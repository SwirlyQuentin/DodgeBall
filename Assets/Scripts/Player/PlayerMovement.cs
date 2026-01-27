using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public Player player;
    public Rigidbody2D rb;
    public Movement config;
    public Dash dashConfig;
    public float DashCooldown {get; set;}
    public float DashTime {get; set;}
    public float DashSpeed {get; set;}
    public float MoveSpeed {get; set;}
    private Vector2 moveInput;
    private Vector2 dashDirection;

    public bool lockMovement = false;

    private bool canDash = true;
    private float currentDashCooldown = 0f;

    void Awake()
    {
        MoveSpeed = config.speed;
        DashCooldown = dashConfig.DashCooldown;
        DashTime = dashConfig.DashTime;
        DashSpeed = dashConfig.DashSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        // If movement is locked, dont let player move using WASD or another Dash
        if(!lockMovement)
        {
            Move();
        }
        //Still move dash
        if (canDash)
        {
            if (player.StateMachine.CurrentPlayerState is DashState  && lockMovement)
            {
                Dash();
            }   
        }
        else
        {
            currentDashCooldown -= Time.deltaTime;
            if (currentDashCooldown <= 0)
            {
                canDash = true;
            }
        }
    }


    private void Dash()
    {
        rb.linearVelocity = dashDirection * DashSpeed;
        canDash = false;
        currentDashCooldown = DashCooldown;
        // Debug.Log($"Dashing direction: ${dashDirection}  Speed: ${DashSpeed}");
    }

    private void Move()
    {
        moveInput.Normalize();

        rb.linearVelocity = moveInput * MoveSpeed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (moveInput != Vector2.zero)
            {
                dashDirection = moveInput.normalized;
            }
            else
            {
                dashDirection = new Vector2(1, 0);
            }


            player.StateMachine.ChangeState(player.DashState);
        }
    }

    public void LockMovement()
    {
        lockMovement = true;
    }

    public void UnlockMovement()
    {
        lockMovement = false;
    }


}
