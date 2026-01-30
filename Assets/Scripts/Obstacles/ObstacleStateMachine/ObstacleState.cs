using UnityEngine;

public class ObstacleState
{
    protected Obstacle obstacle;
    protected ObstacleStateMachine osm;

    public ObstacleState(Obstacle obstacle, ObstacleStateMachine osm)
    {
        this.obstacle = obstacle;
        this.osm = osm;
    }

    public virtual void EnterState(){}
    public virtual void ExitState(){}
    public virtual void FrameUpdate(){}
    public virtual void PhysicsUpdate(){}
    public virtual void AnimationTriggerEvent(){}
}
