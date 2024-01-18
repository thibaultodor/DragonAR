using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Cette fonction est appelée lorsque le script est activé
    void Start()
    {
        // Détruit le GameObject après 5 secondes
        Destroy(gameObject, 5f);
    }
    
    // The particle system prefab to instantiate
    public GameObject particlePrefab;

    // The delay for destroying the particle system copy
    public float destroyDelay = 1f;

    // This method is called when the game object is destroyed
    void OnDestroy()
    {
        // Instantiate a copy of the particle system prefab at the same position and rotation as the game object
        GameObject particleCopy = Instantiate(particlePrefab, transform.position, transform.rotation);

        // Destroy the particle system copy after the delay
        Destroy(particleCopy, destroyDelay);
    }
}