using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class WinCondScene1 : MonoBehaviour
{
    private bool[] tags = new bool[100]; // tableau des tags de remplissage ou nn des bonnes drops
    private bool[] tagsR = new bool[100]; // tableau des tags de remplissages dou nn des mauvaises drop
    private Component[] tmp = new Component[50]; // tableau recepteur avant le tri
    private short length; // nombre bonnes drops dans la constellation

    [SerializeField] private GameObject DropZoneManager;
    //private GameObject winpanel;

    // Start is called before the first frame update
    void Start()
    {
        /*winpanel = GameObject.FindGameObjectWithTag("winscene1");
        winpanel.SetActive(false);*/
        tmp = GetComponentsInChildren<dropscript>();
        foreach (dropscript k in tmp)
            if (k.right == true)
                length ++;
    }

    // Update is called once per frame
    void Update()
    {
        int count_filled = 0, count_n_filled = 0; // init de compteurs

        //recup des dropzones et vérification de la complétion de celles-ci
        tmp = GetComponentsInChildren<dropscript>();
        foreach (dropscript k in tmp)
        {
            if (k.right == true && k.filed == true)
            {
                count_filled ++;
            }

            if (k.right == false && k.filed == true)
            {
                count_n_filled ++;
            }
        }

        //condition de victoire
        if (count_filled == length && count_n_filled == 0)
            print("gagné");
            //DropZoneManager.GetComponent<DropZoneSelector>().Complete[DropZoneManager.GetComponent<DropZoneSelector>().ID_Active] = true;
            //winpanel.SetActive(true);
        else
            print("perdu");
            //DropZoneManager.GetComponent<DropZoneSelector>().Complete[DropZoneManager.GetComponent<DropZoneSelector>().ID_Active] = false;
            //winpanel.SetActive(false);

    }
}