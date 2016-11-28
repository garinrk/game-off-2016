using UnityEngine;
using System.Collections;
using UnityEditor.Animations;
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
    AnimatorController[] animators;

    [SerializeField]
    Sprite armUpgrade;

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject gunArm;

	[SerializeField]
	GameObject DynamicMusicSystem;

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
		DynamicMusicSystem.GetComponent<DynamicMusicSystem> ().ToggleSynths();
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
                player.GetComponent<Animator>().runtimeAnimatorController = animators[0];
                break;

            case 2:
			SoundManager.instance.play (SoundClip.PlayerSuitEquip);
                gunArm.GetComponent<SpriteRenderer>().sprite = armUpgrade;
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
}
