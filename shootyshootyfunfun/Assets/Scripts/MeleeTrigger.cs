using UnityEngine;
using System.Collections;

public class MeleeTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collision)
	{
		print ("meleetriggered "+collision.gameObject.tag);
		if (collision.gameObject.tag == "Enemy") {
			Destroy (collision.gameObject);
		}
	}
}
