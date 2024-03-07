using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public void DestroyTarget()
    {
        // Perform target destruction logic here
        // For example, play an explosion animation and sound
        // You can also add a score increment or any other game-specific logic

        Destroy(gameObject); 
    }
}
