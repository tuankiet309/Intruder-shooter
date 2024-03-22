using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    [SerializeField] GameObject engine;
    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    Audio_OG audioOG;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;
    Animator anim;
    CapsuleCollider2D playerCollider;
    Shooter shooter;
    Player player;
    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioOG = GetComponent<Audio_OG>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
        anim = GetComponentInChildren<Animator>();
        playerCollider = GetComponent<CapsuleCollider2D>();
        player = GetComponent<Player>();
        shooter = GetComponent<Shooter>();
        ////?o?n code d??i do có m?t s? l?i không s?a ???c nên ???c cho vào Script này (L?i Null reference)
        ///Ban ??u nó ???c ??t trong Level Manager Script 
        /// Ý ngh?a c?a code: Reset Score m?i l?n load Main Game 
        if(isPlayer)
        {
            scoreKeeper.ResetScore();
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<DealDamage>() != null)
        {
            health -= collision.GetComponent<DealDamage>().GetDamage();
            ShakeCamera();
            PlayerHitEffect();
            if (health <= 0) 
            {
                Die();
            }   
            collision.GetComponent<DealDamage>().Hit();
        }

    }
    void Die()
    {
        

        if(!isPlayer)
        {
            Destroy(gameObject);
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            Destroy(engine);
            anim.SetBool("isDestroyed", true);
            player.enabled = false;
            playerCollider.enabled = false;
            shooter.enabled = false;
            StartCoroutine(Destroyed());
        }

    }
    void PlayerHitEffect()
    {
        if(hitEffect!=null)
        {
            ParticleSystem intance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            audioPlayer.PlayClip(audioOG.GetDamagedAudio(),audioOG.GetDamagedVolume());
            Destroy(intance.gameObject,intance.main.duration + intance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake) 
        {
            cameraShake.Play();
        }
    }
    public int GetHealth()
    {
        return health;
    }
    IEnumerator Destroyed()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        levelManager.LoadGameOver();
    }
    
    
}
