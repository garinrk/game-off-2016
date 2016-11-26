using UnityEngine;
using System.Collections;

public class Enemy{

	//The member variables of enemy

	private int healthPoints;
	public float speed;
	private bool angry;
	public bool collided = false;
	private Vector3 spawnPosition = Vector3.zero;


	public enum EnemyType{
		Vanilla,
		BigVanilla,
		BounceBack
	};

	public EnemyType enemType;

	//The empty constructor
	public Enemy(){
	}


	//The enemy constructor
	public Enemy(int p_healthPoints, float p_speed, bool p_angry, EnemyType p_type,  Vector3 p_spawnPosition){
		this.healthPoints = p_healthPoints;
		this.speed = p_speed;
		this.angry = p_angry;
		this.enemType = p_type;
		this.spawnPosition = p_spawnPosition;
	}


	//Spawn methods for the different enemy types
	public Enemy SpawnEnemyVanilla(){
		Enemy enemy = new Enemy (100,5.0f,false,EnemyType.Vanilla,Vector3.zero);
		return enemy;
	}

	public Enemy SpawnEnemyBigVanilla(){
		Enemy enemy = new Enemy (200,3.0f,false,EnemyType.BigVanilla,Vector3.zero);
		return enemy;
	}

	public Enemy SpawnEnemyBounceBack(){
		Enemy enemy = new Enemy (100,10.0f,false,EnemyType.BounceBack,Vector3.zero);
		return enemy;
	}





}




public class EnemyCreation : MonoBehaviour {


	private Enemy enemy;
	public string enemyType;


	//The enemy sprites
	[SerializeField]
	Sprite enemyVanillaSprite;
	[SerializeField]
	Sprite enemyBigVanillaSprite;
	[SerializeField]
	Sprite enemyBounceBackSprite;



	//The enemy movement function for the different enemy types
	private void EnemyMovement(){

		if (enemy.enemType == Enemy.EnemyType.Vanilla) {

			if(!enemy.collided)
				this.transform.position += new Vector3 (enemy.speed, 0.0f,0.0f) * Time.deltaTime;
			else
				this.transform.position += new Vector3 (-enemy.speed, 0.0f,0.0f)* Time.deltaTime;

		} else if (enemy.enemType == Enemy.EnemyType.BigVanilla) {
			if(!enemy.collided)
				this.transform.position += new Vector3 (enemy.speed/1.5f, 0.0f,0.0f)* Time.deltaTime;
			else
				this.transform.position += new Vector3 (-enemy.speed/1.5f, 0.0f,0.0f)* Time.deltaTime;
		} else if (enemy.enemType == Enemy.EnemyType.BounceBack) {
			if(!enemy.collided)
				this.transform.position += new Vector3 (enemy.speed/1.5f, enemy.speed/1.5f,0.0f)* Time.deltaTime;
			else
				this.transform.position += new Vector3 (-enemy.speed/1.5f,-enemy.speed/1.5f,0.0f)* Time.deltaTime;
		}



	}





	// Use this for initialization
	void Awake () {
		enemy = new Enemy();
		gameObject.AddComponent<Rigidbody> ();
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePositionZ;
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		gameObject.GetComponent<SpriteRenderer> ().sprite = enemyVanillaSprite;
		gameObject.AddComponent<BoxCollider> ();

		//Pick the right enemy
		if (enemyType.Equals("Vanilla")) {
			enemy = enemy.SpawnEnemyVanilla ();
		}
		else if(enemyType.Equals("BigVanilla")){
			enemy = enemy.SpawnEnemyBigVanilla ();
		}else if(enemyType.Equals("BounceBack")){
			enemy = enemy.SpawnEnemyBounceBack ();
		}



	}

	// Update is called once per frame
	void Update () {
		EnemyMovement ();
	}


	//Check collision events
	void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Wall") {

			enemy.collided = !enemy.collided;
			gameObject.transform.localScale = new Vector3 (-gameObject.transform.localScale.x,gameObject.transform.localScale.y,gameObject.transform.localScale.z);

		}

		if (collision.transform.tag == "Bullet") {

			Destroy (gameObject);

		}


	}






}
