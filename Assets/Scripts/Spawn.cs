using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

	public Transform spawnPoint;
	public GameObject balloon;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn() {

    	yield return new WaitForSeconds(2);

    	Instantiate(balloon, spawnPoint.position, Quaternion.identity);
    	StartCoroutine(StartSpawn());
    }
}
