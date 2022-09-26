using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFullSucces : MonoBehaviour
{
    public GameObject box_succes1;
    public GameObject box_succes2;
    public GameObject box_succes3;
    public GameObject box_succes4;
    public GameObject box_succes5;
    public float succesCredits;

    void Update()
    {
        if (PlayerPrefs.GetFloat("scene1OK") == 1)
        {
            box_succes1.SetActive(true);
        }
        if (PlayerPrefs.GetFloat("scene2OK") == 1)
        {
            box_succes2.SetActive(true);
        }
        if (PlayerPrefs.GetFloat("scene2&1OK") == 1)
        {
            box_succes3.SetActive(true);
        }
        succesCredits = PlayerPrefs.GetFloat("credits");
        if (PlayerPrefs.GetFloat("credits") == 1)
        {
            box_succes4.SetActive(true);
        }
        if (PlayerPrefs.GetFloat("deadByMeteores") == 1)
        {
            box_succes5.SetActive(true);
        }
    }
}
