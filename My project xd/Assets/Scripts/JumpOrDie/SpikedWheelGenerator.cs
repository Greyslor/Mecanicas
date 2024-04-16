using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedWheelGenerator : MonoBehaviour
{
    public GameObject wheelPrefab;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject wheel = Instantiate(wheelPrefab, transform.position, Quaternion.identity);
            Vector3 velocity = speed * transform.right;
            wheel.GetComponent<Rigidbody>().velocity = velocity;
            wheel.GetComponent<Rigidbody>().angularVelocity = new Vector3(0,0, -speed/1f);
        }
    }
}
