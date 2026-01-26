using UnityEngine;

public class DashState : PlayerState
{
    public Dash dashConfig;
    private float timer;
    
    public DashState(Player player, PlayerStateMachine psm, Dash dashConfig) : base(player, psm)
    {
        this.dashConfig = dashConfig;
    }

    public override void EnterState()
    {
        base.EnterState();
        player.movement.LockMovement();
        timer = dashConfig.DashTime;
    }

    public override void ExitState()
    {
        base.ExitState();
        player.movement.UnlockMovement();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            player.StateMachine.ChangeState(player.DefaultState);
        }

    }
}
