using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float hp = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(float damage)
    {
        hp -= damage;
        Debug.Log(hp);
        if (hp <= 0f) {
            Die();
        }
    }

    void Die() {

    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Destroying...");
        Destroy(col.gameObject);
    }
}
