using UnityEngine;
// script Refrence : https://www.youtube.com/watch?v=THnivyG0Mvo&t=69s
// script for the enemy
public class Target : MonoBehaviour
{
    public int hp = 15;
     
    public void TakeDamage(int amount)
    {
        Debug.Log(hp -= amount);
        if (hp <= 0)
        {
            Destroyed();
        }
    }

    void Destroyed()
    {
        Destroy(gameObject);
    }
}
