using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabola : MonoBehaviour
{
    public int durability = 1;
    public Transform Target;
    public float firingAngle = 45.0f;
    public float gravity = 9.8f;

    public Transform Projectile;
    private Transform myTransform;

    public GameObject explosionEffect;

    void Awake()
    {
        myTransform = transform;
        Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        StartCoroutine(SimulateProjectile());
    }


    IEnumerator SimulateProjectile()
    {
        // �߻�ü�� ������ ���� �����ð� �߰�
        yield return new WaitForSeconds(0.8f);

        // ��ü�� �������� �ϴ� ��ġ�� �߻�ü�� �̵� + �ʿ��� ��� �������� �߰�.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // ��ǥ�������� �Ÿ� ���
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // ������ �������� ��ǥ���� ��ü�� ������ �� �ʿ��� �ӵ��� ���
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // �ӵ��� XY ������Ҹ� ����
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // ���� �ð��� ���
        float flightDuration = target_Distance / Vx;

        // ��ǥ���� ���ϵ��� �߻�ü�� ȸ��
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            Projectile.Translate(0, (Vy - (gravity * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        StartCoroutine(Explosion());

        if (col.gameObject.tag == "PlayerBullet")
        {
            TakeDamage(1);
            Destroy(this.gameObject);
        }
    }

    IEnumerator Explosion()
    {
        Instantiate(explosionEffect, Projectile);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        durability -= damage;

        if (durability <= 0)
        {
            Instantiate(explosionEffect, Projectile);
        }
    }
}
