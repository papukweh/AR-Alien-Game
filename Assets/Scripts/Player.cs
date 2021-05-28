using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hp = 100.0f;

    public GameObject hpBar;
    // Start is called before the first frame update

    public GameObject damageScreen;
    public GameObject gameOverScreen;
    void Start()
    {
        // gameOverScreen.enabled = false;
        // damageScreen.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceiveDamage(float damage)
    {
        hp -= damage;
        hpBar.GetComponent<Slider>().value = hp;
        damageScreen.SetActive(true);
        StartCoroutine(HideDamage());
        if (hp <= 0f) {
            Die();
        }
    }

    IEnumerator HideDamage()
    {
        yield return new WaitForSeconds(1);
        damageScreen.SetActive(false);

    }

    void Die() {
        gameOverScreen.SetActive(true);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy") {
            ReceiveDamage(10.0f);
        }

        Destroy(col.gameObject);
    }
}
