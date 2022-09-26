using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    readonly float G = 100f;
    public GameObject[] planetes;
    void Start()
    {
        planetes = GameObject.FindGameObjectsWithTag("Planete");
        Velocity();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Gravity();
    }

    void Gravity()
    {
        foreach(GameObject a in planetes)
            foreach(GameObject b in planetes)
                if(!a.Equals(b))
                {
                    float m1 = a.GetComponent<Rigidbody>().mass;
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);

                    a.GetComponent<Rigidbody>().AddForce((b.transform.position - a.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
    }
    void Velocity()
    {
        foreach (GameObject a in planetes)
            foreach (GameObject b in planetes)
                if (!a.Equals(b))
                {
                    float m2 = b.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(a.transform.position, b.transform.position);
                    a.transform.LookAt(b.transform);

                    float speed = Mathf.Sqrt((G * m2) / r);
                    a.GetComponent<Rigidbody>().velocity += a.transform.right *speed;
                }
    }
}
