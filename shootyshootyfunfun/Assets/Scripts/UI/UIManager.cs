using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

    public GameObject roundTimerObject;
    public GameObject mainCameraObject;

    public float masterRoundTime;
    public float masterCountdownTime;

    private RoundTimer rt;

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
        rt = roundTimerObject.GetComponent<RoundTimer>();
        rt.roundTime = masterRoundTime;
        rt.countdownTime = masterCountdownTime;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void StartNewRound()
    {
        rt.StartNewRound();
    }


}
