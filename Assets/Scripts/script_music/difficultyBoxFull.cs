using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class difficultyBoxFull : MonoBehaviour
{
    public GameObject box_easy;
    public GameObject box_normal;
    public GameObject box_hard;
    public float difficulty;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = PlayerPrefs.GetFloat("Sauv_Difficulty");
        if (difficulty == 0)
        {
            box_easy.SetActive(true);
        }
        if (difficulty == 1)
        {
            box_normal.SetActive(true);
        }
        if (difficulty == 2)
        {
            box_hard.SetActive(true);
        }
    }

}
