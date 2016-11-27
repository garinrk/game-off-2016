using UnityEngine;
using System.Collections;
using System;

public class ShakeEffect : MonoBehaviour {

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

    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
        currentShakeFactor = startingShakeFactor;
    }

    void Update()
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
}
