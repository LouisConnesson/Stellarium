using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_test : MonoBehaviour
{
    public GameObject obj;
    public GameObject constellation;
    private Color couleur =  Color.red;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            constellation.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            constellation.SetActive(true);
        }
    }
    void OnMouseOver()
    {
        //Destroy.
        this.GetComponent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f);
        
    }
    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = couleur;
    }
}
