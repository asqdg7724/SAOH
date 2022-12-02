using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public float enemyHP;
    private Test bullet;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        { 
            Destroy(other.gameObject);

            enemyHP -= bullet.damage;

            if (enemyHP <= 0)
            {
                Destroy(this.gameObject);
                EnemyDie();
            }
            

        }
    }

    public void EnemyDie()
    {
        Debug.Log("Àû Á×À½");
    }

}
