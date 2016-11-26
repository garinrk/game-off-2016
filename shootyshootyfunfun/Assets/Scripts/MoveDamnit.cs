﻿using UnityEngine;
using System.Collections;

public class MoveDamnit : MonoBehaviour {

	public float playerSpeedHorizontal = 1f;
	public float playerSpeedVertical = 1f;
	public GameObject bullet;
	Vector3 left;
	Vector3 right;
	Vector3 up;
	Vector3 lookDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
		left = new Vector3 (-playerSpeedHorizontal, 0f, 0f);
		right = new Vector3 (playerSpeedHorizontal, 0f, 0f);
		up = new Vector3 (0f, playerSpeedVertical, 0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		if(Input.GetKeyDown("w")){
			transform.Translate(up);
		}
		if(Input.GetKey("a")){
			transform.Translate(left);
		}
		if(Input.GetKey("d")){
			transform.Translate(right);
		}
		if(Input.GetButtonDown("Fire1")){
			ShootyShooot ();
		}
	}

	void ShootyShooot (){
		GameObject spawnedBullet = (GameObject)Instantiate (bullet, transform.transform.position, transform.rotation);
		spawnedBullet.GetComponent<ShootDamnit> ().direction = lookDirection;
	}
}
