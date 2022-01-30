using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    //public float min;
    //public float max;

    // private float nextActionTime = 0.0f;
    // public float period = 0.1f;

   private Vector2 randRange;

	// Use this for initialization

    void Update()
    {
        //randRange = new Vector2(Random.Range(min, max), Random.Range(min, max));
        // if (Time.time > nextActionTime){
        //     nextActionTime = Time.time + period;

        //     spawnTime--;
        //     spawnDelay--;
        // }
    }
	void Start () {
		InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
	}
	
    public void SpawnObject() {
        Instantiate(spawnee, transform.position, transform.rotation);
        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }
}