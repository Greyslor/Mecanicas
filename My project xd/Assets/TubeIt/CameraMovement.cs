using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    
    void Update()
    {
        float dt = Time.deltaTime;
        transform.Translate(speed * transform.forward * dt, Space.World);
    }
}
