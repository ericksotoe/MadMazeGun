using UnityEngine;

public class Target : MonoBehaviour {

    // health of the target
    public float health = 50f;

    public GameObject brokenCrate;
    public void TakeDamage(float amount)
    {
        health -= amount; // decreases the health of the target
        if (health <= 0f)
        {
            Die();
        }
    }
	

    void Die()
    {
        Instantiate(brokenCrate, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
        //Instantiate(brokenCrate);
    }
}
