using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int numberOfConstellationsMenu = 23;
    public int numberOfConstellationsPuzzle = 26;
    public int[] isConstellationEnable = new int[26];
    public int nbFails = 0;
    public GameObject[] objectConstellation = new GameObject[26];
    // Start is called before the first frame update
    public GameObject meteors;
    public GameObject fireWorks;

    void Start()
    {
        for (int i = 0; i < numberOfConstellationsPuzzle; i++)
            isConstellationEnable[i] = 0;

        for(int i =0;i< numberOfConstellationsPuzzle; i++)
        {
            if (isConstellationEnable[i] == 0)
            {
                objectConstellation[i].SetActive(false);
            }
            else
                objectConstellation[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(nbFails > 10)
        {
            meteors.SetActive(true);
            PlayerPrefs.SetFloat("deadByMeteores", 1);
        }
        else
            meteors.SetActive(false);

        bool victory = true;
        for (int i = 0; i < 16; i++)
        {
            if(isConstellationEnable[i] == 0)
                victory = false;
        }
        if (victory)
        {
            fireWorks.SetActive(true);
            PlayerPrefs.SetFloat("scene2Ok",1);
            if (PlayerPrefs.GetFloat("scene1Ok") == 1)
                PlayerPrefs.SetFloat("scene2&1Ok", 1);
            if (nbFails == 0)
                PlayerPrefs.SetFloat("0fauteScene2", 1);
        }
        else
            fireWorks.SetActive(false);

        for (int i = 0; i < numberOfConstellationsPuzzle; i++)
        {
            if (isConstellationEnable[i] == 0)
            {
                objectConstellation[i].SetActive(false);
            }
            else
                objectConstellation[i].SetActive(true);
        }
    }
}
