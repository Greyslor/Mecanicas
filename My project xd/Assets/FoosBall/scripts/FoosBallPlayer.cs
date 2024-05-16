using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoosBallPlayer : MonoBehaviour
{
    public string verticalInputName;
    public float impulse, drag;
    public Rigidbody cubeRb;
    private float verticalInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxisRaw(verticalInputName);
    }

    void FixedUpdate()
    {
        cubeRb.drag = drag;
        Vector3 force = -impulse * Vector3.right * verticalInput;
        cubeRb.AddForce(force, ForceMode.VelocityChange);
    }
}
