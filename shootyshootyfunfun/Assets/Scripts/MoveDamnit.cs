using UnityEngine;
using System.Collections;

public class MoveDamnit : MonoBehaviour {

	public float playerSpeedHorizontal = 1f;
	public float playerSpeedVertical = 1f;
	Vector3 left;
	Vector3 right;
	Vector3 up;
	Vector3 lookDirection = Vector3.zero;
	public Animator playerAnimator;
	public Animation playerAnimation;
	public float maxDownTime =1;
	bool jump;
	bool grounded = true;

	bool isMoving;
	Rigidbody rb;

	[SerializeField]
	float downScale;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
	}
	// Use this for initialization
	void Start () { 
		left = new Vector3 (-playerSpeedHorizontal, 0f, 0f);
		right = new Vector3 (playerSpeedHorizontal, 0f, 0f);
		up = new Vector3 (0f, playerSpeedVertical, 0f);
		playerAnimator = GetComponent<Animator> ();
		playerAnimation = GetComponent<Animation> ();
		isMoving = false;
		jump = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		if (Input.GetKey("w")) {


				rb.MovePosition (rb.position + up * Time.deltaTime);


		}
		if(Input.GetKey("a")){			
			playerAnimator.Play ("Move");
			isMoving = true;
			rb.MovePosition (rb.position + left * Time.deltaTime);
		}else if(Input.GetKey("d")){			
			playerAnimator.Play ("Move");
			rb.MovePosition (rb.position + right * Time.deltaTime);
			isMoving = true;
		}else{
			isMoving = false;
		}
		if(!isMoving){			
			playerAnimator.Play ("Idle");
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.transform.tag == "Platform") {		
			//rb.MovePosition (rb.position - up * Time.deltaTime*2);
		}
	}
}
