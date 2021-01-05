using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingState : State
{
    public RestingState(Bird bird, StateMachine stateMachine) : base(bird, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Resting");
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

        bird.StopFlying();
        bird.energy += 0.3f;
        if(bird.energy >= 500.0f)  
        {
            stateMachine.ChangeState(bird.flying);  // Full energy
        }

       

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
