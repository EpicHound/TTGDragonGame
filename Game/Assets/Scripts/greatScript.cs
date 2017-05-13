using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greatScript : MonoBehaviour {
    Animator anim;
    // Use this for initialization
    void Start() {
        
    }
    float time;
    float startTime;
    private void OnEnable()
    {
        int coins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("Coins", coins + 1);
        anim = GetComponent<Animator>();
        time = Time.time + 3f;
        anim.Play("fadin");    
    }
    // Update is called once per frame
    private void Update()
    {
        if(Time.time > time)
        {
            gameObject.SetActive(false);
        }
    }

}

