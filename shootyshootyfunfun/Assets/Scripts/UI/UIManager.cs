using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    //gameobject references to get around finds
    public GameObject roundTimerObject;
    public GameObject mainCameraObject;
    public GameObject roundTextObject;
    
    public float masterRoundTime;
    public float masterCountdownTime;
	public float masterHideStartTime;

    [HideInInspector]
    public RoundTimer timer;
    
    [SerializeField]
    float fadeFactor = 2f;

    CanvasGroup cg;
    //private Text roundText;

    public static UIManager instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        //DontDestroyOnLoad(gameObject);

        //initialization
        timer = roundTimerObject.GetComponent<RoundTimer>();
        cg = gameObject.GetComponent<CanvasGroup>();

        cg.alpha = 1f;
        //roundText = roundTextObject.GetComponent<Text>();


        timer.masterRoundTime = masterRoundTime;
		timer.masterCountdownTimer = masterCountdownTime;
		timer.masterHideStartTime = masterHideStartTime;

    }

    // Use this for initialization
    void Start () {
        StartCoroutine(FadeIn());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartNewRound(int new_round)
    {
        //roundText.text = "Round " + new_round.ToString();
        timer.StartNewRound();
    }

    public IEnumerator FadeOut()
    {

        while(cg.alpha < 1)
        {
            cg.alpha += Time.deltaTime / fadeFactor;
            yield return null;
        }
        Manager.instance.EndGame();

    }

    IEnumerator FadeIn()
    {

        while(cg.alpha > 0)
        {
            cg.alpha -= Time.deltaTime / fadeFactor;
            yield return null;
        }
    }

    


}
