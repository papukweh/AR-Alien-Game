using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawn : MonoBehaviour
{

	public Transform spawnPoint;
	public GameObject[] enemies;
    public GameObject player;

    public Text waveLabel;
    public int enemiesCount;
    

    public int waveIndex = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave(100, 3, enemies, 5, 10));
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
    
    public void OnEnemyKilled() {
        enemiesCount -= 1;
        Debug.Log("Enemy killed!");
        if(enemiesCount == 0){
            StartWave(50, 2, enemies, 4, 7);
        }
    }

    IEnumerator StartWave(int _enemiesCount, float interval, GameObject[] enemies, float minRadius, float maxRadius) {
    	
        enemiesCount = _enemiesCount;
        waveLabel.text = "Wave " + waveIndex.ToString();
        waveIndex++;

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
