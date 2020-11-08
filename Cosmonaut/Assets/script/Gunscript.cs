using UnityEngine;
// script Refrence : https://www.youtube.com/watch?v=THnivyG0Mvo&t=69s
// not yet finished 
public class Gunscript : MonoBehaviour
{
    public float damage = 1f;
    public float range = 100f;

    public Camera fpsCam;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
