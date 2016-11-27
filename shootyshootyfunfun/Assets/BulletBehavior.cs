using UnityEngine;
using System.Collections;

public class BulletBehavior : MonoBehaviour {

	public float direction;
	public float speed;


	// Use this for initialization
	void Start () {
	
		if (direction > 0.0f) {
			transform.localScale = new Vector3 (gameObject.transform.localScale.x,gameObject.transform.localScale.y,gameObject.transform.localScale.z);
		}
		else if(direction < 0.0f){
			transform.localScale = new Vector3 (-gameObject.transform.localScale.x,gameObject.transform.localScale.y,gameObject.transform.localScale.z);
		}


	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * direction, 0.0f, 0.0f) * Time.deltaTime;
	}


	//Check collision events
	void OnCollisionEnter(Collision collision)
	{
		//Do not collide with the enemy
		if(collision.gameObject.layer != 8)
			Destroy (gameObject);
	}


}
