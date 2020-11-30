using UnityEngine.AI;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class bot : MonoBehaviour
{
    public Text Timetext;
    public NavMeshAgent agent;
    public Transform player;
    private GameManager GM;
    private timer timer;
    

    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        timer = FindObjectOfType<timer>();
        FindObjectOfType<audioManager>().Play("EnemyAppear");
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
            GM.player.SetActive(false);
            GM.Gc.SetActive(false);
            GM.mob.SetActive(false);
            GM.Gover.SetActive(true);
            GM.SetCursor(true);
            Timetext.text = "TIME : " + timer.timetxt;
            
        }
    }
}
