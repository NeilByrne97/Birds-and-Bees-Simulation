using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public StateMachine movementSM;
    public SearchingState searching;
    public FleeingState fleeing;
    public GatheringState gathering;
    public DancingState dancing;
    public AtHiveState atHive;

    public float movementSpeed = 1.0f;
    public float rotationSpeed = 45.0f;
    public bool gatherTrigger = false;

    public GameObject flower;
    public GameObject hive;

    public bool arrivedAtFlower = false;
    public bool arrivedAtHive = false;

    public bool maxCapacity = false;


    public float energy = 500f;
    public float nectar = 0f;

    public PathCreation.Examples.PathFollower pathFollower;

    private void OnTriggerEnter(Collider other)
    {
        print("Bee Trigger from Bee");
        gatherTrigger = true;
    }

    private void Start()
    {
        Debug.Log("Bee");
        movementSM = new StateMachine();
        searching = new SearchingState(this, movementSM);
        fleeing = new FleeingState(this, movementSM);
        gathering = new GatheringState(this, movementSM);
        dancing = new DancingState(this, movementSM);
        atHive = new AtHiveState(this, movementSM);

        movementSM.Initialize(searching);  // Default

    }

    private void Update()
    {
        movementSM.CurrentState.HandleInput();

        movementSM.CurrentState.LogicUpdate();

        //print("Bee energy is " + energy);
        print("Bee nectar is " + nectar);

    }

    private void FixedUpdate()
    {
        movementSM.CurrentState.PhysicsUpdate();
    }

    public void Searching()
    {
        gameObject.GetComponent<PathFollower>().enabled = true;
    }

    public void StopSearching()
    {
        gameObject.GetComponent<PathFollower>().enabled = false;
    }


    public void AtFlower()
    {
        print("At Flower");
        Quaternion targetRotation = Quaternion.LookRotation(flower.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 + Time.deltaTime);
        transform.position += transform.forward * 8f * Time.deltaTime;

        if (Vector3.Distance(flower.transform.position, transform.position) < 1.0f)
        {
            // arrivedAtFlower = true;
            nectar += 100f;
            maxCapacity = true;

        }
    }

    public void MaxCapacity()
    {
        print("Max Capacity");
        Quaternion targetRotation = Quaternion.LookRotation(hive.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 + Time.deltaTime);
        transform.position += transform.forward * 8f * Time.deltaTime;


        if (Vector3.Distance(hive.transform.position, transform.position) < 1.0f)
        {
            print("Go to Hive");
            arrivedAtHive = true;   

        }
    }

}
