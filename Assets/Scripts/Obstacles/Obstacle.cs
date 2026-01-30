using UnityEngine;

public class Obstacle : MonoBehaviour
{
    

    public IAttackSource AttackSource;

    #region State Machine Variables

    public ObstacleStateMachine StateMachine {get; set;}

    public IdleState IdleState {get; set;}
    public AttackState AttackState {get; set;}

    #endregion

    void Awake()
    {
        StateMachine = new ObstacleStateMachine();

        IdleState = new IdleState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);

        AttackSource = gameObject.GetComponent<IAttackSource>();
    }

    public void DetectObjectEnter(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            AttackSource.SetTarget(collider.transform);
            StateMachine.ChangeState(AttackState);

        }
    }

    public void DetectObjectExit(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            StateMachine.ChangeState(IdleState);
        }
    }


    void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    void Update()
    {
        StateMachine.CurrentObstacleState.FrameUpdate();
    }

    void FixedUpdate()
    {
        StateMachine.CurrentObstacleState.PhysicsUpdate();
    }

}
