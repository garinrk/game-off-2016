using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Manager : MonoBehaviour {


    public static Manager instance = null;

    public Vector3 gameGravity = new Vector3(0, -1.0f, 0);

    [SerializeField]
    Sprite[] villianBubbles;

    [SerializeField]
    Sprite[] heroBubbles;

    [SerializeField]
	EnemySpawner spawner1;
	[SerializeField]
	EnemySpawner spawner2;
	[SerializeField]
	EnemySpawner spawner3;
	[SerializeField]
	EnemySpawner spawner4;
	[SerializeField]
	EnemySpawner spawner5;
	[SerializeField]
	EnemySpawner spawner6;

    [SerializeField]
    GameObject consoleMessageObject;
    [SerializeField]
    GameObject hackingTriggerObject;

    [SerializeField]
    GameObject heroChatBubbleObject;

    [SerializeField]
    GameObject villianChatBubbleObject;

    SpriteRenderer hero_renderer;
    SpriteRenderer villian_renderer;

    [SerializeField]
    int currentRound = 0;

    [SerializeField]
    RuntimeAnimatorController[] animators;

    [SerializeField]
    Sprite armUpgrade;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject gunArm;

	[SerializeField]
	GameObject DynamicMusicSystem;

	bool waiting = true;

	[SerializeField]
	Sprite[] backgroundSet1;
	[SerializeField]
	Sprite[] backgroundSet2;
	[SerializeField]
	Sprite[] backgroundSet3;
	[SerializeField]
	GameObject[] backgroundAssets;

    private void Awake()
    {

        //singleton shit
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

       // DontDestroyOnLoad(gameObject);
        
        Physics.gravity = gameGravity;

        hero_renderer = heroChatBubbleObject.GetComponent<SpriteRenderer>();
        villian_renderer = villianChatBubbleObject.GetComponent<SpriteRenderer>();

        hero_renderer.sprite = null;
        villian_renderer.sprite = null;
    }
    // Use this for initialization
    void Start () {
        //SendStartRound();
		DynamicMusicSystem.GetComponent<DynamicMusicSystem> ().ToggleSynths();
    }
	
	// Update is called once per frame
	void Update () {
		
    }

    public void SendStartRound()
    {
        //wow that's ugly as fuck, sorry fam
        if (UIManager.instance.timer.isCountingToRoundStart || UIManager.instance.timer.isCountingToStartRemoval)
            return;
        currentRound++;
		player.GetComponent<PlayerController> ().playerHealth++;
		if (player.GetComponent<PlayerController> ().playerHealth > player.GetComponent<PlayerController> ().maxPlayerHealth) {
			player.GetComponent<PlayerController> ().playerHealth = player.GetComponent<PlayerController> ().maxPlayerHealth;
		}
		ChangeBackGround (player.GetComponent<PlayerController> ().playerHealth);
        UIManager.instance.StartNewRound(currentRound);
        DisplayChatBubbles(currentRound);
    }

    private void SendShake()
    {

        CameraManager.instance.ShakeCamera();

    }

	public void SendSpawnEnemies(){

		switch (currentRound)
		{
		case 1:			
			StartCoroutine (Wave1 ());
			break;

		case 2:			
			StartCoroutine (Wave2 ());
			break;

		case 3:
			StartCoroutine (Wave3 ());
			break;

		case 4:
			StartCoroutine (Wave4 ());
			break;


		case 5:
			StartCoroutine (Wave5());
			break;

		default:
			StartCoroutine (Wave5 ());
			break;
		}
	}

	IEnumerator Wave1(){
		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);
	
		yield return new WaitForSeconds (3.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);
	}


	IEnumerator Wave2(){
	
		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab, spawner1.transform.position, Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab, spawner2.transform.position, Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab, spawner3.transform.position, Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab, spawner4.transform.position, Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab, spawner5.transform.position, Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab, spawner6.transform.position, Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (2.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);
	}

	IEnumerator Wave3(){
		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (2.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);


		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = -1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);
	}

	IEnumerator Wave4(){
		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (2.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);



		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		//Shooters

		yield return new WaitForSeconds (2.0f);


		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = -1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);
	}

	IEnumerator Wave5(){
		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);


		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (2.0f);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.direction = 1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);


		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);


		//Shooter

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (2.0f);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		yield return new WaitForSeconds (3.0f);

		spawner5.enemyPrefab.direction = -1;
		spawner5.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner5.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);


		spawner6.enemyPrefab.direction = -1;
		spawner6.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner6.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);

		spawner1.enemyPrefab.direction = 1;
		spawner1.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner1.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);

		spawner2.enemyPrefab.direction = 1;
		spawner2.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = true;
		spawner2.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.direction = -1;
		spawner3.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner3.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.direction = -1;
		spawner4.enemyPrefab.GetComponent<SpriteRenderer> ().flipX = false;
		spawner4.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);
	}

    public void EndGame()
    {
        Debug.Log("Game Over");
    }


    public void ResetRound()
    {
        //sets hacking message to show again effectively the end of round
        consoleMessageObject.SetActive(true);
        hackingTriggerObject.GetComponent<HackingTrigger>().Reset();
        UpgradePlayer();
		AddMusicLayer ();
    }

	void AddMusicLayer(){
		switch (currentRound)
		{
		case 1:
			DynamicMusicSystem.GetComponent<DynamicMusicSystem> ().ToggleAdvDrums();
			break;

		case 2:
			DynamicMusicSystem.GetComponent<DynamicMusicSystem> ().ToggleBells();
			break;

		case 3:
			DynamicMusicSystem.GetComponent<DynamicMusicSystem> ().ToggleFunkBass();
			break;

		case 4:
			DynamicMusicSystem.GetComponent<DynamicMusicSystem> ().ToggleFunkGuitar();
			break;
		}
	}

    void UpgradePlayer()
    {
        switch (currentRound)
        {
		case 1:
			SoundManager.instance.play (SoundClip.PlayerSuitEquip);
			player.GetComponent<Animator> ().runtimeAnimatorController = animators [0];
            break;

		case 2:
			SoundManager.instance.play (SoundClip.PlayerSuitEquip);
			gunArm.GetComponent<SpriteRenderer> ().sprite = armUpgrade;
            break;

            case 3:
			SoundManager.instance.play (SoundClip.PlayerSuitEquip);
            player.GetComponent<Animator>().runtimeAnimatorController = animators[1];
            break;

            case 4:
			SoundManager.instance.play (SoundClip.PlayerSuitEquip);
            player.GetComponent<Animator>().runtimeAnimatorController = animators[2];
            break;
        }
    }

    public void DisplayChatBubbles(int round)
    {
        if (round < heroBubbles.Length)
        {
            Sprite heroWords = heroBubbles[round - 1];
            hero_renderer.sprite = heroWords;
        }
        if (round < villianBubbles.Length)
        {
            Sprite villianWords = villianBubbles[round - 1];
            villian_renderer.sprite = villianWords;
        }
        StartCoroutine(DissappearChatBubbles());
    }


    IEnumerator DissappearChatBubbles()
    {
        yield return new WaitForSeconds(5);

        hero_renderer.sprite = null;
        villian_renderer.sprite = null;

    }

	public void ChangeBackGround(int playerHealth){
		if (playerHealth == 3) {
			backgroundAssets [0].GetComponent<SpriteRenderer> ().sprite = backgroundSet1 [0];
			backgroundAssets [1].GetComponent<SpriteRenderer> ().sprite = backgroundSet1 [1];
			backgroundAssets [2].GetComponent<SpriteRenderer> ().sprite = backgroundSet1 [2];
			backgroundAssets [3].GetComponent<SpriteRenderer> ().sprite = backgroundSet1 [2];
			backgroundAssets [4].GetComponent<SpriteRenderer> ().sprite = backgroundSet1 [1];
			backgroundAssets [5].GetComponent<SpriteRenderer> ().sprite = backgroundSet1 [3];
			backgroundAssets [6].GetComponent<SpriteRenderer> ().sprite = backgroundSet1 [3];
		} else if (playerHealth == 2) {
			backgroundAssets [0].GetComponent<SpriteRenderer> ().sprite = backgroundSet2 [0];
			backgroundAssets [1].GetComponent<SpriteRenderer> ().sprite = backgroundSet2 [1];
			backgroundAssets [2].GetComponent<SpriteRenderer> ().sprite = backgroundSet2 [2];
			backgroundAssets [3].GetComponent<SpriteRenderer> ().sprite = backgroundSet2 [2];
			backgroundAssets [4].GetComponent<SpriteRenderer> ().sprite = backgroundSet2 [1];
			backgroundAssets [5].GetComponent<SpriteRenderer> ().sprite = backgroundSet2 [3];
			backgroundAssets [6].GetComponent<SpriteRenderer> ().sprite = backgroundSet2 [3];
		} else if (playerHealth == 1) {
			backgroundAssets [0].GetComponent<SpriteRenderer> ().sprite = backgroundSet3 [0];
			backgroundAssets [1].GetComponent<SpriteRenderer> ().sprite = backgroundSet3 [1];
			backgroundAssets [2].GetComponent<SpriteRenderer> ().sprite = backgroundSet3 [2];
			backgroundAssets [3].GetComponent<SpriteRenderer> ().sprite = backgroundSet3 [2];
			backgroundAssets [4].GetComponent<SpriteRenderer> ().sprite = backgroundSet3 [1];
			backgroundAssets [5].GetComponent<SpriteRenderer> ().sprite = backgroundSet3 [3];
			backgroundAssets [6].GetComponent<SpriteRenderer> ().sprite = backgroundSet3 [3];
		}
	}
}
