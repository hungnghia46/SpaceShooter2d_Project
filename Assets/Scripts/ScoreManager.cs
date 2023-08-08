using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int scoreCount = 0;
    bool isScoreCount = false;
    public TextMeshProUGUI txtScore;
    private void Start()
    {
        EventManager.Instance.ScoreEvent += UpdateScore;
    }
    private void Update() {
        if(isScoreCount)
        {
            txtScore.text = scoreCount.ToString();
            isScoreCount = false;
        }
    }
    private void UpdateScore(int score)
    {
        scoreCount += score;
        isScoreCount = true;
    }
    private void OnDisable()
    {
        EventManager.Instance.ScoreEvent -= UpdateScore;
    }
}
