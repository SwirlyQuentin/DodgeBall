using UnityEngine;

public class PlayerState
{

    protected Player player;
    protected PlayerStateMachine psm;


    public PlayerState(Player player, PlayerStateMachine psm)
    {
        this.player = player;
        this.psm = psm;
    }

    public virtual void EnterState(){}
    public virtual void ExitState(){}
    public virtual void FrameUpdate(){}
    public virtual void PhysicsUpdate(){}
    public virtual void AnimationTriggerEvent(){}
    
}
