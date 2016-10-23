using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController:MonoBehaviour
{

    public Rigidbody player;
    public AudioSource audioSource;
    private float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate = 0.5f;
    public float nextFire = 0.0f;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody>(); // get Player GameObject reference
        speed = 20f;
        audioSource.GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space) && Time.time>nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot,shotSpawn.position,shotSpawn.rotation);
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        player.velocity = movement * speed;

        player.position = new Vector3(
            Mathf.Clamp(player.position.x,boundary.xMin,boundary.xMax),
            0.0f,
            Mathf.Clamp(player.position.z,boundary.zMin,boundary.zMax)
            );
        player.rotation = Quaternion.Euler(0.0f,0.0f,player.velocity.x * -tilt);
    }


}
