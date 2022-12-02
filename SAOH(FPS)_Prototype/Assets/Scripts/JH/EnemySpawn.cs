using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    // ������ ����� Plane�� �ڽ��� RespawnRange ������Ʈ
    public GameObject rangeObject;
    BoxCollider rangeCollider;
    public GameObject[] enemies;
    public float spawnTime;
    public int enemyCount;
    public int enemyCountMax;


    private void Awake()
    {
        rangeCollider = rangeObject.GetComponent<BoxCollider>();
    }

    private void Start()
    {
        StartCoroutine(RandomRespawn_Coroutine());
    }

    Vector3 Return_RandomPosition()
    {
        Vector3 originPosition = rangeObject.transform.position;
        // �ݶ��̴��� ����� �������� bound.size ���
        float range_X = rangeCollider.bounds.size.x;
        float range_Z = rangeCollider.bounds.size.z;

        range_X = Random.Range((range_X / 2) * -1, range_X / 2);
        range_Z = Random.Range((range_Z / 2) * -1, range_Z / 2);
        Vector3 RandomPostion = new Vector3(range_X, 0f, range_Z);

        Vector3 respawnPosition = originPosition + RandomPostion;
        return respawnPosition;
    }

    IEnumerator RandomRespawn_Coroutine()
    {
        int enemisArray = Random.Range(0, enemies.Length);

        while (enemyCount < enemyCountMax)
        {
            yield return new WaitForSeconds(spawnTime);

            // ���� ��ġ �κп� ������ ���� �Լ� Return_RandomPosition() �Լ� ����
            GameObject instantEnemy = Instantiate(enemies[Random.Range(0, enemies.Length)], 
                Return_RandomPosition(), Quaternion.identity);
            enemyCount += 1;
        }
    }
}
