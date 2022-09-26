using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PickableObject : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject rightRenderer;

    private float distGrab = 0.05f;

    private GameObject player;
    private bool hasPlayer = false;
    private bool beingcarried = false;
    // Start is called before the first frame update
    private InputDevice targetDeviceRight;

    private Vector3 drop_pos;
    private Vector3 drop_rota;
    private bool onSnapZone = false;
    public bool detectZone = true;

    private Transform transformtest;
    void Start()
    {
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
        float dist = Vector3.Distance(gameObject.transform.position, rightHand.transform.position);

        //on peut ramasser
        if (dist <= distGrab)
            hasPlayer = true;
        else
            hasPlayer = false;

        //on recupere la pression des manettes
        targetDeviceRight.TryGetFeatureValue(CommonUsages.trigger, out float triggerValueRight);


        if (hasPlayer && triggerValueRight >= 0.5f)
        {
            beingcarried = true;
        }

        else
            beingcarried = false;


        if (beingcarried)
        {
            detectZone = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Vector3 manette = new Vector3(rightHand.transform.position.x, rightHand.transform.position.y, rightHand.transform.position.z);
            GetComponent<Rigidbody>().MovePosition(manette);
            rightRenderer.SetActive(false);
        }

        else
        {
            detectZone = true;
            GetComponent<Rigidbody>().isKinematic = false;
            rightRenderer.SetActive(true);
        }
        if (onSnapZone)
        {
            this.GetComponent<Transform>().position = drop_pos;
            this.GetComponent<Transform>().rotation = Quaternion.Euler(drop_rota);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "dropzone")
        {
            if (!beingcarried && other.GetComponent<dropscript>().filed == false)
            {
                GameObject child = other.GetComponent<Transform>().GetChild(0).gameObject;
                drop_pos = new Vector3(child.transform.position.x, child.transform.position.y, child.transform.position.z);
                drop_rota = new Vector3(child.transform.eulerAngles.x, child.transform.eulerAngles.y, child.transform.eulerAngles.z);
                onSnapZone = true;
                other.GetComponent<dropscript>().filed = true;
            }
            else
            {
                onSnapZone = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        print("test");
        if (other.gameObject.tag == "dropzone")
        {
            other.GetComponent<dropscript>().filed = false;
        }
    }
}