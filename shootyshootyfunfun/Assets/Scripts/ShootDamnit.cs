﻿using UnityEngine;
using System.Collections;

public class ShootDamnit : MonoBehaviour {
	public float bulletSpeed;
	public float bulletSize;
	public Vector3 direction;

	// Use this for initialization
	void Start () {		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (direction * bulletSpeed*Time.deltaTime);
	}
}
