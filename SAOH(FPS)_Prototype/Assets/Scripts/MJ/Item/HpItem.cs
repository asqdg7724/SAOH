using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {        
            Debug.Log(other.gameObject.name + " HP ȸ��");
            other.gameObject.GetComponent<Player>().hp += 10;
            Debug.Log("PlayerHP : " + other.gameObject.GetComponent<Player>().hp);
           
            Destroy(gameObject);
        }
       
    }
}
