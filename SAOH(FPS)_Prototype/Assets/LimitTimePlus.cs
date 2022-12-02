using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitTimePlus : TimeLimit
{
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.name + "제한시간 증가");
            limitTime = +180;
            Debug.Log(limitTime);
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
