using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileNumeric : MonoBehaviour
{
    public Vector3 Pcurrent, Vcurrent;
    public float m;
    private Vector3 F, Pnext, Vnext;

    // Update is called once per frame
    void FixedUpdate()
    {
        F = m * new Vector3(0, -9.81f, 0f);
        float dt = Time.deltaTime;
        Pnext = Pcurrent + dt * Vcurrent;
        Vnext = Vcurrent + dt * F/m;

        transform.position = Pnext;
        Pcurrent = Pnext;
        Vcurrent = Vnext;
    }
}
