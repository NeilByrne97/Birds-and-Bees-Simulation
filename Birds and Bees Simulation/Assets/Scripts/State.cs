using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Bird bird;
    protected StateMachine stateMachine;

    protected State(Bird bird, StateMachine stateMachine)
    {
        this.bird = bird;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        DisplayOnUI(UIManager.Alignment.Left);
    }

    public virtual void HandleInput()
    {
        
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Exit()
    {

    }

    protected void DisplayOnUI(UIManager.Alignment alignment)
    {
        UIManager.Instance.Display(this, alignment);
    }
}

