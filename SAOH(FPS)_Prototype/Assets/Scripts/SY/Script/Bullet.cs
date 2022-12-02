using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;
    // Update is called once per frame
    private void Start()
    {
        damage = 30;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f);
        Destroy(gameObject, 2.0f);
    }
}
