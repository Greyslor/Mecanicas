using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicBullet : MonoBehaviour
{
    public Vector3 P0, V0;
    float t;

    public GameObject destructionEffectPrefab; // Reference to the destruction effect prefab

    void Update()
    {
        t += Time.deltaTime;
        transform.position = ParabolicShot.Position(t, P0, V0);
        transform.forward = ParabolicShot.Velocity(t, P0, V0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Target target = collision.gameObject.GetComponent<Target>();
        if (target != null)
        {
            // Perform target destruction logic
            target.DestroyTarget();

            // Instantiate destruction effect
            Instantiate(destructionEffectPrefab, target.transform.position, Quaternion.identity);

            // Destroy the bullet
            Destroy(gameObject);
        }
        else
        {
            // If the bullet hits something else, just destroy it immediately
            Destroy(gameObject);
        }
    }
}
