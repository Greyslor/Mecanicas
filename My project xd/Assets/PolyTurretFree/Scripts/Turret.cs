using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform axisY;
    public Transform axisX;
    public float rotSpeed;
    float angleX;

    public float bulletSpeed;
    public Transform shootPoint;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Vector3 pos = shootPoint.position;
            Quaternion rot = shootPoint.localRotation;

            GameObject bullet = Instantiate(bulletPrefab, pos, rot);
            bullet.GetComponent<KinematicBullet>().P0 = pos;
            bullet.GetComponent<KinematicBullet>().V0 = bulletSpeed * shootPoint.forward;
        }
        HorizontalRotation();
        VerticalRotation();
    }

    void HorizontalRotation()
    {
        float dt = Time.deltaTime;
        float hInput = Input.GetAxis("Horizontal");
        float angle = rotSpeed * hInput * dt;
        Vector3 eulerAngles = new Vector3(0, angle, 0);
        axisY.Rotate(eulerAngles, Space.Self);
    } 
    void VerticalRotation()
    {
        float dt = Time.deltaTime;
        float vInput = Input.GetAxis("Vertical");
        angleX -= rotSpeed * vInput * dt;
        angleX = Mathf.Clamp(angleX, -90f, 0f);
        axisX.localRotation = Quaternion.Euler(angleX, 0, 0);
    }

}
