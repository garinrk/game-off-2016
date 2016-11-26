using UnityEngine;
using System.Collections;
using System;

public class Manager : MonoBehaviour {
    
    public Vector3 gameGravity = new Vector3(0, -1.0f, 0);

    public float masterRoundTime = 30.0f;
    public float masterCountdownTime = 5.0f;

    public GameObject RoundTimerObject;
    public GameObject CameraObject;
    private RoundTimer rt;
    private ShakeEffect se;

    [SerializeField]
    private int currentRound = 1;
    
    private void Awake()
    {
        rt = RoundTimerObject.GetComponent<RoundTimer>();
        se = CameraObject.GetComponent<ShakeEffect>();
        Physics.gravity = gameGravity;
        rt.roundTime = masterRoundTime;
        rt.countdownTime = masterCountdownTime;
    }
    // Use this for initialization
    void Start () {
	
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("s"))
        {
            StartRound();
        }

        if (Input.GetKeyUp("space"))
        {
            SendShake();
        }

    }

    private void StartRound()
    {
        rt.StartNewRound();
        currentRound++;
    }

    private void SendShake()
    {
        se.ShakeCamera();
    }
}
