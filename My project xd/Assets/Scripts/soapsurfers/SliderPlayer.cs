using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPlayer : MonoBehaviour
{
    public string horizontalInputName, verticalInputName;
    public float forceMagnitude, torqueMagnitude;
    public LayerMask bowlLayer;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovementControl();
        RotationRectification();
    }

    void MovementControl()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis(horizontalInputName);
        float vInput = Input.GetAxis(verticalInputName);

        Vector3 Inputdir = new Vector3(hInput, 0, vInput).normalized;
        Vector3 newDir = Inputdir - Vector3.Dot(Inputdir, transform.up) * transform.up;
        Vector3 force = forceMagnitude * newDir * dt;
        rb.AddForce(force, ForceMode.Force);
    }

    void RotationRectification()
    {   
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10, bowlLayer)) 
        {
            Vector3 newUp = hit.normal;
            Vector3 newForward = transform.forward - Vector3.Dot(transform.forward, newUp) * newUp;
            transform.rotation = Quaternion.LookRotation(newForward, newUp);
        }
    }
}
