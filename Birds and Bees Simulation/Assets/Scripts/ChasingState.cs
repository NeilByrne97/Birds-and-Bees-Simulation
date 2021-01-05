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
        
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        bird.StopFlying();
        bird.ChaseBee();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
