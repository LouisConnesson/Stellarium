using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_sparkle : MonoBehaviour
{
    float init_range = 0.0f;
    bool flag;
    // Start is called before the first frame update
    void Start()
    {
       init_range = this.GetComponent<Light>().range;
    }

    // Update is called once per frame
    void Update()
    {
            if (this.GetComponent<Light>().range <= init_range - 1)
        {
            flag = true;
        }
        else if (this.GetComponent<Light>().range >= init_range + 1)
        {
            flag = false;
        }
            if (this.GetComponent<Light>().range <= init_range + 1 && flag == true)
        {
            this.GetComponent<Light>().range = this.GetComponent<Light>().range + 0.1f;
        }
        else if (this.GetComponent<Light>().range >= init_range - 1 && flag == false)
            this.GetComponent<Light>().range = this.GetComponent<Light>().range - 0.1f;


    }
}
