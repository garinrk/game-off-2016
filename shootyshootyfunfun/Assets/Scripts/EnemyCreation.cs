using UnityEngine;
using System.Collections;

public enum EnemyType{
	Vanilla,
	BigVanilla,
	BounceBack,
	Shooter
};

public class Enemy{

	//The member variables of enemy

	public int healthPoints;
	public float speed;
	private bool angry;
	public bool collided = false;
	private Vector3 spawnPosition = Vector3.zero;
	public bool changedDirection = false;
	public bool hasWeapon = false;
	public GameObject targetObject;


	public EnemyType enemType;

	//The empty constructor
	public Enemy(){
	}


	//The enemy constructor
	public Enemy(int p_healthPoints, float p_speed, bool p_angry, EnemyType p_type,  Vector3 p_spawnPosition, bool p_hasWeapon){
		this.healthPoints = p_healthPoints;
		this.speed = p_speed;
		this.angry = p_angry;
		this.enemType = p_type;
		this.spawnPosition = p_spawnPosition;
		this.hasWeapon = p_hasWeapon;
	}


	//Spawn methods for the different enemy types
	public Enemy SpawnEnemyVanilla(){
		Enemy enemy = new Enemy (1,5.0f,false,EnemyType.Vanilla,Vector3.zero,false);
		return enemy;
	}

	public Enemy SpawnEnemyBigVanilla(){
		Enemy enemy = new Enemy (200,3.0f,false,EnemyType.BigVanilla,Vector3.zero,false);
		return enemy;
	}

	public Enemy SpawnEnemyBounceBack(){
		Enemy enemy = new Enemy (100,10.0f,false,EnemyType.BounceBack,Vector3.zero,false);
		return enemy;
	}

	public Enemy SpawnEnemyShooter(){
		Enemy enemy = new Enemy (3,5.0f,false,EnemyType.Shooter,Vector3.zero,true);
		return enemy;
	}

}


public class EnemyCreation : MonoBehaviour {


	private Enemy enemy;
	public EnemyType enemType;
	public AnimatorOverrideController animatorControllerVanilla;
	public AnimatorOverrideController animatorControllerShooter;
	public Animator monsterAnimator; // the default is the monster shooter controller
	public int direction = 1;

	Vector3 up;
	Rigidbody rb;

	//For the bounce back enemy
	float dirX = 1.0f;
	float dirY = 1.0f;



	//The enemy sprites
	[SerializeField]
	Sprite enemyVanillaSprite;
	[SerializeField]
	Sprite enemyBigVanillaSprite;
	[SerializeField]
	Sprite enemyBounceBackSprite;

	[SerializeField]
	GameObject enemyBullet;

	public float fireRate;
	private float currentTime = 0.0f;





	//The enemy movement function for the different enemy types
	private void EnemyMovement(){
		
		if (enemy.changedDirection) {
			dirX = randomDirection ();
			dirY = randomDirection ();
			enemy.changedDirection = false;
		}


		if (enemType == EnemyType.Vanilla) {

			if(!enemy.collided)
				this.transform.position += new Vector3 (direction * enemy.speed, 0.0f,0.0f) * Time.deltaTime;
			else
				this.transform.position += new Vector3 (direction *-enemy.speed, 0.0f,0.0f)* Time.deltaTime;

		} else if (enemType == EnemyType.BigVanilla) {
			if(!enemy.collided)
				this.transform.position += new Vector3 (direction *enemy.speed/1.5f, 0.0f,0.0f)* Time.deltaTime;
			else
				this.transform.position += new Vector3 (direction *-enemy.speed/1.5f, 0.0f,0.0f)* Time.deltaTime;


		} else if (enemType == EnemyType.BounceBack) {
			if (!enemy.collided) {
				this.transform.position += new Vector3 (dirX * (enemy.speed / 1.5f), dirY * (enemy.speed / 1.5f), 0.0f) * Time.deltaTime;
			} else {
				this.transform.position += new Vector3 (-dirX * (enemy.speed / 1.5f), -dirY * (enemy.speed / 1.5f), 0.0f) * Time.deltaTime;
			}

		
		}else if(enemType == EnemyType.Shooter){
			if(!enemy.collided)
				this.transform.position += new Vector3 (direction *enemy.speed, 0.0f,0.0f) * Time.deltaTime;
			else
				this.transform.position += new Vector3 (direction *-enemy.speed, 0.0f,0.0f)* Time.deltaTime;
		}
	}

	private float randomDirection(){
		float[] choices = new float[] {-1.0f,1.0f};
		int choice = Random.Range (0,choices.Length);
		float direction = choices[choice];
		return direction;
	}


	private void ShootWeapon(){

		currentTime += Time.deltaTime;

		if (currentTime > fireRate) {

			if (enemy.hasWeapon) {


				float direction = 0.0f;
				if (gameObject.transform.localScale.x > 0.0f) {
					direction = 1.0f;
				}
				else if (gameObject.transform.localScale.x < 0.0f){
					direction = -1.0f;
				}
				enemyBullet.GetComponent<BulletBehavior> ().direction = direction; 
				Instantiate (enemyBullet, gameObject.transform.position, new Quaternion(0.0f,0.0f,0.0f,0.0f));

			}
	
			currentTime = 0.0f;
		}
	}

	private void Jump(){
		rb.AddForce(up* 200.0f);
	}

	// Use this for initialization
	void Awake () {
		

		enemy = new Enemy();
		rb = GetComponent<Rigidbody> ();


		gameObject.GetComponent<SpriteRenderer> ().sprite = enemyVanillaSprite;

		//Pick the right enemy
		if (enemType == EnemyType.Vanilla) {
			monsterAnimator.runtimeAnimatorController = animatorControllerVanilla;
			enemy = enemy.SpawnEnemyVanilla ();
		}
		else if(enemType == EnemyType.BigVanilla){
			enemy = enemy.SpawnEnemyBigVanilla ();
		}else if(enemType == EnemyType.BounceBack){
			gameObject.GetComponent<Rigidbody> ().useGravity = false;
			enemy = enemy.SpawnEnemyBounceBack ();
		}
		else if(enemType == EnemyType.Shooter){
			monsterAnimator.runtimeAnimatorController = animatorControllerShooter;
			enemy = enemy.SpawnEnemyShooter ();
		}

		up = new Vector3 (0f, enemy.speed, 0f);
	}

	// Update is called once per frame
	void Update () {
		EnemyMovement ();
		ShootWeapon ();
	}

	//Check collision events
	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Wall") {

			enemy.collided = !enemy.collided;
			gameObject.transform.localScale = new Vector3 (-gameObject.transform.localScale.x,gameObject.transform.localScale.y,gameObject.transform.localScale.z);

		}

		if (enemType == EnemyType.BounceBack) {
			enemy.collided = !enemy.collided;
			enemy.changedDirection = !enemy.changedDirection;
			gameObject.transform.localScale = new Vector3 (-gameObject.transform.localScale.x,gameObject.transform.localScale.y,gameObject.transform.localScale.z);
		} 
			


	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.transform.tag == "Bullet") {
			SoundManager.instance.play (SoundClip.EnemyDeath);
			enemy.healthPoints--;

			if (enemy.healthPoints <= 0) {
				Destroy (gameObject);
			}
		}

		if (collider.transform.tag == "Launcher") {

			if(PlayerController.getInstance().transform.position.y > gameObject.transform.position.y)
			Jump ();
		}

	}




}
