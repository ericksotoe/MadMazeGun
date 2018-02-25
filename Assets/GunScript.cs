using UnityEngine;
using UnityEngine.Audio;

// defines the type of ammo
public enum AmmoType
{
    BLUE,
    RED,
    GREEN,
    WHITE,
    EMPTY
}

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 400f;
    public float impactForce = 30f;
    public float magazine = 5f;
    public static AmmoType currAmmo = AmmoType.GREEN;
    //public float fireRate = 15f;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public AudioClip empty;

    // private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        // left mouse button used for shooting
        if (Input.GetButtonDown("Fire1")) // && Time.time >= nextTimeToFire
        {
            //nextTimeToFire = Time.time + 1f / fireRate;
            if (magazine > 0)
            {
                Shoot();
                magazine--;
            }
            else if (magazine == 0)
            {
                currAmmo = AmmoType.EMPTY;
                ShootEmpty();
            }
        }

        // right mouse button used for reloading
        if (Input.GetButtonDown("Fire2"))
        {
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 10f)) // need to be 5 units away to reload
            {
                //Debug.Log(hit.transform.name); // prints out to console
                Target target = hit.transform.GetComponent<Target>();
                Debug.Log(target);
                if (target != null) // checks for null pointer exception
                {
                    //Debug.Log("reloaded with red");
                    target.TakeDamage(30f);

                    if ((int)hit.rigidbody.mass == 499)
                    {
                        this.Reload(AmmoType.RED);

                    }
                    else if ((int)hit.rigidbody.mass == 999)
                    {
                        this.Reload(AmmoType.GREEN);
                    }
                    else if ((int)hit.rigidbody.mass == 1500)
                    {
                        this.Reload(AmmoType.BLUE);
                    }
                }
            }

        }
    }

    // reloads the magazine with 5 new bullets of defined type
    public void Reload(AmmoType newAmmo)
    {
        magazine = 5f;
        currAmmo = newAmmo;
    }

    public void ShootEmpty()
    {
        Debug.Log("gun is empty");
    }


    public void Shoot ()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
