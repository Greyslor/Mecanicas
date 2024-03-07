using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorBehaviour : MonoBehaviour
{
    public Vector3 components;
    public Vector3 origin;
    public Color color;
    private Transform cone;
    private Transform sphere;
    // Start is called before the first frame update
    void Start()
    {
        InitVector();
    }

    // Update is called once per frame
    void Update()
    {
        ModifyVector();   
    }

    void InitVector()
    {
        sphere = transform.Find("Sphere");
        sphere.localScale = 0.3f * Vector3.one;
        cone = transform.Find("Cone");
        cone.localScale = 0.25f * Vector3.one;
        GetComponent<LineRenderer>().widthMultiplier = 0.1f;
        GetComponent<LineRenderer>().positionCount = 2;
    }

    void ModifyVector()
    {
        sphere.position = origin;
        cone.position = origin + components;
        cone.up = components;

        float magnitude = components.magnitude - 0.5f;
        GetComponent<LineRenderer>().SetPosition(0, origin);
        GetComponent<LineRenderer>().SetPosition(1, origin + magnitude * (components.normalized));

        sphere.GetComponent<MeshRenderer>().material.color = color;
        cone.GetComponent<MeshRenderer>().material.color = color;
        GetComponent<LineRenderer>().material.color = color;
    }
}
