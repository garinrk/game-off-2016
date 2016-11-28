using UnityEngine;
using System.Collections;

public class HackingTrigger : MonoBehaviour {

    bool triggered = false;
    [SerializeField]
    GameObject consoleMessageObject;

    [SerializeField]
    GameObject consoleCanvasObject;

    CanvasGroup consoleCG;

    private void Awake()
    {
    //    consoleCG = consoleCanvasObject.GetComponent<CanvasGroup>();
    //    consoleCG.alpha = 0f;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Input.GetKeyDown("h") && triggered == false)
        {
            triggered = true;
            Manager.instance.SendStartRound();
            consoleMessageObject.SetActive(false);

            //consoleCG.alpha = 1f;
        }
    }

    public void Reset()
    {
        triggered = false;
    }
}
