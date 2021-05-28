using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject laser;
	public GameObject arCamera;
	private AudioSource audioSource;
	private GameObject laserInst;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

    void Shoot() {
        audioSource.Play();
    	laserInst = Instantiate(laser, laser.transform.position, arCamera.transform.rotation);
    	laserInst.SetActive(true);
    }

    void Update() {
    	transform.position = arCamera.transform.position;
    	transform.rotation = arCamera.transform.rotation;
    }
}
