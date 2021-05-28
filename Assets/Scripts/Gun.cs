using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public GameObject laser;
	public GameObject arCamera;

    void Shoot() {
    	Instantiate(laser, laser.transform.position, Quaternion.identity);
    }

    void Update() {
    	transform.position = arCamera.transform.position;
    	transform.rotation = arCamera.transform.rotation;
    }
}
