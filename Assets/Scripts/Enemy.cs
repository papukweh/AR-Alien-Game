using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rigidyBody;
    public float baseSpeed = 0.5f;
    

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
        // transform.rotation = Quaternion.Inverse(player.transform.rotation);
        // transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
        float rand = Random.Range(0.8f, 1.5f);
        Vector3 dir = (player.transform.position - transform.position).normalized;
        transform.Translate(transform.forward * Time.deltaTime * 2 * baseSpeed);
        // rigidyBody.addForce(dir * baseSpeed);

        
    }
    
}
