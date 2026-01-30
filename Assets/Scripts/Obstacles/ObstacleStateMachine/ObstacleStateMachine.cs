using UnityEngine;

public class ObstacleStateMachine
{
    public ObstacleState CurrentObstacleState {get; set;}

    public void Initialize(ObstacleState startingState)
    {
        CurrentObstacleState = startingState;
        startingState.EnterState();
    }

    public void ChangeState(ObstacleState newState)
    {
        CurrentObstacleState.ExitState();
        CurrentObstacleState = newState;
        newState.EnterState();
    }


}
