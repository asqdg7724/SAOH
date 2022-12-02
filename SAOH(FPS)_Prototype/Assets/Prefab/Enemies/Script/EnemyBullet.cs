using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    Rigidbody rb;
    public float bulletSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
    }
}
