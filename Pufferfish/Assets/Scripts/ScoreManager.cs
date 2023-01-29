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

    float score = 10;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Mass: " + ((int)score).ToString();
        highscoreText.text = "Highest Mass: " + highscore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMass()
    {
        score += 10;
        scoreText.text = "Mass: " + ((int)score).ToString();
        if(highscore < score)
        {
            PlayerPrefs.SetInt("highscore", (int)score);
        }
    }
    public void SubtractMass()
    {
        if(score >= 1)
        score -= 0.4f;
        scoreText.text = "Mass: " + ((int)score).ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", (int)score);
        }
    }
}
