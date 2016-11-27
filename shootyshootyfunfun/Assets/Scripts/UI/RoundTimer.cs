using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class RoundTimer : MonoBehaviour {
    
    public float MasterCountdownTimer = 5.0f;
    private float countdownTime;

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


    void Awake()
    {

        if(countdownTextOnScreen == null)
        {
            countdownTextOnScreen = GetComponent(typeof(Text)) as Text;
        }
    
        //initial countdown states
        countdownTime = MasterCountdownTimer;
        hideStartTime = masterHideStartTime;

    }

 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        CountdownUpdate();

        StartRemovalCountdownUpdate();
        
	}

    public void StartNewRound()
    {
        isCountingToRoundStart = true;
        countdownTime = MasterCountdownTimer;
        currentElapsedRoundTime = 0.0f;
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

    #endregion
}
