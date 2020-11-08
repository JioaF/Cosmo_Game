using UnityEngine;
// script Refrence : https://www.youtube.com/watch?v=THnivyG0Mvo&t=69s
// not yet finished
public class Target : MonoBehaviour
{
    public float hp = 5f;
     
    public void TakeDamage(float amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            Destroyed();
        }
    }

    void Destroyed()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
