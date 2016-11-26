using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour
{

    public static CameraManager instance = null;

    /// <summary>
    /// SHAKE EFFECT SHIT
    /// </summary>

    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private Transform camTransform;

    // How long the object should shake for.
    public float shakeDuration = 0f;
    private float shakeLeft = 0f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float startingShakeFactor = 0.7f;
    private float currentShakeFactor;
    public float shakeFactorDelta = 0.05f;

    Vector3 originalPos;

    /// <summary>
    /// END SHAKE EFFECT SHIT
    /// </summary>

    void Awake()
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

        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        ShakeEnable();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShakeUpdate();
    }


    /// <summary>
    /// MORE SHAKE EFFECT SHIT
    /// </summary>

    void ShakeUpdate()
    {
        if (shakeLeft > 0)
        {
            camTransform.localPosition = originalPos + UnityEngine.Random.insideUnitSphere * currentShakeFactor;

            shakeLeft -= Time.deltaTime;
        }
        else
        {
            camTransform.localPosition = originalPos;
        }
    }


    public void ShakeCamera()
    {
        if (shakeLeft > 0)
        {
            currentShakeFactor += shakeFactorDelta;
            return;
        }
        else
        {
            currentShakeFactor = startingShakeFactor;
            shakeLeft = shakeDuration;
        }

    }

    void ShakeEnable()
    {
        originalPos = camTransform.localPosition;
        currentShakeFactor = startingShakeFactor;
    }

    /// <summary>
    /// END MORE SHAKE EFFECT SHIT
    /// </summary>


}
