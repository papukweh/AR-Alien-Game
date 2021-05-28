using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{

	public GameObject arCamera;
    public GameObject smoke;
    public GameObject spawn;

    void Start(){
        spawn = GameObject.FindWithTag("Player");
    }

    public void Shoot(int enemiesCount)
    {
        RaycastHit hit;

        if(Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit)) {
        	if (hit.transform.gameObject.tag == "Enemy") {
        		Destroy(hit.transform.gameObject);
                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
                spawn.GetComponent<Spawn>().OnEnemyKilled();

                
        	}
        }
    }
}
