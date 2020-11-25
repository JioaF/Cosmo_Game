using UnityEngine;
using UnityEngine.AI;

public class patrolling : MonoBehaviour
{
    public Transform[] wp;
    public NavMeshAgent agent;

    private int wpIndex;
    private float distance;
    private float range = 200f;
    private float speed = 5f;

    private void Start()
    {
        wpIndex = 0;
        transform.LookAt(wp[wpIndex].position);
    }

    public void patrol()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void increaseIndex()
    {
        wpIndex++;
        if (wpIndex >= wp.Length)
        {
            wpIndex = 0;
        }
        transform.LookAt(wp[wpIndex].position);
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, wp[wpIndex].position);
        if (distance < range)
        {
            increaseIndex();
        }
        patrol();
    }
}
