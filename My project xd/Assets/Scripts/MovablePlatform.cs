using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    public float travelTime;
    public Transform A;
    public Transform B;

    float speed, time;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = A.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceAB = (B.position - A.position).magnitude;
        speed = distanceAB / travelTime;
        Vector3 direction = (B.position - A.position).normalized;
        Vector3 P0 = A.position;
        Vector3 V0 = speed * direction;
        time += Time.deltaTime;
        transform.position = Kinematic.MovimientoRectilineoUniforme(time, P0, V0);
    }
}
