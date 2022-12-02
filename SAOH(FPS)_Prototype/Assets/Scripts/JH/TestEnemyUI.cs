using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestEnemyUI : MonoBehaviour
{
    public Text LeftEnemy;
    public int EnemyLeft;

    public GameObject BlockObject;
    public GameObject EnemySpawn_0;
    public GameObject EnemySpawn_1;
    public GameObject EnemySpawn_2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftEnemy.text = EnemyLeft.ToString();

        if (EnemyLeft == 45)
        {
            EnemySpawn_0.SetActive(true);
        }
        
        else if (EnemyLeft == 30)
        {
            EnemySpawn_1.SetActive(true);
        }

        else if (EnemyLeft == 15)
        {
            EnemySpawn_2.SetActive(true);
        }

        else if (EnemyLeft <= 0)
        {
            BlockObject.SetActive(false);
        }
    }


}
