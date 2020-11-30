using UnityEngine;
using UnityEngine.AI;
// script Refrence : https://www.youtube.com/watch?v=THnivyG0Mvo&t=69s
// script for the enemy
public class Target : MonoBehaviour
{
    public GameObject spawner;
    public GameObject mob;
    public NavMeshAgent agent;

    private GameManager gm;

    public int hp = 7;

    private void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            FindObjectOfType<audioManager>().Stop("EnemyAppear");
            gm.mob.SetActive(false);
            Invoke(nameof(Respawn), 10f);
        }
    }

    void Respawn()
    {
        Debug.Log("Respawn");
        gm.mob.SetActive(true);
        hp = 7;
        mob.transform.position = spawner.transform.position;
        FindObjectOfType<audioManager>().Play("EnemyAppear");

        agent.speed += 6f;
        agent.acceleration += 11f;
    }
}
