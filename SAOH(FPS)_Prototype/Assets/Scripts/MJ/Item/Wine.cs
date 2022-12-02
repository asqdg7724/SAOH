using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wine : MonoBehaviour
{

    public void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name + " øÕ¿Œ »πµÊ");
            other.gameObject.GetComponent<Player>().damage += 5;
            other.gameObject.GetComponent<Player>().speed -= 2;
            Debug.Log("speed : " + other.gameObject.GetComponent<Player>().speed);
            Debug.Log("damage : " + other.gameObject.GetComponent<Player>().damage);
            Destroy(gameObject);
        }
    }
}
