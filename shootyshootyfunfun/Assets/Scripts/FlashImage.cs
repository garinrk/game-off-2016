using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FlashImage : MonoBehaviour {

    CanvasGroup myCG;
    SpriteRenderer sr;
    bool flashing = false;

    private void Awake()
    {
        sr = GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
    }

    private void OnEnable()
    {
        TurnOn();
        StartCoroutine(Flash());
    }

    private void OnDisable()
    {
        StopCoroutine(Flash());
        TurnOff();
    }

    IEnumerator Flash()
    {
        while (flashing)
        {
            yield return new WaitForSeconds(.5f);

            Color temp = sr.color;
            if (temp.a == 1f)
            {
                temp.a = 0f;
                sr.color = temp;
            }
            else
            {
                temp.a = 1f;
                sr.color = temp;
            }
            //if (myCG.alpha == 1f)
            //    myCG.alpha = 0;
            //else
            //    myCG.alpha = 1;

            yield return null;

        }

        yield return null;

   }

    void TurnOff()
    {
        flashing = false;
        Color temp = sr.color;
        temp.a = 0f;
        sr.color = temp;
    }
    
    void TurnOn()
    {
        flashing = true;
    }
}
