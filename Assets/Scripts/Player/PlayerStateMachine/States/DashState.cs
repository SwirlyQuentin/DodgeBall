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
        player.movement.StartDash();
        timer = dashConfig.DashTime;
    }

    public override void ExitState()
    {
        base.ExitState();
        player.movement.UnlockMovement();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.movement.KeepDashSpeed();
        timer -= Time.fixedDeltaTime;

        if (timer <= 0)
        {
            player.StateMachine.ChangeState(player.DefaultState);
        }
    }
}
