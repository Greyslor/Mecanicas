using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float torqueMagnitude, forceMagnitude;
    public float rotSpeed, bulletSpeed;
    public Transform turret, shootPoint;
    public GameObject bulletPrefab;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        TankMovement();
        TurretRotation();
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Fire();
        }
    }

    void TankMovement()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal-P1");
        float vInput = Input.GetAxis("Vertical-P1");

        Vector3 torque = torqueMagnitude * transform.up * hInput * dt;
        rb.AddTorque(torque, ForceMode.Force);

        Vector3 force = forceMagnitude * transform.forward * vInput * dt;
        rb.AddForce(force, ForceMode.Force);
    }

    void TurretRotation()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal-P2");
        float angle = rotSpeed * hInput * dt;
        Vector3 eulerAngles = new Vector3(0, angle, 0);
        turret.Rotate(eulerAngles, Space.Self);
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * shootPoint.forward;
    }
}
