using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> controllerPrefabs;
    private InputDevice targetDeviceRight;
    private InputDevice targetDeviceLeft;

    private GameObject spawnedController;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        //right controller
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
        
        
        if (devices.Count > 0)
        {
            targetDeviceRight = devices[0];
            spawnedController = Instantiate(controllerPrefabs[0], transform);
            
        }
        //left controller
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);
        if (devices.Count > 0)
            targetDeviceLeft = devices[0];

    }

    // Update is called once per frame
    void Update()
    {
        //bouton
       
        if (targetDeviceRight.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue) && primaryButtonValue)
            Debug.Log("Pressing primary button");

        //gachette
        
        if (targetDeviceRight.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue) && triggerValue > 0.1f)
            Debug.Log("Triger pressed" + triggerValue);

        //joystick
        
        if (targetDeviceRight.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2SAxisValue) && primary2SAxisValue != Vector2.zero)
            Debug.Log("Primary touchpad" + primary2SAxisValue);
    }
}
