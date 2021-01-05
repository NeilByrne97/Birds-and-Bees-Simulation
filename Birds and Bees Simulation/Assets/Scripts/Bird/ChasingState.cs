using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    public ChasingState(Bird bird, StateMachine stateMachine) : base(bird, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("ChasingState");
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
        bird.energy -= 0.8f;

        base.LogicUpdate();
        if (!bird.caughtTrigger)
        {
            bird.StopFlying();
            bird.ChaseBee();

        }
        if (bird.caughtTrigger)
        {
            stateMachine.ChangeState(bird.eating);  // Caught Bee
        } 

        if(bird.energy <= 0.0f)
        {
            stateMachine.ChangeState(bird.resting); // No Energy
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
