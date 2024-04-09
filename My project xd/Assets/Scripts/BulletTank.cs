using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTank : MonoBehaviour
{
    public LayerMask barrierLayer;
    private int collisionCount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrier"))
        {
            Debug.Log("Trigger Detected!");
            RaycastHit hit;

            if (Physics.Raycast(transform.position - 0.5f * transform.forward, transform.forward, out hit, Mathf.Infinity, barrierLayer))
            {
                Debug.Log("Raycast emitted!");
                Vector3 normal = (hit.normal).normalized;
                Vector3 tangent = Vector3.Cross(normal, Vector3.up).normalized;
                Vector3 velocity = GetComponent<Rigidbody>().velocity;

                float Vn = Vector3.Dot(velocity, normal);
                float Vt = Vector3.Dot(velocity, tangent);

                Vector3 newVelocity = Vt * tangent - Vn * normal;
                transform.rotation = Quaternion.LookRotation(newVelocity, Vector3.up);
                GetComponent<Rigidbody>().velocity = newVelocity;

            }
        }
    }
}
