using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingState : State
{
    bool beeInRange = false;
    bool noEnergy = false;

    public FlyingState(Bird bird, StateMachine stateMachine) : base(bird, stateMachine)
    {
    }

    public override void Enter()
    {
        Debug.Log("Flying");
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();     
    }

    public override void HandleInput()
    {
        base.HandleInput();
        if(bird.birdTrigger == true)
        {
            print("Collision Trigger in Flying State");
            beeInRange = true;
        }
    }
   
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        bird.Flying();

        if (beeInRange)
        {
            stateMachine.ChangeState(bird.chasing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

