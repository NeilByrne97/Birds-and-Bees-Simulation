using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public float movementSpeed = 1.0f;
    public float rotationSpeed = 45.0f;

    private void OnTriggerEnter(Collider other)
    {
        print("Bee Trigger");
        transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }



}
