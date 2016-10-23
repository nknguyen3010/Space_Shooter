using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerDeath;

    void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("Boundary")) return;

        if (other.CompareTag("Asteroid")) return;

        if (other.CompareTag("Player"))
        {
            Instantiate(playerDeath, other.transform.position , other.transform.rotation);
            Destroy(other.gameObject);
            return;
        }
        Instantiate(explosion,transform.position,transform.rotation);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }

}
