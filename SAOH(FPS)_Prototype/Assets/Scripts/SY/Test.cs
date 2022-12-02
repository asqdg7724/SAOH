using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f);
        Destroy(gameObject, 2.0f);
    }
}
