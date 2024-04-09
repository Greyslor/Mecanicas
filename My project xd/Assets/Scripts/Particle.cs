using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public float t;
    public Vector3 P0, V0;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        transform.position = Kinematic.MovimientoRectilineoUniforme(t, P0, V0);
    }
}
