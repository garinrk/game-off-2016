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

        DontDestroyOnLoad(gameObject);
        
        Physics.gravity = gameGravity;

        hero_renderer = heroChatBubbleObject.GetComponent<SpriteRenderer>();
        villian_renderer = villianChatBubbleObject.GetComponent<SpriteRenderer>();

        hero_renderer.sprite = null;
        villian_renderer.sprite = null;
    }
    // Use this for initialization
    void Start () {
        //SendStartRound();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp("s"))
            SendStartRound();

    }

    public void SendStartRound()
    {
        //wow that's ugly as fuck, sorry fam
        if (UIManager.instance.timer.isCountingToRoundStart || UIManager.instance.timer.isCountingToStartRemoval)
            return;
        currentRound++;
        UIManager.instance.StartNewRound(currentRound);
        DisplayChatBubbles(currentRound);
    }

    private void SendShake()
    {

        CameraManager.instance.ShakeCamera();

    }

	public void SendSpawnEnemies(){
		spawner1.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner1.enemyPrefab,spawner1.transform.position,Quaternion.identity);
	
		spawner2.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner2.enemyPrefab,spawner2.transform.position,Quaternion.identity);

		spawner3.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner3.enemyPrefab,spawner3.transform.position,Quaternion.identity);

		spawner4.enemyPrefab.enemType = EnemyType.Vanilla;
		Instantiate (spawner4.enemyPrefab,spawner4.transform.position,Quaternion.identity);

		spawner5.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner5.enemyPrefab,spawner5.transform.position,Quaternion.identity);

		spawner6.enemyPrefab.enemType = EnemyType.Shooter;
		Instantiate (spawner6.enemyPrefab,spawner6.transform.position,Quaternion.identity);
	}

    public void EndGame()
    {
        Debug.Log("Game Over");
    }


    public void ResetRound()
    {
        consoleMessageObject.SetActive(true);
        hackingTriggerObject.GetComponent<HackingTrigger>().Reset();
    }

    public void DisplayChatBubbles(int round)
    {
        Sprite heroWords = heroBubbles[round - 1];
        Sprite villianWords = villianBubbles[round - 1];

        hero_renderer.sprite = heroWords;
        villian_renderer.sprite = villianWords;

        StartCoroutine(DissappearChatBubbles());
    }


    IEnumerator DissappearChatBubbles()
    {
        yield return new WaitForSeconds(5);

        hero_renderer.sprite = null;
        villian_renderer.sprite = null;

    }
}
