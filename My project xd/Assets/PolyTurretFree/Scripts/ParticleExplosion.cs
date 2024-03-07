using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExplosion : MonoBehaviour
{
    public Vector3 initialPosition, initialVelocity;
    public GameObject particlePrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject particle = Instantiate(particlePrefab, initialPosition, Quaternion.identity);
            particle.GetComponent<Particle>().P0 = Random.onUnitSphere;
            particle.GetComponent<Particle>().V0 = Random.onUnitSphere;
            Destroy(particle, 5f);
        }

        //Random.onUnitSphere
        //Random.insideUnitSphere
    }
}
