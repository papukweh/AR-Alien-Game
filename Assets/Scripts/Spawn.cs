using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

	public Transform spawnPoint;
	public GameObject[] enemies;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave(10, 5, enemies, 9, 12));
    }

    void SpawnEnemy(GameObject enemy, float angle, float radius) {

        // Sets the radial offset
        Vector3 offset = Quaternion.AngleAxis(angle, Vector3.up) * player.transform.forward * radius;
        // Sets the vertical offset based on screen size
        float screen_height = Screen.height/50;
        offset.y = Random.Range(-screen_height, screen_height);

        spawnPoint.position = player.transform.position + offset;

    	Instantiate(enemy, spawnPoint.position, Quaternion.identity);
    }

    IEnumerator StartWave(int enemiesCount, float interval, GameObject[] enemies, float minRadius, float maxRadius) {
    	
        for (int i = 0; i < enemiesCount; i++) {
            yield return new WaitForSeconds(interval);
            float radius = Random.Range(minRadius, maxRadius);
            float angle = Random.Range(0, 360);
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];

            SpawnEnemy(enemy, angle, radius);

        }
        

        // yield return new WaitForSeconds(enemiesCount * interval + 10);

    }
}
