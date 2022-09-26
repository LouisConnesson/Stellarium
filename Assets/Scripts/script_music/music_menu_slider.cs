using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music_menu_slider : MonoBehaviour
{
    public GameObject music_menu;

    // Update is called once per frame
    void Update()
    {
        music_menu.GetComponent<AudioSource>().volume = this.GetComponent<Slider>().value;

    }
}

