﻿using UnityEngine;
using System.Collections;

public class Gunzo : MonoBehaviour {

<<<<<<< HEAD
	// Use this for initialization
	void Start () {
	
=======
	public GameObject gun;
	public GameObject bullet;
	public float shootDelay;
	bool readyToShoot;

	// Use this for initialization
	void Start () {
		readyToShoot = true;
>>>>>>> refs/remotes/origin/bharat
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		
=======
		Vector3 mousePosition = getMouseDirection();
		float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
		if(Input.GetButton("Fire1") && readyToShoot){			
			ShootyShooot ();
			readyToShoot = false;
			StartCoroutine (GunDelay());
		}
	}

	void ShootyShooot (){
		GameObject spawnedBullet = (GameObject)Instantiate (bullet, gun.transform.position, Quaternion.Euler(Vector3.zero));
		spawnedBullet.GetComponent<ShootDamnit> ().direction = getMouseDirection().normalized;
	}

	Vector3 getMouseDirection(){
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0f;
		Vector3 gunPos = transform.position;
		mousePosition.x = mousePosition.x - gunPos.x;
		mousePosition.y = mousePosition.y - gunPos.y;
		return mousePosition;
	}

	IEnumerator GunDelay(){
		yield return new WaitForSeconds (shootDelay);
		readyToShoot = true;
>>>>>>> refs/remotes/origin/bharat
	}
}
