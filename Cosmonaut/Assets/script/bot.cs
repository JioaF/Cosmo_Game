using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine;

public class bot : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    private GameManager GM;
    

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        FindObjectOfType<audioManager>().Play("EnemyAppear");
    }

    private void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
        
    }
     private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
           FindObjectOfType<audioManager>().Play("PlayerDead");
            FindObjectOfType<audioManager>().Stop("EnemyAppear");
           GM.Gover.SetActive(true);
           GM.player.SetActive(false);
           GM.Gc.SetActive(false);
           GM.mob.SetActive(false);
           Cursor.lockState = CursorLockMode.None;

        }
    }
}
