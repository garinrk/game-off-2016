using UnityEngine;
using System.Collections;
using System;


public class Manager : MonoBehaviour {


    public static Manager instance = null;

    public Vector3 gameGravity = new Vector3(0, -1.0f, 0);
    


    [SerializeField]
    private int currentRound = 0;
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
    }
    // Use this for initialization
    void Start () {
	
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("s"))
        {
            SendStartRound();
        }

        if (Input.GetKeyUp("space"))
        {
            SendShake();
        }

    }

    private void SendStartRound()
    {
        //wow that's ugly as fuck, sorry fam
        if (UIManager.instance.timer.isCountingToRoundStart || UIManager.instance.timer.isCountingToStartRemoval)
            return;
        currentRound++;
        UIManager.instance.StartNewRound(currentRound);
    }

    private void SendShake()
    {

        CameraManager.instance.ShakeCamera();

    }
}
