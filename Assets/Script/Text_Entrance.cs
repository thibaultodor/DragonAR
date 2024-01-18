using System.Collections;
using UnityEngine;
using TMPro; // On importe le namespace TextMeshPro

public class Text_Entrance : MonoBehaviour
{
    // La taille initiale de l'objet
    private Vector3 originalScale;

    // La taille maximale de l'objet
    public float maxScale = 2f;

    // La durée de l'animation en secondes
    public float durationappear = 2f;
    
    // La durée de l'animation en secondes
    public float durationanimation = 2f;

    // Un booléen pour contrôler l'animation
    private bool isScaling = false;

    // La coroutine qui gère l'animation
    private IEnumerator scaleCoroutine;

    // Le composant TextMesh Pro de l'objet
    private TMP_Text textMesh; // On déclare une variable de type TMP_Text

    // La fonction Awake est appelée avant le Start
    private void Awake()
    {
        // On sauvegarde la taille initiale de l'objet
        originalScale = transform.localScale;

        // On récupère le composant TextMesh Pro de l'objet
        textMesh = GetComponent<TMP_Text>(); // On utilise GetComponent avec le type TMP_Text
    }

    // La fonction ScaleAnimation est une coroutine qui gère l'animation
    public IEnumerator ScaleAnimation()
    {
        // On indique que l'objet est en train de s'agrandir ou de rapetisser
        isScaling = true;

        // On calcule le temps de début et de fin de l'animation
        float startTime = Time.time;
        float endTime = startTime + durationappear;
        
        // Tant que le temps actuel est inférieur au temps de fin
        while (Time.time < endTime)
        {
            // On calcule le pourcentage de progression de l'animation
            float progress = (Time.time - startTime) / durationappear;
            
            // On change l'opacité du texte en fonction du pourcentage
            textMesh.alpha = progress; // On utilise la propriété alpha du composant TextMesh Pro
            
            // On attend la prochaine frame
            yield return null;
        }
        
        // On attend 2 secondes
        yield return new WaitForSeconds(1f);
        
        startTime = Time.time;
        endTime = startTime + durationanimation;

        // Tant que le temps actuel est inférieur au temps de fin
        while (Time.time < endTime)
        {
            // On calcule le pourcentage de progression de l'animation
            float progress = (Time.time - startTime) / durationanimation;

            // On calcule la taille intermédiaire de l'objet en fonction du pourcentage
            float scale = Mathf.Lerp(originalScale.x, maxScale, progress);

            // On applique la nouvelle taille à l'objet
            transform.localScale = new Vector3(scale, scale, scale);

            // On change la couleur du texte en fonction du pourcentage
            textMesh.color = Color.Lerp(Color.white, Color.red, progress); // On utilise la propriété color du composant TextMesh Pro

            // On change l'opacité du texte en fonction du pourcentage
            textMesh.alpha = 1 - progress; // On utilise la propriété alpha du composant TextMesh Pro
            
            // On attend la prochaine frame
            yield return null;
        }
        
        Destroy(gameObject);
    }
}
