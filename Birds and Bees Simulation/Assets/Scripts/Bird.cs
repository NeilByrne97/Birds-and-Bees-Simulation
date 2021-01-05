using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public StateMachine movementSM;
    public FlyingState flying;
    public ChasingState chasing;
    public EatingState eating;
    public RestingState resting;

    public float movementSpeed = 1.0f;
    public float rotationSpeed = 45.0f;
    public bool chaseTrigger = false;
    public bool caughtTrigger = false;

    public GameObject bee;

    public PathCreation.Examples.PathFollower pathFollower;

    private void OnTriggerEnter(Collider other)
    {
        print("Bird Trigger from Bird");
        chaseTrigger = true;
    }

    private void Start()
    {
        Debug.Log("Bird");
        movementSM = new StateMachine();
        flying = new FlyingState(this, movementSM);
        chasing = new ChasingState(this, movementSM);
        eating = new EatingState(this, movementSM);
        resting = new RestingState(this, movementSM);

        movementSM.Initialize(flying);  // Default

    }

    private void Update()
    {
        movementSM.CurrentState.HandleInput();

        movementSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        movementSM.CurrentState.PhysicsUpdate();
    }

    public void Flying()
    {
        gameObject.GetComponent<PathFollower>().enabled = true;  
    }

    public void StopFlying()
    {
        gameObject.GetComponent<PathFollower>().enabled = false;
    }

    public void ChaseBee()
    {
        if(bee == null)
        {
            return;
        }
        Quaternion targetRotation = Quaternion.LookRotation(bee.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 + Time.deltaTime);
        transform.position += transform.forward * 8f * Time.deltaTime;
      
        if(Vector3.Distance(bee.transform.position, transform.position) < 1.0f)
        {
            print("Touch");
            Destroy(bee);
            caughtTrigger = true;
            
        }
    }

}
