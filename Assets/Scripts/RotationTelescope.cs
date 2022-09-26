using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTelescope : MonoBehaviour
{
    [SerializeField] private DropZoneSelector constellation;
    public Vector3[] rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Help();
    }
    void Help()
    {
        transform.eulerAngles = rotation[constellation.ID_Active];
    }
}
