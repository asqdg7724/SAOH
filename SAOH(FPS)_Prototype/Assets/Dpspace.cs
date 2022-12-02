using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dpspace : MonoBehaviour
{
    public PlayerCol playerCol;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            playerCol.currDP += 10.0f;
        }
    }
}
