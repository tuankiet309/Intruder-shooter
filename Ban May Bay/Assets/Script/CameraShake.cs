using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1f;
    [SerializeField] float shakeMagnitude = 0.5f;
    Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake()
    {
        float elapseTime = 0;
        while (elapseTime < shakeDuration)
        {
            transform.position = initialPosition + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapseTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPosition;
    }
}
