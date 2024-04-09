using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class HarmonicOscillator : MonoBehaviour
{
    public Transform mass;
    public Transform spring;

    public float amplitude, frequency, phase;
    public float radius, turns, restLenght;

    private List<Vector3> pointList = new List<Vector3>();
    private float time, lenght;
    // Start is called before the first frame update
    void Start()
    {
        SetLineRenderer();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        mass.localPosition = PositionFunction();
        lenght = mass.localPosition.y;
        ChangeMassColor();
        UpdateSpringPoints();
    }

    void ChangeMassColor()
    {
        float lerpFactor = (mass.position.y - restLenght) / amplitude;

    }

    Vector3 PositionFunction()
    {
        float y = restLenght + amplitude *Mathf.Sin(frequency * time - phase);
        return new Vector3(0, y, 0);
    }

    void SetLineRenderer()
    {
        spring.GetComponent<LineRenderer>().useWorldSpace = false;
        spring.GetComponent<LineRenderer>().widthMultiplier = 0.05f;
    }

    void UpdateSpringPoints()
    {
        pointList.Clear();
        float pi = Mathf.PI;
        for (float s = 0f; s < 2f * pi; s+= 0.025f)
        {
            Vector3 point = SpringShape(s);
            pointList.Add(point);

        }

        spring.GetComponent<LineRenderer>().positionCount = pointList.Count;
        spring.GetComponent<LineRenderer>().SetPositions(pointList.ToArray());

    }

    Vector3 SpringShape(float s)
    {
        float pi = Mathf.PI;
        float x = radius * Mathf.Cos(turns * s);
        float y = s * lenght / (2 * pi);
        float z = radius * Mathf.Sin(turns * 5);
        return new Vector3(x, y, z);
    }
}
