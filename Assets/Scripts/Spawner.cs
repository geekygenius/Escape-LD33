using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public float spawnTime;
	public GameObject zombie;
	public float spawnRadius = 2;

	void Start () {
		InvokeRepeating ("Spawn", 0,spawnTime);
	}

	void Spawn(){
		if (GetComponent<Place>() == null)
			Instantiate (zombie, transform.position + new Vector3(Random.Range(-spawnRadius,spawnRadius),0,Random.Range(-spawnRadius,spawnRadius)), Quaternion.identity);
	}
}
