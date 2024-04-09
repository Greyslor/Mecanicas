using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RollRunnerController : MonoBehaviour
{
    public float angularSpeed, radius;
    private float xPosition, angle;
    private bool isPlaying = true;
    private AudioSource audioSource; // Agrega referencia al AudioSource

    // Start is called before the first frame update
    private void Start()
    {
        xPosition = transform.localPosition.x;
        GetComponent<Rigidbody>().isKinematic = true;

        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying)
        {
            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        float verticalInput = Input.GetAxis("Horizontal");
        angle += angularSpeed * verticalInput * Time.deltaTime;
        transform.localPosition = AngularPosition();

        Vector3 up = AngularPosition();
        up.x = 0;
        Vector3 forward = Vector3.zero;

        if (verticalInput >= 0)
        
            forward = Vector3.Cross(Vector3.right, up);
        else 
            forward = -Vector3.Cross(Vector3.right, up);

        transform.localRotation = Quaternion.LookRotation(forward, up);
    }

    Vector3 AngularPosition()
    {
        float y = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float z = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

        return new Vector3(xPosition, y, z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Limit"))
        {
            Debug.Log("Outside");
            Vector3 radialPosition = AngularPosition();
            radialPosition.x = 0;

            Vector3 slipDirection = Vector3.zero;
            if (transform.position.z < 0)
                slipDirection = Vector3.Cross(radialPosition, Vector3.right).normalized;
            else
                slipDirection = -Vector3.Cross(radialPosition, Vector3.right).normalized;

            transform.parent = null;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(5 * slipDirection, ForceMode.Impulse);
            isPlaying = false;

            if (audioSource != null && audioSource.clip != null)
            {
                audioSource.Play();
                Debug.Log("KYYYYYAAAA");
            }
        }
    }
}
