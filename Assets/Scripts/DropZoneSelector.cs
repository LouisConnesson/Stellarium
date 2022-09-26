using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropZoneSelector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    public int ID_Active;
    public bool[] Complete;
    private GameObject winpanel;
    private bool[] tags = new bool[100]; // tableau des tags de remplissage ou nn des bonnes drops
    private bool[] tagsR = new bool[100]; // tableau des tags de remplissages dou nn des mauvaises drop
    private Component[] tmp = new Component[50]; // tableau recepteur avant le tri
    private short length; // nombre bonnes drops dans la constellation
    // Start is called before the first frame update
    void Start()
    {
        winpanel = GameObject.FindGameObjectWithTag("winscene1");
        winpanel.SetActive(false);
        ID_Active = 0;
        Complete = new bool[transform.childCount];
        tmp = transform.GetChild(ID_Active).GetComponentsInChildren<dropscript>();
        length = 0;
        foreach (dropscript k in tmp)
            if (k.right == true)
                length ++;
    }

    void Update()
    {
        int count_filled = 0, count_n_filled = 0; // init de compteurs

        //recup des dropzones et vérification de la complétion de celles-ci
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

        //condition de complétion Constellation
        if (count_filled == length && count_n_filled == 0)
        {
            winpanel.SetActive(true);
            Complete[ID_Active] = true;
        }
        else
        {
            winpanel.SetActive(false);
            Complete[ID_Active] = false;
        }
        int count = 0;

        //Victoire
        foreach (bool constellation in Complete)
            if (constellation == true)
                count ++;
        if (count == Complete.Length)
        {
            GameObject.FindGameObjectsWithTag("Victory")[0].SetActive(true);
        }
    }

    public void IncrementDropZoneActive()
    {
        transform.GetChild((ID_Active+1)%transform.childCount).gameObject.SetActive(true);
        transform.GetChild(ID_Active).gameObject.SetActive(false);
        ID_Active = (ID_Active+1)%transform.childCount;
        Text.GetComponent<TextMeshProUGUI>().text = transform.GetChild(ID_Active).name;
        if (Complete[ID_Active] == true)
            winpanel.SetActive(true);
        else
            winpanel.SetActive(false);
        tmp = transform.GetChild(ID_Active).GetComponentsInChildren<dropscript>();
        length = 0;
        foreach (dropscript k in tmp)
            if (k.right == true)
                length ++;
    }
    public void DecrementDropZoneActive()
    {
        transform.GetChild(ID_Active).gameObject.SetActive(false);
        ID_Active = ID_Active-1;
        if (ID_Active < 0)
            ID_Active += transform.childCount;
        transform.GetChild(ID_Active).gameObject.SetActive(true);
        Text.GetComponent<TextMeshProUGUI>().text = transform.GetChild(ID_Active).name;
        tmp = transform.GetChild(ID_Active).GetComponentsInChildren<dropscript>();
        length = 0;
        foreach (dropscript k in tmp)
            if (k.right == true)
                length ++;
    }

}
