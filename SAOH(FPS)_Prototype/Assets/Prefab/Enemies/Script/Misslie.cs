using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misslie : MonoBehaviour
{
    Rigidbody rb;
    public float misslieSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * misslieSpeed, ForceMode.Impulse);
    }
}
