using UnityEngine;

public class Player : MonoBehaviour
{

    public Dash dashConfig;

    public PlayerMovement movement;
    public HealthComponent health;
    
    #region PlayerStateMachine Variables

    public PlayerStateMachine StateMachine {get; set;}

    public DefaultState DefaultState {get; set;}
    public DashState DashState {get; set;}



    #endregion

    void Awake()
    {
        StateMachine = new PlayerStateMachine();

        DefaultState = new DefaultState(this, StateMachine);
        DashState = new DashState(this, StateMachine, dashConfig);
    }

    void Start()
    {
        StateMachine.Initialize(DefaultState);
    }

    void Update()
    {
        StateMachine.CurrentPlayerState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentPlayerState.PhysicsUpdate();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
