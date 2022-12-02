using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Transform rightGunBone;
    public Transform leftGunBone;
    public GameObject rightGun;
    public GameObject FirePos;
    public GameObject Bullet;
    public TestEnemyUI EnemyUI;
    public Bullet bullet;
    

    public float health;
    public bool isAlive;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        EnemyUI = GameObject.Find("SceneManager").GetComponent<TestEnemyUI>();
        isAlive = true;
    }

    
    // Update is called once per frame
    void Update()
    {
        GameObject newRightGun = (GameObject)Instantiate(rightGun);
        newRightGun.transform.parent = rightGunBone;
        newRightGun.transform.localPosition = Vector3.zero;
        newRightGun.transform.localRotation = Quaternion.Euler(90, 0, 0);
    }

    public void Stay()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 0f);
    }

    public void Run()
    {
        animator.SetBool("Aiming", false);
        animator.SetFloat("Speed", 1f);
    }

    public void Attack()
    {
        Aiming();
        animator.SetTrigger("Attack");
    }

    public void Aiming()
    {
        animator.SetBool("Squat", false);
        animator.SetFloat("Speed", 0f);
        animator.SetBool("Aiming", true);
    }

    public void GunFire()
    {
        if (isAlive)
        {
            Instantiate(Bullet, FirePos.transform.position, transform.rotation);
        }
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
            GetComponent<EnemyAI>().Death();
            Invoke(nameof(DestroyEnemy), 4f);
        }
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
        EnemyUI.EnemyLeft -= 1;
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
