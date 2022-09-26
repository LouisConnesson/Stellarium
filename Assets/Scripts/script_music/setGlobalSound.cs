using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setGlobalSound : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("Sauv_MusicMenu", this.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("Sauv_MusicGame", this.GetComponent<Slider>().value);
        //print(PlayerPrefs.GetFloat("Sauv_MusicMenu"));
    }
}
