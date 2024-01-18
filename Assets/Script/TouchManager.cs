using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TouchManager : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerInput _playerInput;

    private InputAction touchpositionAction;
    private InputAction touchpressAction;
    
    // Le prefab du projectile à instancier
    public GameObject projectilePrefab;

    // La vitesse du projectile
    public float projectileSpeed;

    // La position du centre de l'écran
    private Vector3 screenCenter;

    // La caméra principale
    private Camera mainCamera;

    // The timer variable
    private float nextFire = 0f;

    // The delay between shots
    public float fireRate;
    
    private void Awake()
    {
        // On récupère la caméra principale
        mainCamera = Camera.main;
        // On calcule la position du centre de l'écran en pixels
        screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        _playerInput = GetComponent<PlayerInput>();
        touchpressAction = _playerInput.actions.FindAction("TouchPress");
    }

    private void Update()
    {
        if (!touchpressAction.WasPerformedThisFrame() || !(Time.time > nextFire)) return;
        // Update the next fire time by adding the fire rate
        nextFire = Time.time + fireRate;
            
        // On crée un rayon depuis la caméra vers la position du toucher
        Ray ray = mainCamera.ScreenPointToRay(screenCenter);

        // On instancie un projectile à la position du centre de l'écran
        GameObject projectile = Instantiate(projectilePrefab, mainCamera.ScreenToWorldPoint(screenCenter),
            Quaternion.identity);

        // On ajoute un composant Rigidbody au projectile pour lui appliquer la physique
        var rb = projectile.AddComponent<Rigidbody>();

        // On ajoute une force au projectile dans la direction du rayon
        rb.AddForce(ray.direction * projectileSpeed, ForceMode.Impulse);

        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
    }
}
