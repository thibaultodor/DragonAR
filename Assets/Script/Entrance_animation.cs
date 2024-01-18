using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Entrance_animation : MonoBehaviour
{
    private TouchManager touchmanager;

    private bool end_entrance;
    
    private Animator myAnimator;

    private Text_Entrance fight_text;
    
    private Text_Entrance_Lose_Win lose_text;

    private SmoothAppear pv_dragon;

    private DragonController _dragonController;
    
    private TMP_Text timerText; // The UI text element to show the timer
    private CanvasGroup timerText_render; // The UI text element to show the timer
    
    public float timeLimit = 30f; // The time limit in seconds
    
    private bool canPlay = true; // A flag to check if the game is still playable

    private RawImage cible;

    private void Start()
    {
        touchmanager = GameObject.Find("TouchManager").GetComponent<TouchManager>();
        myAnimator = GetComponent<Animator>();
        _dragonController = GetComponent<DragonController>();
        fight_text = GameObject.FindWithTag("UI_Fight").GetComponent<Text_Entrance>();
        lose_text = GameObject.FindWithTag("UI_Lose").GetComponent<Text_Entrance_Lose_Win>();
        pv_dragon = GameObject.FindWithTag("UI_PV").GetComponent<SmoothAppear>();
        timerText = GameObject.FindWithTag("Time_Text").GetComponent<TMP_Text>();
        timerText_render = GameObject.FindWithTag("Time_Text").GetComponent<CanvasGroup>();
        cible = GameObject.FindWithTag("Cible").GetComponent<RawImage>();
    }

    private void Update()
    {
        if(end_entrance)return;
        if (transform.localPosition.y < -0.005)
        {
            transform.Translate(0, 0.001f, 0);
            touchmanager.gameObject.SetActive(false);
            cible.canvasRenderer.SetAlpha(0f);
        }
        else
        {
            transform.localPosition = new Vector3(0, -0.005f, 0);
            fight_text.StartCoroutine("ScaleAnimation");
            myAnimator.Play("Scream");
            pv_dragon.StartCoroutine("AppearCoroutine");
            touchmanager.gameObject.SetActive(true);
            _dragonController.end_entrance=true;
            StartCoroutine("TimerCoroutine");
            cible.canvasRenderer.SetAlpha(1f);
            end_entrance = true;
        }
    }
    
    IEnumerator TimerCoroutine()
    {
        if (!timerText.gameObject.activeSelf)
        {
            timerText_render.alpha = 0f;
        }

        timerText_render.alpha = 1f;
        
        // Loop until the time limit is reached
        while (timeLimit > 0f)
        {
            // Update the timer text
            timerText.SetText(timeLimit.ToString("F0"));

            // Wait for one frame
            yield return null;

            // Subtract the time elapsed since the last frame
            timeLimit -= Time.deltaTime;
        }

        if (touchmanager.isActiveAndEnabled)
        {
            touchmanager.gameObject.SetActive(false);
            lose_text.StartCoroutine("ScaleAnimation");
            yield return new WaitForSeconds(2f);
            GetComponent<DragonScrunch>().StartCoroutine("ScrunchCoroutineMenu");
        }
    }
}
