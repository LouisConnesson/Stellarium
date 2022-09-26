using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getGlobalSound : MonoBehaviour
{
    public GameObject music_menu;
    public GameObject music_game;
    public GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        music_menu.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sauv_MusicMenu");
        music_game.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sauv_MusicGame");
        slider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("Sauv_MusicMenu");
    }


}
