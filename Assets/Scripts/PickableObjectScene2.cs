using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PickableObjectScene2 : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject rightRenderer;

    private float distGrab = 0.3f;

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


        //on ramasse
        /* if (hasPlayer && triggerValueRight >= 0.5f)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            //transform.parent = playerCam;
            Vector3 manette = new Vector3(rightHand.transform.position.x, rightHand.transform.position.y, rightHand.transform.position.z);
            Vector3 size = GetComponent<Collider>().bounds.size;
            GetComponent<Rigidbody>().MovePosition(manette + size / 2);
            GetComponent<Rigidbody>().MoveRotation(rightHand.transform.rotation * Quaternion.Euler(200f, 200f, 200f));
           beingcarried = true;
        }

       else if (hasPlayer && triggerValueLeft >= 0.5f)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            //transform.parent = playerCam;
            Vector3 manette = new Vector3(leftHand.transform.position.x, leftHand.transform.position.y, leftHand.transform.position.z);
            Vector3 size =  GetComponent<Collider>().bounds.size;
            GetComponent<Rigidbody>().MovePosition(manette + size/2);
            beingcarried = true;
        }*/
        if (hasPlayer && triggerValueRight >= 0.5f)
        {
            beingcarried = true;
        }
        
        else
            beingcarried = false;

        
       /* if(beingcarried)
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
        }*/
        if(onSnapZone)
        {
            this.GetComponent<Transform>().position = drop_pos;
            this.GetComponent<Transform>().rotation = Quaternion.Euler(drop_rota);
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        var multiTags = GetComponent<MultipleTags>();
        if (other.gameObject.tag == this.tag)
        {
            other.gameObject.GetComponent<Renderer>().material = GameObject.Find("GameManager").GetComponent<LevelManager>().materialsLevel[0];
            Debug.Log("dropzone");
            if (!beingcarried)
            {
                GameObject child = other.GetComponent<Transform>().GetChild(0).gameObject;
                Debug.Log(child.name);
                //drop = new Vector3(other.GetComponent<Transform>().position.x, other.GetComponent<Transform>().position.y, other.GetComponent<Transform>().position.z);
                drop_pos = new Vector3(child.transform.position.x, child.transform.position.y, child.transform.position.z);
                drop_rota = new Vector3(child.transform.eulerAngles.x, child.transform.eulerAngles.y, child.transform.eulerAngles.z);
                onSnapZone = true;

                for(int i =0;i < GetComponent<Transform>().childCount;i++)
                {
                    GameObject child2 = GetComponent<Transform>().GetChild(i).gameObject;
                    if(child2.tag == "idConstellation")
                        GameObject.Find("GameManager").GetComponent<PuzzleManager>().isConstellationEnable[int.Parse(child2.name)] = 1;

                }
            }
            else
                onSnapZone = false;
        }
        else if(other.gameObject.tag =="Verif")
        {
            if(detectZone == true)
            {
                if (other.gameObject.GetComponent<MultipleTags>().HasTag(this.tag))
                {
                    Debug.Log("AHHHHHHH");

                }
                else
                {
                    Debug.Log("BBBBBBBBB");
                    GameObject.Find("GameManager").GetComponent<PuzzleManager>().nbFails += 1;

                }
            }
           
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        var multiTags = GetComponent<MultipleTags>();
        if (other.gameObject.tag == this.tag)
        {
            other.gameObject.GetComponent<Renderer>().material = GameObject.Find("GameManager").GetComponent<LevelManager>().materialsLevel[1];
            GameObject child = other.GetComponent<Transform>().GetChild(0).gameObject;
            Debug.Log(child.name);

            for (int i = 0; i < GetComponent<Transform>().childCount; i++)
            {
                GameObject child2 = GetComponent<Transform>().GetChild(i).gameObject;
                if (child2.tag == "idConstellation")
                    GameObject.Find("GameManager").GetComponent<PuzzleManager>().isConstellationEnable[int.Parse(child2.name)] = 0;

            }

        }

    }

}
