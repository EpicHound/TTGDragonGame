using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        GameObject[] Backgrounds = GameObject.FindGameObjectsWithTag("Background");
        int Show = (Random.Range(1, Backgrounds.GetLength(0))) - 1;
        foreach (GameObject Background in Backgrounds)
        {
            Background.SetActive(false);
        }
        Backgrounds[Show].SetActive(true);
    }
}
