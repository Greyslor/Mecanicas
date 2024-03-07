using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobilePlatform : MonoBehaviour
{
    public Transform platformA;
    public Transform platformB;
    // Start is called before the first frame update

    [Range(0f, 1f)]
    public float lerpParameter;

    private float time;
    public float frequency;
    public float phase;
    void Start()
    {
        
        //transform.position = Vector3.Lerp(platformA.position, platformB.position, lerpParameter);
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        lerpParameter = 0.5f * (1 + Mathf.Sin(frequency * time - phase));
        transform.position = LerpUwu(platformA.position, platformB.position, lerpParameter);
    }

    Vector3 LerpUwu(Vector3 A, Vector3 B, float s)
    {
        return (B - A) * s + A;
    }
}
