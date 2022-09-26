using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemLittle : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform soleil;
    public GameObject[] planetes = new GameObject[8];
    public float[] speed = new float[8];
    public int coeff = 2;
        
    // Update is called once per frame
    void Update()
    {
        for(int i =0;i<8;i++)
        {
            planetes[i].transform.RotateAround(soleil.transform.position, soleil.transform.up, coeff * speed[i] * Time.deltaTime);

        }
    }
}
