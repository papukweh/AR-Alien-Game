using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rigidyBody;
    public float baseSpeed = 0.5f;
    
    public GameObject bullet;
    public GameObject[] muzzles;
    public float shootRate = 1.0f;
    public float shootForce = 1.0f;
    private float shootRateTimestamp = 5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        // rigidyBody = GameObject.GetComponent("Rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform, transform.up);
        float rand = Random.Range(0.8f, 1.5f);
        Vector3 dir = (player.transform.position - transform.position).normalized;
        transform.Translate(transform.forward * Time.deltaTime * 2 * baseSpeed);

        if (Time.time > shootRateTimestamp) {
            Shoot();
        }
    }


    void Shoot()
    {   
        for (int i = 0; i < muzzles.Length; i++) {
            GameObject muzzle = muzzles[i];
            GameObject bulletObj = (GameObject)Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            bulletObj.GetComponent<EnemyBullet>().parent = gameObject;
            bulletObj.GetComponent<Rigidbody>().AddForce(muzzle.transform.forward * shootForce);
            shootRateTimestamp = Time.time + shootRate; 
        }

    }
    
}