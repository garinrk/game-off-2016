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
    private Text roundText;

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

        DontDestroyOnLoad(gameObject);

        //initialization
        timer = roundTimerObject.GetComponent<RoundTimer>();
        roundText = roundTextObject.GetComponent<Text>();


        timer.masterRoundTime = masterRoundTime;
		timer.masterCountdownTimer = masterCountdownTime;
		timer.masterHideStartTime = masterHideStartTime;

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartNewRound(int new_round)
    {
        roundText.text = "Round " + new_round.ToString();
        timer.StartNewRound();
    }

    


}
