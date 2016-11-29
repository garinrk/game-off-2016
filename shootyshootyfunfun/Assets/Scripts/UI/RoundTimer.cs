using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RoundTimer : MonoBehaviour {
    [HideInInspector]
	public float masterCountdownTimer = 3.0f;
    private float countdownTime;

	[HideInInspector]
    public float masterHideStartTime = 2.0f;
    private float hideStartTime;

    [HideInInspector]
    public float masterRoundTime = 666.0f;
    private float currentElapsedRoundTime = 0.0f;

    private Text countdownTextOnScreen;

    [HideInInspector]
    public bool isCountingToRoundStart = false;
    [HideInInspector]
    public bool isCountingToStartRemoval = false;


    [SerializeField]
    public Slider progressBar;

    public float roundOneTime = 10.0f;
    public float roundTwoTime = 10.0f;
    public float roundThreeTime = 10.0f;
    public float roundFourTime = 10.0f;
    public float roundFiveTime = 10.0f;

    float armor_1delta = 0.1f;
    float armor_2delta = 0.275f;
    float armor_3delta = 0.27f;
    float armor_4delta = 0.244f;
    float armor_5delta = 0.1f;

    public Color completedMarkerColor;

    public GameObject[] markerObjects;

    private bool inRound = false;

    int current_round;


    void Awake()
    {

        if(countdownTextOnScreen == null)
        {
            countdownTextOnScreen = GetComponent(typeof(Text)) as Text;
        }
    
        //initial countdown states
        countdownTime = masterCountdownTimer;
        hideStartTime = masterHideStartTime;

    }

 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        
	}

	void FixedUpdate(){

		RoundTimeUpdate ();
		CountdownUpdate();
		StartRemovalCountdownUpdate();
	}

    public void StartNewRound()
    {
        if (current_round == 5)
            Manager.instance.EndGame();
        current_round++;
        isCountingToRoundStart = true;
        switch (current_round)
        {
            case 1:
                masterRoundTime = roundOneTime;
                break;
            case 2:
                masterRoundTime = roundTwoTime;
                break;
            case 3:
                masterRoundTime = roundThreeTime;
                break;
            case 4:
                masterRoundTime = roundFourTime;
                break;
            case 5:
                masterRoundTime = roundFiveTime;
                break;
        }

        countdownTime = masterCountdownTimer;
    }

	void RoundTimeUpdate(){
		if (inRound) {
			
			if (currentElapsedRoundTime >= masterRoundTime) {
				inRound = false;
				currentElapsedRoundTime = 0.0f;
				//countdownTextOnScreen.text = "Round " + Manager.instance.currentRound + " OVER!";
                SetMarkerComplete(current_round);
                Manager.instance.ResetRound();
				return;
			} else {
				currentElapsedRoundTime += Time.deltaTime;
				//countdownTextOnScreen.text = "Time Left: " + (masterRoundTime - currentElapsedRoundTime).ToString ();
                SetSliderValue();
			}
		} else {

		}
			
	}

    void SetSliderValue()
    {
        float val;
        switch (current_round)
        {
            case 1:
                val = (currentElapsedRoundTime / roundOneTime) * armor_1delta;
                progressBar.value = val;
                break;
            case 2:
                val = (currentElapsedRoundTime / roundTwoTime) * armor_2delta + armor_1delta;
                progressBar.value = val;
                break;
            case 3:
                val = (currentElapsedRoundTime / roundThreeTime) * armor_3delta + armor_2delta + armor_1delta;
                progressBar.value = val;
                break;
            case 4:
                val = (currentElapsedRoundTime / roundFourTime) * armor_4delta + armor_3delta + armor_2delta + armor_1delta;
                progressBar.value = val;
                break;
            case 5:
                val = (currentElapsedRoundTime / roundFiveTime) * armor_5delta + armor_4delta + armor_3delta + armor_2delta + armor_1delta;
                progressBar.value = val;
                break;
        }
    }

    void SetMarkerComplete(int roundToSet)
    {
        if (roundToSet >= 5)
            return;

        GameObject marker = markerObjects[roundToSet - 1];
               
        Color c = marker.GetComponent<Image>().color;
        c = completedMarkerColor;
        marker.GetComponent<Image>().color = c;
    }

    #region CountdownFunctions

    private void StartRemovalCountdownUpdate()
    {
        if (isCountingToStartRemoval)
        {
            hideStartTime -= Time.deltaTime;
        }

        if (isCountingToStartRemoval && hideStartTime <= 0)
        {
            isCountingToStartRemoval = !isCountingToStartRemoval;
            countdownTextOnScreen.text = "";
            hideStartTime = masterHideStartTime;
			inRound = true;
			SendSpawnEnemies ();
        }
    }

    void CountdownUpdate()
    {
        if (isCountingToRoundStart)
        {
            countdownTime -= Time.deltaTime;
			int timer = (int)countdownTime;
			countdownTextOnScreen.text = timer.ToString();
        }
        if (isCountingToRoundStart && countdownTime <= 0)
        {
            isCountingToRoundStart = !isCountingToRoundStart;
            countdownTextOnScreen.text = "START";

            isCountingToStartRemoval = true;
        }
    }

	void SendSpawnEnemies(){
		Manager.instance.SendSpawnEnemies ();
	}

    #endregion
}
