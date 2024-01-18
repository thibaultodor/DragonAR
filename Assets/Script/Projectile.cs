using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Le composant Trail Renderer
    public TrailRenderer trail;

    // La vitesse du projectile
    public float speed = 10f;

    // La direction du projectile
    public Vector3 direction = Vector3.forward;

    void Start()
    {
        // Si le composant Trail Renderer n'est pas assigné, on le crée et on l'attache à l'objet
        if (trail == null)
        {
            trail = gameObject.AddComponent<TrailRenderer>();
            trail.material = new Material(Shader.Find("Sprites/Default")); // Le matériel de la traînée
            trail.startColor = Color.red; // La couleur de départ de la traînée
            trail.endColor = Color.yellow; // La couleur de fin de la traînée
            trail.startWidth = 0.1f; // La largeur de départ de la traînée
            trail.endWidth = 0f; // La largeur de fin de la traînée
            trail.time = 1f; // La durée de la traînée
        }
    }
}