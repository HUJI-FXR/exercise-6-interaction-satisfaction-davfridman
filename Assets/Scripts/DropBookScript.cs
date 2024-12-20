using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBookScript : MonoBehaviour
{
    public float impulseStrength = 5f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ApplyBackwardImpulse()
    {
        Vector3 backwardDirection = -transform.forward;
        rb.AddForce(backwardDirection * impulseStrength, ForceMode.Impulse);
    }
}
