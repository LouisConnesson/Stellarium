using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] pieces = new GameObject[14];
    public Material[] materialsLevel = new Material[2]; //0 transparent, 1 visible
    public int selectLevel = 0;
    public int[] probaLevel = new int[] { 50, 30 };
    public int[] probaPiece = new int[14];
    void Start()
    {
        selectLevel = (int)PlayerPrefs.GetFloat("Sauv_Difficulty");
        pieces = GameObject.FindGameObjectsWithTag("dropzone");
        for (int i = 0; i < 14; i++)
            probaPiece[i] = Random.Range(0, 100);

        for (int i = 0; i < 14; i++)
            probaPiece[i] = Random.Range(0, 100);

        if (selectLevel == 0)
        {
            for (int i = 0; i < 14; i++)
                pieces[i].GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material = materialsLevel[1];
        }
        else
        {


            for (int i = 0; i < 14; i++)
            {
                Debug.Log(probaLevel[selectLevel - 1]);
                if (probaPiece[i] < probaLevel[selectLevel - 1])
                    pieces[i].GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material = materialsLevel[1];
                else
                    pieces[i].GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material = materialsLevel[0];

            }
        }
    }

    // Update is called once per frame
    void Update()
    {

       /* if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 14; i++)
                probaPiece[i] = Random.Range(0, 100);

            if (selectLevel == 0)
            {
                for (int i = 0; i < 14; i++)
                    pieces[i].GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material = materialsLevel[1];
            }
            else
            {


                for (int i = 0; i < 14; i++)
                {
                    Debug.Log(probaLevel[selectLevel - 1]);
                    if (probaPiece[i] < probaLevel[selectLevel - 1])
                        pieces[i].GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material = materialsLevel[1];
                    else
                        pieces[i].GetComponent<Transform>().GetChild(0).GetComponent<MeshRenderer>().material = materialsLevel[0];

                }
            }
        }*/


    }
}
