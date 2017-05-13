using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private Fizzyo.BreathRecogniser BreathRecognise;
    public string levelname ="";
	void Start ()
    {

    }
	void Update ()
    { 

	}
    void OnMouseDown()
    {
        SceneManager.LoadScene(levelname);
    }
}
