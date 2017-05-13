using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text ScoreText;
    public int CurrentScore = 0;
    private string TextOutput = "";
	void Start ()
    {
        CurrentScore = PlayerPrefs.GetInt("CurrentScore");
        TextOutput = ("Score: " + CurrentScore);
        ScoreText.text = TextOutput;
    }
	public void UpdateScore()
    {
        CurrentScore += 50;
        TextOutput = ("Score: " + CurrentScore);
        ScoreText.text = TextOutput;
        PlayerPrefs.SetInt("CurrentScore",CurrentScore);
    }
}
