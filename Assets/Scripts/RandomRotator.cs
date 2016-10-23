using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {

    public Rigidbody rb;
    public float tumble;
    void Start()
    {
        tumble = Random.Range(5,11);
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }


    

}
