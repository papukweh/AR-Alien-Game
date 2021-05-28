using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float expireAfter = 10f;

    public GameObject parent;
    void Start()
    {
        Destroy(gameObject, expireAfter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player") {
            col.gameObject.GetComponent<Player>().ReceiveDamage(5.0f);
        }

        if (col.gameObject != parent) {
            Destroy(gameObject);
        }
    }
}
