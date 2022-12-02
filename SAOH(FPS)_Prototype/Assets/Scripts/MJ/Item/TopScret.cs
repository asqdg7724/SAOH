using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopScret : MonoBehaviour
{
    public GameObject topSecret;

// Start is called before the first frame update
   private void Start()
    {
        topSecret.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
        Debug.Log(other.gameObject.name + "È¹µæ");
        topSecret.SetActive(true);
        Destroy(gameObject);
        }

    }

}
