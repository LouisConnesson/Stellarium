using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
public class script_menu : MonoBehaviour
{
    // Start is called before the first frame update
    
    public GameObject canvas;
    public GameObject credits;
    public GameObject options;
    public GameObject infos;
    public GameObject credits_retour;
    public GameObject menu;
    public GameObject music;
    private InputDevice targetDeviceRight;
    private bool flag = false;
    private bool flag_menu = false;
    void Start()
    {
        canvas.SetActive(false);
        List<InputDevice> devices = new List<InputDevice>();
        //right controller
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        if (devices.Count > 0)
            targetDeviceRight = devices[0];
    }

    // Update is called once per frame
    void Update()
    {
        targetDeviceRight.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueRight);
        Debug.Log(triggerValueRight);
        if (triggerValueRight >= 0.5f)
           flag_menu = true;

        else
            flag_menu = false;

        if (flag_menu == true && flag == false)
        {
            canvas.SetActive(true);
            music.GetComponent<AudioSource>().mute = true;
            flag = true;
        }

        else if (flag_menu == false &&  flag == true)
        {
            canvas.SetActive(false);
            credits.SetActive(false);
            options.SetActive(false);
            credits_retour.SetActive(false);
            infos.SetActive(false);
            menu.SetActive(true);

            music.GetComponent<AudioSource>().mute = false;

            flag = false;
        }
    }
}
