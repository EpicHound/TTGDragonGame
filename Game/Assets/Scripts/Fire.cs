using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fire : MonoBehaviour {
    public ParticleSystem FireEffect;
    private float TimeEffect;
	void Start ()
    {
		
	}
	void Update ()
    {
        FireEffect.gameObject.SetActive(true);
        TimeEffect += Time.deltaTime;
        if (TimeEffect > 5)
        {
            SceneManager.LoadScene("MainWindow");
        }
	}
}
