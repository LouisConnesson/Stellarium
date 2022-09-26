using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getGlobalDifficulty : MonoBehaviour
{
    public float difficulty;
    // Start is called before the first frame update
    void Update()
    {
        difficulty = PlayerPrefs.GetFloat("Sauv_Difficulty");
    }

}
