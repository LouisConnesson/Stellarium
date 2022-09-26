using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("0fauteScene2", 0); //OK
        PlayerPrefs.SetFloat("scene1Ok", 0);//
        PlayerPrefs.SetFloat("scene2Ok", 0);//OK
        PlayerPrefs.SetFloat("scene2&1Ok", 0);//OK
        PlayerPrefs.SetFloat("credits", 0);//
        PlayerPrefs.SetFloat("deadByMeteores", 0);//OK        
        PlayerPrefs.SetFloat("telescope", 0);//

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
