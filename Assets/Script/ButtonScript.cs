using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonScrunch : MonoBehaviour
{
    // Les objets Scrunch1 et Scrunch2 à animer
    public Transform Scrunch1;
    public Transform Scrunch2;

    // La hauteur maximale à atteindre par les objets
    private float MaxHeight = 650f;

    // La vitesse de déplacement des objets
    private float Speed = 5000f;

    // La durée de l'attente après l'animation
    private float WaitTime = 0.1f;

    // La scène à charger après l'animation
    private string NextScene = "DragonAR";

    private void Start()
    {
        if (Scrunch1.IsUnityNull())
        {
            Scrunch1 = GameObject.FindGameObjectsWithTag("Scrunch")[0].transform;
            Scrunch2 = GameObject.FindGameObjectsWithTag("Scrunch")[1].transform;
        }
    }

    // La coroutine qui fait l'animationS
    private IEnumerator ScrunchCoroutineStart()
    {
        // Tant que les objets n'ont pas atteint la hauteur maximale
        while (Scrunch1.position.y < MaxHeight)
        {
            // Déplacer les objets vers le haut à la vitesse indiquée
            Scrunch1.Translate(0, Speed * Time.deltaTime, 0);
            Scrunch2.Translate(0, Speed * Time.deltaTime, 0);

            // Attendre la fin de la frame
            yield return null;
        }

        // Attendre le temps indiqué
        yield return new WaitForSeconds(WaitTime);

        // Charger la scène suivante
        SceneManager.LoadScene(NextScene);
    }
    
    private IEnumerator ScrunchCoroutineMenu()
    {
        // Tant que les objets n'ont pas atteint la hauteur maximale
        while (Scrunch1.position.y < MaxHeight)
        {
            // Déplacer les objets vers le haut à la vitesse indiquée
            Scrunch1.Translate(0, Speed * Time.deltaTime, 0);
            Scrunch2.Translate(0, Speed * Time.deltaTime, 0);

            // Attendre la fin de la frame
            yield return null;
        }

        // Attendre le temps indiqué
        yield return new WaitForSeconds(WaitTime);

        // Charger la scène suivante
        SceneManager.LoadScene("Menu");
    }
    
    private IEnumerator ScrunchCoroutineQuit()
    {
        // Tant que les objets n'ont pas atteint la hauteur maximale
        while (Scrunch1.position.y < MaxHeight)
        {
            // Déplacer les objets vers le haut à la vitesse indiquée
            Scrunch1.Translate(0, Speed * Time.deltaTime, 0);
            Scrunch2.Translate(0, Speed * Time.deltaTime, 0);

            // Attendre la fin de la frame
            yield return null;
        }

        // Attendre le temps indiqué
        yield return new WaitForSeconds(WaitTime);

        // Charger la scène suivante
        Application.Quit();
    }

    // La méthode qui s'exécute au démarrage du script
    private void StartGame()
    {
        StartCoroutine("ScrunchCoroutineStart");
    }
    
    private void QuitGame()
    {
        StartCoroutine("ScrunchCoroutineQuit");
    }
}