using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingState : State
{
    public EatingState(Bird bird, StateMachine stateMachine) : base(bird, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Eating");
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
        bird.energy = 500f; 
        stateMachine.ChangeState(bird.flying);  // Full Energy 
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
