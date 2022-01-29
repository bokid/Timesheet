using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

    public GameObject spawnee;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;

    // private float nextActionTime = 0.0f;
    // public float period = 0.1f;

    private Vector2 randRange;

	// Use this for initialization

    void Update(){
        randRange = new Vector2(Random.Range(-20, -10), Random.Range(-20, -10));
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
        Instantiate(spawnee, randRange, transform.rotation);
        if(stopSpawning) {
            CancelInvoke("SpawnObject");
        }
    }
}