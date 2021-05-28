using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject laser;
	public GameObject arCamera;
	private AudioSource audioSource;

	void Start() {
		audioSource = GetComponent<AudioSource> ();
	}

    void Shoot() {
        audioSource.Play();
    	Instantiate(laser, laser.transform.position, arCamera.transform.rotation);
    }

    void Update() {
    	transform.position = arCamera.transform.position;
    	transform.rotation = arCamera.transform.rotation;
    }
}
