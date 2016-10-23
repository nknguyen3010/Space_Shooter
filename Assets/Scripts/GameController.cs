using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Rigidbody hazard;
    public Vector3 spawnValues;
    public float hazardCount; // hazard number of that wave
    public float waitStartTime; // time for player to prepare to fight
    public float spawnTime; // time to spawn new hazard ( sequentially)
    public float waveTime; // time to next wave


	void Start()
    {
        StartCoroutine(SpawnWaves());
 
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(waitStartTime); // wait for player to prepare to fight
        while(true) // keep generate waves
        {
            for(int i = 0; i<hazardCount;i++) // wave
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard,spawnPosition,spawnRotation);
                yield return new WaitForSeconds(spawnTime);
            }
            yield return new WaitForSeconds(waveTime); // wait for next wave
        }
        

    }

}
