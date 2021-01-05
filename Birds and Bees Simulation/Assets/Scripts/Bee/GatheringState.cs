using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringState : State
{
    public GatheringState(Bee bee, StateMachine stateMachine) : base(bee, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Gathering");
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

        bee.StopSearching();
        bee.AtFlower();

        if (bee.maxCapacity)
        {
            stateMachine.ChangeState(bee.atHive);

        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
