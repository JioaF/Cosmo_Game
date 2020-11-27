using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rock : MonoBehaviour
{
    public Text Rock; 

    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.collider.tag == "Player")
        {
            Debug.Log("Hit");
            Rock.text = "PICKUP";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
       
        if (collision.collider.tag == "Player")
        {
            Debug.Log("not Hit");
            Rock.text = "";
        }
        
    }
}
