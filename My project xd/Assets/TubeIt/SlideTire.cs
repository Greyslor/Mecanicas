using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideTire : MonoBehaviour
{
    public string horizontalInputName, verticalInputName;
    public float forceMagnitude, jumpMagnitude, torqueMagnitude;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float hInput = Input.GetAxis(horizontalInputName);
        float vInput = Input.GetAxis(verticalInputName);
        float dt = Time.deltaTime;
        Vector3 force = forceMagnitude * new Vector3 (hInput, 0, vInput);
        GetComponent<Rigidbody>().AddForce(force * dt, ForceMode.Force);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ramp"))
        {
            Vector3 jumpForce = jumpMagnitude * transform.up;
            GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Force);
            print("Ramp");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BowLimit"))
        {
            float forceMagnitude = 1;
            float torqueMagnitude = 1;
            Vector3 force = forceMagnitude * (transform.position).normalized;
            rb.AddForce(force, ForceMode.Impulse);
            Vector3 torque = torqueMagnitude * Random.onUnitSphere;
            rb.AddTorque(torque, ForceMode.Impulse);
        }

    }
}
