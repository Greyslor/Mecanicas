using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperPlayer : MonoBehaviour
{
    [Range(0, 20)] public float jumpImpulse;
    [Range(-20, -1)] public float gravity;
    public KeyCode keyCode;
    private bool grounded;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);
        if (grounded && Input.GetKeyDown(keyCode))
            rb.AddForce(jumpImpulse * transform.up, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            grounded = false;
        }
    }
}
