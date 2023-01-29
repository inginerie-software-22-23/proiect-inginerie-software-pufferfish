using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public float score = 10;
    public int highScore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Mass: " + (int)score;
        highscoreText.text = "Highest Mass: " + highScore;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMass(int mass)
    {
        score += mass;
        scoreText.text = "Mass: " + (int)score;
        
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", (int)score);
        }
    }
    
    public void SubtractMass()
    {
        if (score >= 1)
        {
            score -= 0.4f;
        }
        
        scoreText.text = "Mass: " + (int)score;
        
        if (highScore < score)
        {
            PlayerPrefs.SetInt("highScore", (int)score);
        }
    }
}
