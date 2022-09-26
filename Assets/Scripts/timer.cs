using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minute = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minute + ":" + seconds;
    }
}
