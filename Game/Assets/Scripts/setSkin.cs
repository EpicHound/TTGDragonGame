using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class setSkin : MonoBehaviour {
    GameObject dragon;
   public SpriteRenderer head;
    public SpriteRenderer body;
    public SpriteRenderer leftWing;
    public SpriteRenderer rightWing;
    
    public  Row[] sprites;
    public int skin;
	// Use this for initialization
	void Start () {
        dragon = GameObject.Find("/Dragon");
        setSkinBy(PlayerPrefs.GetInt("Selected Skin"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void setSkinBy(int skin)
    {
        head.sprite = sprites[skin].rowdata[0];
        leftWing.sprite = sprites[skin].rowdata[1];
        body.sprite = sprites[skin].rowdata[2];
        rightWing.sprite = sprites[skin].rowdata[3];
    }

     [System.Serializable]
    public class Row
    {
        public Sprite[] rowdata;
    }
}


