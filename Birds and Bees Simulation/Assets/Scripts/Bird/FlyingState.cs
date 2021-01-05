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
        if(bird.chaseTrigger == true)
        {
            print("Collision Trigger in Flying State");
            beeInRange = true;
        }
    }
   
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        bird.Flying();
        bird.energy -= 0.4f;

        if (beeInRange)
        {
            stateMachine.ChangeState(bird.chasing); // Bee in range
        }

        if (bird.energy <= 0.0f)    
        {
            print("bird is tired - go to bed");
            stateMachine.ChangeState(bird.resting); // No energy
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}

