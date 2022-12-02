using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    //추적 기능 관련 변수
    public LayerMask layerMask;
    public GameObject player;
    bool isAlive = true;

    // 공격 기능 관련 변수
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    // 상태
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
            if (GetComponent<Enemy>().isAlive == true) 
                // Debug.Log("플레이어 인식");
                SetDestinationPlayer(player.transform);
        }
    }

    public void SetDestinationPlayer(Transform player)
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);
        GetComponent<Enemy>().Run();
    }



    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(targetPosition);

        if (!alreadyAttacked)
        {
            // 공격하는 코드
            GetComponent<Enemy>().Attack();
            GetComponent<Enemy>().GunFire();
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

    public void WaitPlayer()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        agent.SetDestination(transform.position);
        GetComponent<Enemy>().Stay();
        transform.LookAt(targetPosition);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(2f);
    }
}
