using UnityEngine.AI;
using UnityEngine;

public class chase_Player : MonoBehaviour
{
    private NavMeshAgent agent;
    public patrolling patrol;
    public GameObject player;
    private GameManager gm;

    public float BotDistanceRun = 30f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
       
        float distance = Vector3.Distance(transform.position, player.transform.position);

        //run towards player
        if (distance < BotDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newpos = transform.position - dirToPlayer;

            agent.SetDestination(newpos);
        }else if(distance > BotDistanceRun)
        {
            patrol.patrol();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            gm.Gover.SetActive(true);
            gm.player.SetActive(false);
            gm.Gc.SetActive(false);
            gm.mob.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
        }
       
    }
}
