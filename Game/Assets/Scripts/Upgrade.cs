using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {
    int CurrentCoins = 0;
    public Text Text;
	// Use this for initialization
	void Start ()
    {
        CurrentCoins = PlayerPrefs.GetInt("Coins");
        Text.text = ("You Have: " + CurrentCoins + " Coins."); 	
	}
	
	// Update is called once per frame
	void Update ()
    {
        CurrentCoins = PlayerPrefs.GetInt("Coins");
        Text.text = ("You Have: " + CurrentCoins + " Coins.");
    }
}
