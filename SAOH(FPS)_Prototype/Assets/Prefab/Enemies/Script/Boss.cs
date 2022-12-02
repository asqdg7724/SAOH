using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator animator;
    public int health;
    public bool isAlive;

    public Transform Leg;
    public GameObject DeathExplosion;
    public GameObject Car;
    public Transform ThrowPos;

    public InGamePageManager GM;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move()
    {
        animator.SetFloat("Speed", 1f);
    }

    public void Attack()
    {
        if (isAlive)
        {
            animator.SetTrigger("Fire");
            Instantiate(Car, ThrowPos);
        }
    }

    public void Stomp()
    {
        animator.SetTrigger("Stomp");
    }

    public void Stay()
    {
        animator.SetFloat("Speed", 0f);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            isAlive = false;
            animator.SetTrigger("Death");
            StartCoroutine(DestroyRobot());
            GM.StageClear();
        }
    }

    IEnumerator DestroyRobot()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(DeathExplosion, this.transform);
    }

    void DestroyEnemy()
    {
        Instantiate(DeathExplosion, this.transform);
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBullet")
        {
            if (isAlive)
            {
                TakeDamage(1);
                Destroy(other.gameObject);
            }
        }
    }
}
