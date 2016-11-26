using UnityEngine;
using System.Collections;
using System;

enum GameState
{
    PLAYING,
    STOPPED
}

public class Manager : MonoBehaviour {


    public static Manager instance = null;

    public Vector3 gameGravity = new Vector3(0, -1.0f, 0);
    
    public GameObject MainCanvasObject;
    
    private CameraManager cmra_mgr;
    [SerializeField]
    private int currentRound = 1;
    
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
            StartRound();
        }

        if (Input.GetKeyUp("space"))
        {
            SendShake();
        }

    }

    private void StartRound()
    {
        UIManager.instance.StartNewRound();
        currentRound++;
    }

    private void SendShake()
    {

        CameraManager.instance.ShakeCamera();

    }
}
