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
        // 발사체를 던지기 전에 지연시간 추가
        yield return new WaitForSeconds(0.8f);

        // 물체를 던지려고 하는 위치로 발사체를 이동 + 필요한 경우 오프셋을 추가.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // 목표물까지의 거리 계산
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // 지정된 각도에서 목표물에 물체를 던지는 데 필요한 속도를 계산
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // 속도의 XY 구성요소를 추출
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // 비행 시간을 계산
        float flightDuration = target_Distance / Vx;

        // 목표물을 향하도록 발사체를 회전
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
