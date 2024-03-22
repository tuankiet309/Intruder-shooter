using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health health;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
     ScoreKeeper scoreKeeper;
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        healthSlider.maxValue = health.GetHealth();
        scoreText.text = "000000000";
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
