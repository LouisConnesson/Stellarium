using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3[] positions;
    void Start()
    {
        int randomNumber = Random.Range(0, positions.Length);
        transform.position = positions[randomNumber];
    }
}
