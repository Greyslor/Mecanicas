using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeMovement : MonoBehaviour
{
    public float swing;
    public Transform fireBalls;
    private BezierCurve _bezierCurve;
    private float initialSwingSpeed = 1f; 
    private float swingSpeedIncreaseRate = 0.1f; 
    private float currentSwingSpeed; 
    private float time;

    void Start()
    {
        _bezierCurve = GetComponent<BezierCurve>();
        currentSwingSpeed = initialSwingSpeed;
    }

    void FixedUpdate()
    {
        ControlPointsMovement();
        FireBallsMovement();
        time += Time.fixedDeltaTime;
    }

    void FireBallsMovement()
    {
        for (int i = 0; i < fireBalls.childCount; i++)
        {
            float si = (float)i / (fireBalls.childCount - 1f);
            fireBalls.GetChild(i).position = _bezierCurve.Bezier(si);
        }
    }

    void ControlPointsMovement()
    {
        float z1 = _bezierCurve.P[1].position.z;
        float z2 = _bezierCurve.P[2].position.z;
        _bezierCurve.P[1].position = CirclePath(5f, z1);
        _bezierCurve.P[2].position = CirclePath(5f, z2);
        UpdateSwingSpeed();
    }

    void UpdateSwingSpeed()
    {
        currentSwingSpeed += swingSpeedIncreaseRate * Time.fixedDeltaTime;
    }

    Vector3 CirclePath(float radius, float zCoordinate)
    {
        float xCoordinate = radius * Mathf.Sin(swing * time * currentSwingSpeed);
        float yCoordinate = radius * Mathf.Cos(swing * time * currentSwingSpeed);
        return new Vector3(xCoordinate, yCoordinate, zCoordinate);
    }
}
