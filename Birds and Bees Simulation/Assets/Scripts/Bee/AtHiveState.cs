using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtHiveState : State
{
    public AtHiveState(Bee bee, StateMachine stateMachine) : base(bee, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        bee.MaxCapacity();

        if (bee.arrivedAtHive)
        {
            stateMachine.ChangeState(bee.dancing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
