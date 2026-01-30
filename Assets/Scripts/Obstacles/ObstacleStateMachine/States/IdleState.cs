using UnityEngine;

public class IdleState : ObstacleState
{
    public IdleState(Obstacle obstacle, ObstacleStateMachine osm) : base(obstacle, osm)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        obstacle.AttackSource.StopAttack();
    }
}