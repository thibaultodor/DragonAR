using System.Collections;
using UnityEngine;

public class SmoothAppear : MonoBehaviour
{
    private CanvasGroup _canvasRenderer;
    
    // La durée de l'animation en secondes
    public float durationappear = 1f;

    void Start()
    {
        // Get the CanvasRenderer component of the Image
        _canvasRenderer = GetComponent<CanvasGroup>();
    }

    public IEnumerator AppearCoroutine()
    {
        // On calcule le temps de début et de fin de l'animation
        float startTime = Time.time;
        float endTime = startTime + durationappear;

        // Tant que le temps actuel est inférieur au temps de fin
        while (Time.time < endTime)
        {
            // On calcule le pourcentage de progression de l'animation
            float progress = (Time.time - startTime) / durationappear;

            // On change l'opacité du texte en fonction du pourcentage
            _canvasRenderer.alpha = progress; // On utilise la propriété alpha du composant TextMesh Pro

            // On attend la prochaine frame
            yield return null;
        }

        yield return null;
    }
}
