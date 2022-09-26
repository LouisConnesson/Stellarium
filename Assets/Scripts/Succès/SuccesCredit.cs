using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccesCredit : MonoBehaviour
{
    public float succesCredits;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("credits", 1);//
        succesCredits = PlayerPrefs.GetFloat("credits");
    }

}
