using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoundTimer : MonoBehaviour {

    [HideInInspector]
    public float countdownTime = 5.0f;
    [HideInInspector]
    public float roundTime = 666.0f;

    private float hideStartTime = 2.0f;

    private Text textOnScreen;

    private bool countingDown = false;
    private bool removeStartTimer = false;


    void Awake()
    {

        if(textOnScreen == null)
        {
            textOnScreen = GetComponent(typeof(Text)) as Text;
        }

    }

 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        if (countingDown)
        {
            countdownTime -= Time.deltaTime;
            textOnScreen.text = countdownTime.ToString();
        }
        if(countingDown && countdownTime <= 0)
        {
            countingDown = !countingDown;
            textOnScreen.text = "START";

            removeStartTimer = true;
        }

        if (removeStartTimer)
        {
            hideStartTime -= Time.deltaTime;
        }

        if(removeStartTimer && hideStartTime <= 0)
        {
            removeStartTimer = !removeStartTimer;
            textOnScreen.text = "";
        }
        //Debug.Log(countdownTime.ToString());
	
	}

    public void StartNewRound()
    {
        countingDown = true;
    }
}
