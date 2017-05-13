using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mo : MonoBehaviour
{
    private Fizzyo.BreathRecogniser BreathRecognise;
    public string levelname;
    void Start()
    {

    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SceneManager.LoadScene(levelname);
        }
    }
}