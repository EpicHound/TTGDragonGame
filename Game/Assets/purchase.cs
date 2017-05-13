using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purchase : MonoBehaviour {
    public int skinNumber;
    public int Price;
    bool isBought = false;
    public Sprite switchSprite;
	// Use this for initialization
	void Start () {
        if (PlayerPrefs.GetInt("skin" + skinNumber + "isBought") == 1)
        {
            GetComponent<SpriteRenderer>().sprite = switchSprite;
            isBought = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if(isBought == true)
        {
            PlayerPrefs.SetInt("Selected Skin", skinNumber);
            PlayerPrefs.SetInt("skin" + skinNumber + "isBought", 1);
        }
        else
        {
            if(PlayerPrefs.GetInt("Coins") >= Price)
            {
                int newCoins = PlayerPrefs.GetInt("Coins") - Price;
                PlayerPrefs.SetInt("Coins", newCoins);
                GetComponent<SpriteRenderer>().sprite = switchSprite;
                PlayerPrefs.SetInt("Selected Skin", skinNumber);
                PlayerPrefs.SetInt("skin" + skinNumber + "isBought", 1);
            }
        }
    }
}
