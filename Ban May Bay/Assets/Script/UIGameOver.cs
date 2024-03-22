using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;
    // Update is called once per frame
    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        scoreText.text = "Score\n" + scoreKeeper.GetScore();
    }
    void Update()
    {
        
    }
}
