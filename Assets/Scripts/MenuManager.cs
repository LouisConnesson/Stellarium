using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int size = 0;
    public int[] array;
    public GameObject[] buttons = new GameObject[23];
    public Sprite imgBlue;
    public Sprite imgRed;
    void Start()
    {
        size = GameObject.Find("GameManager").GetComponent<PuzzleManager>().numberOfConstellationsMenu;
        //array = etoiles.ToArray();
        array = GameObject.Find("GameManager").GetComponent<PuzzleManager>().isConstellationEnable;
    }

    // Update is called once per frame
    void Update()
    {
        array = GameObject.Find("GameManager").GetComponent<PuzzleManager>().isConstellationEnable;
        for (int i =0; i< size;i++)
        {
            if (array[i] == 0) // pas debloquee
            {
                //buttons[i].GetComponent<Image>().color = Color.red;
                buttons[i].GetComponent<Button>().enabled = false;
                buttons[i].GetComponent<Button>().image.overrideSprite = imgRed;
            }

            else
            {
                buttons[i].GetComponent<Button>().image.overrideSprite = imgBlue;
                buttons[i].GetComponent<Button>().enabled = true;
            }





        }
    }
}
