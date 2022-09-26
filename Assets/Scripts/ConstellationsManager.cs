using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class ConstellationsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI[] textes;
    public string[] paths;
    public int size = 16;
    void Start()
    {
        var paths = new List<string>();
        for (int i = 0; i < size; i++)
            paths.Add("./Assets/Textes/" + "constellation_" + (i+1).ToString() + ".txt");

        var filetext = new List<string>();
        for (int i = 0; i < size; i++)
             filetext.Add(File.ReadAllText(paths[i]));

        for (int i = 0; i < size; i++)
            textes[i].text = filetext[i];

        for (int i = 0; i < size; i++)
            Debug.Log(paths[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
