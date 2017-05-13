using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
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
                break;
            case "IceLevel":
                SceneManager.LoadScene("Forest");
                break;
            case "Forest":
                SceneManager.LoadScene("Lava");
                break;
            case "Lava":
                SceneManager.LoadScene("HiScore");
                break;
        }
    }
}
