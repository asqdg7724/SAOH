using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    Animator animator;
    public float health;
    public bool isAlive;
    public TestEnemyUI EnemyUI;
    public Bullet bullet;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyUI = GameObject.Find("SceneManager").GetComponent<TestEnemyUI>();
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Run()
    {
        animator.SetFloat("Speed", 1f);
    }

    public void Attack()
    {
        if (isAlive)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void Stay()
    {
        animator.SetFloat("Speed", 0f);
    }

    public void TakeDamage(float damage)
    {
        damage = bullet.damage;
        health -= damage;
        animator.SetTrigger("Damage");

        if (health <= 0)
        {
            isAlive = false;
            animator.SetTrigger("Death");
            GetComponent<MeleeEnemyAI>().Death();
            Invoke(nameof(DestroyEnemy), 2f);
            EnemyUI.EnemyLeft -= 1;
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullet")
        {
            if (isAlive)
            {
                TakeDamage(1);
                Destroy(other.gameObject);
            }
        }
    }
}
