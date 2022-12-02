using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public LayerMask layerMask;
    public GameObject player;
    bool isAlive = true;

    // 공격 기능 관련 변수
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");//(transform.position.x, player.position.y, player.position.z);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive == false)
            return;


        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, layerMask);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, layerMask);

        if (!playerInSightRange && !playerInAttackRange)
        {
            WaitPlayer();
        }

        if (playerInAttackRange && playerInSightRange)
        {
            // Debug.Log("플레이어 공격");
            AttackPlayer();
        }

        if (playerInSightRange && !playerInAttackRange)
        {
            // Debug.Log("플레이어 인식");
            SetDestinationPlayer(player.transform);
        }
    }

    public void WaitPlayer()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        agent.SetDestination(transform.position);
        GetComponent<MeleeEnemy>().Stay();
        transform.LookAt(targetPosition);
    }

    public void SetDestinationPlayer(Transform player)
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);
        GetComponent<MeleeEnemy>().Run();
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(targetPosition);

        if (!alreadyAttacked)
        {
            // 공격하는 코드
            GetComponent<MeleeEnemy>().Attack();
            ////////////////
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void Death()
    {
        isAlive = false;
        agent.SetDestination(transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
