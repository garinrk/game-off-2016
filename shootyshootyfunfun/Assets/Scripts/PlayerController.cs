using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeedHorizontal = 1f;
	public float playerSpeedVertical = 1f;
	Vector3 left;
	Vector3 right;
	Vector3 up;
	Vector3 lookDirection = Vector3.zero;
	public Animator playerAnimator;
	public Animation playerAnimation;
	public float maxDownTime =1;
	Animator meleeAnimator;
	bool isMoving;
	Rigidbody rb;

	[SerializeField]
	float downScale;

	[SerializeField]
	GameObject melee;

	[SerializeField]
	GameObject gunArm;

	[SerializeField]
	float meleeSleep;

	bool isMeleeReady;
	int playerHealth = 3;
	BoxCollider meleeColider;

	void Awake(){
		rb = GetComponent<Rigidbody> ();
		melee.SetActive (false);
		meleeAnimator = melee.GetComponent<Animator> ();
		meleeColider = melee.GetComponent<BoxCollider> ();
		meleeColider.enabled = false;
	}
	// Use this for initialization
	void Start () { 
		left = new Vector3 (-playerSpeedHorizontal, 0f, 0f);
		right = new Vector3 (playerSpeedHorizontal, 0f, 0f);
		up = new Vector3 (0f, playerSpeedVertical, 0f);
		playerAnimator = GetComponent<Animator> ();
		playerAnimation = GetComponent<Animation> ();
		isMoving = false;
		isMeleeReady = true;
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
		if(Input.GetButtonDown("Fire2") && isMeleeReady){
			meleeColider.enabled = true;
			SoundManager.instance.play (SoundClip.PlayerMelee);
			isMeleeReady = false;
			gunArm.SetActive (false);
			CameraManager.instance.ShakeCamera(0.08f,0.1f);
			melee.SetActive(true);
			meleeAnimator.Play("Melee");
			StartCoroutine (WaitForAnimation ());
		}
		if(!isMoving){			
			playerAnimator.Play ("Idle");
		}
	}

	void OnCollisionEnter(Collision collision){		
		if (collision.transform.tag == "Enemy") {
			playerHealth--;
			SoundManager.instance.play (SoundClip.PlayerHurt);
			print (playerHealth);
			if (playerHealth < 0) {
				//Game over
			}
		}
	}

	IEnumerator WaitForAnimation(){
		yield return new WaitForSeconds (0.5f);
		melee.SetActive(false);
		gunArm.SetActive (true);
		meleeColider.enabled = false;
		yield return new WaitForSeconds (meleeSleep);
		isMeleeReady = true;
	}
}
