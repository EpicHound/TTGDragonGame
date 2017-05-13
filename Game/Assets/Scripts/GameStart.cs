using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public ScoreManager Manager;
    public void Reset()
    {
        GameObject[] Object = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject Objects in Object)
        {
            Destroy(Objects);
        }
        Scene CurrentScene = SceneManager.GetActiveScene();
        string Name = CurrentScene.name;
        switch (Name)
        {
            case "JetpackLevel":
                SceneManager.LoadScene("IceLevel");
                Manager = GameObject.Find("/GlobalController").GetComponent<ScoreManager>();
                PlayerPrefs.SetFloat("CurrentScore", Manager.CurrentScore);
                break;
            case "IceLevel":
                SceneManager.LoadScene("Forest");
                break;
            case "Forest":
                SceneManager.LoadScene("Lava");
                break;
            case "Lava":
                Manager = GameObject.Find("/GlobalController").GetComponent<ScoreManager>();
                UpdatePrefs(Manager.CurrentScore);
                SceneManager.LoadScene("HiScore");
                break;
        }
    }
    private void UpdatePrefs(int Input)
    {
        if (Input > PlayerPrefs.GetInt("FirstScore"))
        {
            PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
            PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore"));
            PlayerPrefs.SetInt("ThirdScore", PlayerPrefs.GetInt("SecondScore"));
            PlayerPrefs.SetInt("SecondScore", PlayerPrefs.GetInt("FirstScore"));
            PlayerPrefs.SetInt("FirstScore", Input);
        }
        else if (Input > PlayerPrefs.GetInt("SecondScore"))
        {
            PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
            PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore"));
            PlayerPrefs.SetInt("ThirdScore", PlayerPrefs.GetInt("SecondScore"));
            PlayerPrefs.SetInt("SecondScore", Input);
        }
        else if (Input > PlayerPrefs.GetInt("ThirdScore"))
        {
            PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
            PlayerPrefs.SetInt("FourthScore", PlayerPrefs.GetInt("ThirdScore"));
            PlayerPrefs.SetInt("ThirdScore", Input);
        }
        else if (Input > PlayerPrefs.GetInt("FourthScore"))
        {
            PlayerPrefs.SetInt("FifthScore", PlayerPrefs.GetInt("FourthScore"));
            PlayerPrefs.SetInt("FourthScore", Input);
        }
        else if (Input > PlayerPrefs.GetInt("FifthScore"))
        {
            PlayerPrefs.SetInt("FifthScore", Input);
        }
    }
}
