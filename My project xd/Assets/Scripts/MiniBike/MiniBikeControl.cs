using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MiniBikeControl : MonoBehaviour
{
    public float forceMagnitude;
    [Range(0f, 10f)] public float drag;
    public Transform[] bikeParts;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.drag = drag;
        if(Input.GetMouseButtonDown(0))
        {
            float dt = Time.deltaTime;
            Vector3 appliedForce = forceMagnitude * transform.forward * dt;
            rb.AddForce(appliedForce, ForceMode.Force);
        }

        float speed =rb.velocity.magnitude;
        float angularSpeed = speed / 0.29f;
        float angle = Mathf.Rad2Deg * Time.deltaTime * angularSpeed;
        for (int i = 0; i < bikeParts.Length; i++)
        {
            bikeParts[i].Rotate(0, 0, angle, Space.Self);
        }

    }
}
