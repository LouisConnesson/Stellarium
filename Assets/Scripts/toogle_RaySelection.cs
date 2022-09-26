using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class toogle_RaySelection : MonoBehaviour
{
    private InputDevice targetDeviceRight;
    private bool previousState;
    private bool selectionState;

    // Start is called before the first frame update
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //right controller
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        if (devices.Count > 0)
            targetDeviceRight = devices[0];
        previousState = false;
        transform.GetChild(4).gameObject.SetActive(false);
        selectionState = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool pressed = ButtonPressed();
        if (pressed == true)
        {
            if (selectionState == true)
            {
                transform.GetChild(4).gameObject.SetActive(false);
                selectionState = false;
            }
            else
            {
                transform.GetChild(4).gameObject.SetActive(true);
                selectionState = true;
            }
        }
    }

    bool ButtonPressed()
    {
        bool primaryButtonState = false;
        targetDeviceRight.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState);
        if (primaryButtonState == true)
        {
            if (previousState == false)
            {
                previousState = true;
                return true;
            }
            previousState = true;

        }
        else
        {
            if (previousState == true)
            previousState = false;
        }
        return false;
    }
}
