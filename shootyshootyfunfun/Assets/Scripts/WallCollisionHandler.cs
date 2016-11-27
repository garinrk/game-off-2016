using UnityEngine;
using System.Collections;

public class WallCollisionHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{

		if (collider.gameObject.GetComponent<EnemyCreation>() != null) {

			collider.gameObject.layer = 8;
		}
	}

}
