using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Text ScoreText;
    public int CurrentScore = 0;
    private string TextOutput = "Score: 0";
	void Start ()
    {
        
	}
	public void UpdateScore()
    {
        CurrentScore += 50;
        TextOutput = ("Score: " + CurrentScore);
        ScoreText.text = TextOutput;
    }
}
