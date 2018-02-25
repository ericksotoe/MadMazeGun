using UnityEngine;


public class Target : MonoBehaviour {

    // health of the target
    public float health = 30f;
    //public GameObject currTarget;

    

    //public GameObject brokenCrate;
    public void TakeDamage(float amount)
    {
        
        if (this.gameObject.GetComponent<Rigidbody>().mass == 100 && GunScript.currAmmo == AmmoType.RED)
        {
            health -= amount; // decreases the health of the target
            if (health <= 0f)
            {
                Die();
            }
        }

        else if (this.gameObject.GetComponent<Rigidbody>().mass == 200 && GunScript.currAmmo == AmmoType.GREEN)
        {
            health -= amount; // decreases the health of the target
            if (health <= 0f)
            {
                Die();
            }
        }

        else if (this.gameObject.GetComponent<Rigidbody>().mass == 400 && GunScript.currAmmo == AmmoType.BLUE)
        {
            health -= amount; // decreases the health of the target
            if (health <= 0f)
            {
                Die();
            }
        }
        // if the gun is empty
        else if(AmmoType.EMPTY == GunScript.currAmmo && ((int)this.gameObject.GetComponent<Rigidbody>().mass == 499 || 
                                                                   (int)this.gameObject.GetComponent<Rigidbody>().mass == 999 ||
                                                                   this.gameObject.GetComponent<Rigidbody>().mass == 1500))
        {
            health -= amount;
            if (health <= 0f)
            {
                Die();
            }
        }

    }
	

    void Die()
    {
        //Instantiate(brokenCrate, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
        //Instantiate(brokenCrate);
    }
}
