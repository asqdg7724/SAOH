using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firing : MonoBehaviour
{
    public float fireRange;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        Ray ray = FindObjectOfType<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, fireRange))
        {
            Debug.Log(hit.transform.name);
        }

        else
        {
            Debug.Log("¾øÀ½");
        }
    }
}
