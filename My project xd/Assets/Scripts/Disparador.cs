using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject balaPrefab;
    public float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            GameObject bala = Instantiate(balaPrefab, pos, rot);

            Vector3 direction = (target.position-transform.position).normalized;
            bala.GetComponent<Rigidbody>().velocity = speed*direction;
        } 
    }
}
