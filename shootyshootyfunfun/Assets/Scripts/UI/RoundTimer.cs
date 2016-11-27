using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RoundTimer : MonoBehaviour {
    [HideInInspector]
	public float masterCountdownTimer = 5.0f;
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

	private bool inRound = false;


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
        isCountingToRoundStart = true;
        countdownTime = masterCountdownTimer;

    }

	void RoundTimeUpdate(){
		if (inRound) {
			
			if (currentElapsedRoundTime >= masterRoundTime) {
				inRound = false;
				currentElapsedRoundTime = 0.0f;
				countdownTextOnScreen.text = "Round " + Manager.instance.currentRound + " OVER!";
				return;
			} else {
				currentElapsedRoundTime += Time.deltaTime;
				countdownTextOnScreen.text = "Time Left: " + (masterRoundTime - currentElapsedRoundTime).ToString ();
			}
		} else {

		}
			
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
            countdownTextOnScreen.text = countdownTime.ToString();
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
