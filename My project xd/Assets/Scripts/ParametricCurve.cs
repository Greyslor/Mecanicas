using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametricCurve : MonoBehaviour
{
    public float tMin, tMax;
    public float time;
    List<Vector3> points = new List<Vector3>();
    public Transform obj;
    float t;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<LineRenderer>().widthMultiplier = 1.0f;
        SamplePoints();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        obj.transform.position = F2(time);
    }

    void SamplePoints()
    {
        points.Clear();
        for (float t  = tMin; t <= tMax; t += 0.025f)

        {
            Vector3 newPoint = F2(t);
            points.Add(newPoint);
        }
        GetComponent<LineRenderer>().positionCount = points.Count;
        GetComponent<LineRenderer>().SetPositions(points.ToArray());
    }

    Vector3 F1(float t)
    {
        float r = 5f;
        float w = 2.5f;
        float h = 1.5f;

        float x = r *Mathf.Cos(w *t);
        float y = h * t;
        float z = r *Mathf.Sin(w * t);
        return new Vector3(x, y, z);

    }

    Vector3 F2(float t)
    {
        float x = 7 * (t - Mathf.Sin(t));
        float y = 0;
        float z = 7 * (1 - Mathf.Cos(t));
        return new Vector3(x, y, z);
    }

    /*Vector3 F3(float t)
    {
        float x = Mathf.Exp(-0.1 * t) * Mathf.Cos(t);
        float y = 0;
        float z = 0.75 t;
        return new Vector3(x, y, z);
    }*/
}
