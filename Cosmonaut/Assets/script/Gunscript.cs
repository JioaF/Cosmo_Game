using UnityEngine;
// script Refrence : https://www.youtube.com/watch?v=THnivyG0Mvo&t=69s
// script for The gun Mechanic
public class Gunscript : MonoBehaviour
{
    public Camera fpsCam;
    public ParticleSystem MuzzleFlash;
    public GameObject impactEffect;
    public Light lightFlash;

    public int damage = 1;
    public float range = 120f;
  /*public float impactForce = 30f;*/
    public float fireRate = 7f;

    private float nextTimeToFire = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
          
            Shoot();
           
        }
        else
        {
            lightFlash.enabled = false;
        }
    }

    void Shoot()
    {
        //FindObjectOfType<audioManager>().Play("Firing");
        RaycastHit hit;
        MuzzleFlash.Play();
        
        lightFlash.enabled = true;
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            /*if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }*/

           GameObject Effect = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(Effect, 1.5f);
            
        }
    }
}
