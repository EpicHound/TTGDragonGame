using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    public Text FirstText;
    public Text SecondText;
    public Text ThirdText;
    public Text FourthText;
    public Text FifthText;
	// Use this for initialization
	void Start ()
    {
        
        FirstText.text = ("1)      " + PlayerPrefs.GetInt("FirstScore"));
        SecondText.text = ("2)      " + PlayerPrefs.GetInt("SecondScore"));
        ThirdText.text = ("3)      " + PlayerPrefs.GetInt("ThirdScore"));
        FourthText.text = ("4)      " + PlayerPrefs.GetInt("FourthScore"));
        FifthText.text = ("5)      " + PlayerPrefs.GetInt("FifthScore"));
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
