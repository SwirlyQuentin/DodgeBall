using UnityEngine;

public class AttackState : ObstacleState
{
    public AttackState(Obstacle obstacle, ObstacleStateMachine osm) : base(obstacle, osm)
    {
    }


    public override void EnterState()
    {
        base.EnterState();
        obstacle.AttackSource.StartAttack();
    }
}