using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingState : State
{
    public DancingState(Bee bee, StateMachine stateMachine) : base(bee, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Dancing");
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

        while(bee.nectar >= 0)
        {
            bee.nectar -= 0.2f;
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
