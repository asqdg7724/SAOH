using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    Rigidbody rb;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * moveSpeed, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.back * moveSpeed, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * moveSpeed, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * moveSpeed, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyAttack")
        {
            Debug.Log("µ¥¹ÌÁö!");
        }
    }
}
