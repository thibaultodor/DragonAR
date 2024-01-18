using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DestroyOnCollision : MonoBehaviour
{
    private DragonController dragon;
    
    void Start()
    {
        dragon = GameObject.FindWithTag("Dragon").GetComponent<DragonController>();
    }
    
    // Cette fonction est appelée quand le gameobject entre en collision avec un autre gameobject
    private void OnCollisionEnter(Collision collision)
    {
        // Si le gameobject qui a causé la collision a le tag Bullet
        if (!collision.gameObject.CompareTag("Bullet")) return;
        
        if (gameObject.CompareTag("HitPoint")) { dragon.Hit(20);Destroy(gameObject); }
        else { Destroy(transform.parent.gameObject); }
        Destroy(collision.gameObject);
    }
}
