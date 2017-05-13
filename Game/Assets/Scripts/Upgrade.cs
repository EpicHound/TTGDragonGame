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
        CurrentCoins = PlayerPrefs.GetInt("Coins", 19);
        Text.text = ("You Have: " + CurrentCoins + " Coins."); 	
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerPrefs.SetInt("Coins", CurrentCoins);
        Text.text = ("You Have: " + CurrentCoins + " Coins.");
    }
}
