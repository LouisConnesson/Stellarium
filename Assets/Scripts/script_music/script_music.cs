using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class script_music : MonoBehaviour
{
    public GameObject music_menu;
    public GameObject music_game;

    // Update is called once per frame
    void Update()
    {
        music_menu.GetComponent<AudioSource>().volume = this.GetComponent<Slider>().value;
        music_game.GetComponent<AudioSource>().volume = this.GetComponent<Slider>().value;
    }
}
