using UnityEngine;
//script for interacting with the item
public class Interact : MonoBehaviour
{
    public Camera fpsCam;
    public float PickupRange = 3f;

    public void Start()
    {
       GameObject.Find("MoonRock");
       GameObject.Find("Rock");
      
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupItem();
        }
    }

    void PickupItem ()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        RaycastHit hitObj;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hitObj, PickupRange))
        {
            
            Debug.Log(hitObj.transform.name);
            if (hitObj.transform.name == "Rock")
            {
                /*GameObject Rock = GameObject.Find("MoonRock");
                gm.MoonRock += 1;
                Destroy(Rock,2f);
                Debug.Log("Rock : " + gm.MoonRock);*/
            }
        }
     
    }
}
