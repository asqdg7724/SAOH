using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCount : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name + " �Ѿ�ȹ��");
            other.gameObject.GetComponent<Player>().bulletCount += 5;           
            Debug.Log("�Ѿ� �� : " + other.gameObject.GetComponent<Player>().bulletCount);
            Destroy(gameObject);
        }
    }
}
