using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name + " speedUP È¹µæ");

            other.gameObject.GetComponent<Player>().speed += 5;
            Debug.Log("speed : " + other.gameObject.GetComponent<Player>().speed);
            Destroy(gameObject); 
        }
       

    }
}
