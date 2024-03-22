using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 2f;
    [SerializeField] float baseFiringRate= 0.25f;
    [SerializeField] float firingRateVarience = 0f;
    [SerializeField] float miniumFiringRate = 0.1f;
    [SerializeField] bool useAI;
    public bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    Audio_OG audioOG;
    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
        audioOG = GetComponent<Audio_OG>();
    }
    void Start()
    {
        
        if(useAI)
            isFiring = true;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }
    void Fire()
    {
        if (isFiring && firingCoroutine == null)
            firingCoroutine = StartCoroutine(FireContinously());
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }

    }
    IEnumerator FireContinously() 
    {
        while(true) 
        {
            GameObject instance  = Instantiate(projectilePrefab,transform.position,Quaternion.identity);
            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            Destroy(instance,projectileLifetime);
            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVarience, baseFiringRate + firingRateVarience);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile,miniumFiringRate,float.MaxValue);
            audioPlayer.PlayClip(audioOG.GetShootingAudio(), audioOG.GetShootingVolume());
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
