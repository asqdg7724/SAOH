using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int hp = 100;
    public int dp = 100;
    public int bulletCount = 10;
    public int speed = 10;
    public int damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(hp);
        Debug.Log(bulletCount);
        Debug.Log(speed);
        Debug.Log(damage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
