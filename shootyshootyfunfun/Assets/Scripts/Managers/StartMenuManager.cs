using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour {

    public GameObject fadeObject;

    CanvasGroup fade_cg;

    [SerializeField]
    float fade_factor = 2f;

    bool loading = false;

    bool loadingIn = true;
    private void Awake()
    {
        fade_cg = fadeObject.GetComponent<CanvasGroup>();
        fade_cg.alpha = 1f;

        StartCoroutine(FadeIn());
    }

    // Use this for initialization
    void Start () {
		//Cursor.SetCursor(cursorTexture, Vector3.zero, CursorMode.Auto);	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown & !loading && !loadingIn)
        {
            loading = true;
            StartCoroutine(FadeOutToLevel());
        }
	}

    IEnumerator FadeOutToLevel()
    {
        yield return new WaitForSeconds(1);
        while (fade_cg.alpha < 1)
        {
            fade_cg.alpha += Time.deltaTime / fade_factor;
            yield return null;
        }

        SceneManager.LoadScene(1);
        
    }

    IEnumerator FadeIn()
    {

        yield return new WaitForSeconds(1);


        while (fade_cg.alpha > 0)
        {
            fade_cg.alpha -= Time.deltaTime / fade_factor;
            yield return null;
        }

        loadingIn = false;
    }
}
