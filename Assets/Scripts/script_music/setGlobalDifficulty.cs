using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setGlobalDifficulty : MonoBehaviour
{
    // Update is called once per frame

    public void EasyGame()
    {
        PlayerPrefs.SetFloat("Sauv_Difficulty", 0);
    }
    public void NormalGame()
    {
        PlayerPrefs.SetFloat("Sauv_Difficulty", 1);
    }
    public void HardGame()
    {
        PlayerPrefs.SetFloat("Sauv_Difficulty", 2);
    }

    //print(PlayerPrefs.GetFloat("Sauv_MusicMenu"));

}
