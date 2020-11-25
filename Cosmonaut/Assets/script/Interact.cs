﻿using UnityEngine;
//script for interacting with the item
public class Interact : MonoBehaviour
{
    public Camera fpsCam;

    public float PickupRange = 3f;

    public void Start()
    {
        if (GameObject.Find("Rock") && GameObject.Find("Rocket"))
        {
            Debug.Log("Object are in");
        }
        else
        {
            Debug.Log("Object arent in");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractObj();
        }
    }

    void InteractObj ()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        RaycastHit hitObj;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitObj, PickupRange))
        {
            
            Debug.Log(hitObj.transform.name);

            /* if (hitObj.transform.name == "Rock")
             {
                 gm.setMoonRock();
                 Destroy(hitObj.transform.gameObject);
             }*/
            switch (hitObj.transform.tag)
            {
                case "collectible":
                    gm.setMoonRock();
                    Destroy(hitObj.transform.gameObject);
                    break;

                case "Rocket":
                    gm.WinCondition();
                    break;

                default:
                    break;
            }
        }
     
    }
}
