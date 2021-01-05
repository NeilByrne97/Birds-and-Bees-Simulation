using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchingState : State
{
    public bool atFlower = false;

    public SearchingState(Bee bee, StateMachine stateMachine) : base(bee, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Searching State");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if (bee.gatherTrigger)
        {
            atFlower = true;
        }
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        bee.Searching();

        if (atFlower)
        {
            stateMachine.ChangeState(bee.gathering);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
