using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class DynamicCurve : MonoBehaviour
{
    [Range(1f, 30)] public float a;
    [Range(1f, 60f)] public float b;
    [Range(0f, 30)] public float c;
    List<Vector3> points = new List<Vector3>();
    // Start is called before the first frame update
    void Start() 
    {
        GetComponent<LineRenderer>().widthMultiplier = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        SamplePoints();
    }

    void SamplePoints()
    {
        points.Clear();
        for (float t = 0f; t < 2 * Mathf.PI; t += 0.0075f)
        {
            Vector3 newPoint = F(t);
            points.Add(newPoint);
        }
        GetComponent<LineRenderer>().positionCount = points.Count;
        GetComponent<LineRenderer>().SetPositions(points.ToArray());
    }

    Vector3 F(float t)
    {
        float x = Mathf.Cos(a*t) + Mathf.Cos(b*t)/2 + Mathf.Sin(c*t) / 3;
        float y = Mathf.Sin(a * t) + Mathf.Sin(b * t) / 2 + Mathf.Cos(c * t) / 3;
        float z = 0;
        return new Vector3(x, y, z);
    }
}
