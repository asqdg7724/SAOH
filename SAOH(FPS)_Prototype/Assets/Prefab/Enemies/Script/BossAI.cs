using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAI : MonoBehaviour
{
    public GameObject MeleeAttackCol;
    public NavMeshAgent agent;

    public LayerMask layerMask;
    public Transform player;

    public float timeBetweenAttacks;
    public float timeBetweenMeleeAttacks;
    bool alreadyAttacked;

    public float throwRange, stompRange;
    public bool playerInThrowRange, playerInStompRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInThrowRange = Physics.CheckSphere(transform.position, throwRange, layerMask);
        playerInStompRange = Physics.CheckSphere(transform.position, stompRange, layerMask);

        if (!playerInStompRange)
        {
            WaitPlayer();
        }

        if (playerInStompRange)
        {
            //Debug.Log("플레이어 공격");
            StompingPlayer();
        }

        if (playerInThrowRange && !playerInStompRange)
        {
            //Debug.Log("플레이어 인식");
            AttackPlayer();
            //SetDestinationPlayer(player.transform);
        }
    }

    public void WaitPlayer()
    {
        agent.SetDestination(transform.position);
        GetComponent<Boss>().Stay();
        transform.LookAt(player);
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 targetPosition = new Vector3(player.transform.position.x, 
            transform.position.y, player.transform.position.z);

        transform.LookAt(targetPosition);

        if (!alreadyAttacked)
        {
            // 공격하는 코드
            GetComponent<Boss>().Attack();
            ////////////////
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public void StompingPlayer()
    {
        agent.SetDestination(transform.position);

        Vector3 targetPosition = new Vector3(player.transform.position.x, 
            transform.position.y, player.transform.position.z);

        transform.LookAt(targetPosition);
        
        if (!alreadyAttacked)
        {
            GetComponent<Boss>().Stomp();

            StartCoroutine(Stomping());

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenMeleeAttacks);
        }
    }

    public void ThrowObjectAttackPlayer()
    {

    }

    public void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void SetDestinationPlayer(Transform player)
    {
        GetComponent<NavMeshAgent>().SetDestination(player.position);
        GetComponent<Boss>().Move();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stompRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, throwRange);
    }

    IEnumerator Stomping()
    {
        MeleeAttackCol.SetActive(true);
        yield return new WaitForSeconds(1f);
        MeleeAttackCol.SetActive(false);
    }
}
