using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic
{
    public static Vector3 MovimientoRectilineoUniforme(float time, Vector3 initialPosition, Vector3 initialVelocity)
    {
        return initialVelocity * time + initialPosition;
    }
}
