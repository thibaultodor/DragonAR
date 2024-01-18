using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MagicPigGames;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonController : MonoBehaviour
{
    public int lifePoint = 100;
    
    private Animator myAnimator;

    private ProgressBar HP_bar;

    private List<GameObject> list_HitPoints;

    private List<int> destroyed_hitpoints;
    
    private int activeIndex = -1;

    public bool end_entrance;
    
    private Text_Entrance_Lose_Win win_text;
    
    private TouchManager touchmanager;

    private bool stopshowinghit = false;
    
    
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        touchmanager = GameObject.Find("TouchManager").GetComponent<TouchManager>();
        win_text = GameObject.FindWithTag("UI_Win").GetComponent<Text_Entrance_Lose_Win>();
        HP_bar = GameObject.FindWithTag("UI_PV").GetComponent<ProgressBar>();
        list_HitPoints = new List<GameObject>();
        list_HitPoints = GameObject.FindGameObjectsWithTag("HitPoint").ToList();
        foreach (GameObject enemy in list_HitPoints) { enemy.SetActive(false); }
        destroyed_hitpoints = new List<int>();
        InvokeRepeating(nameof(SwitchHitPoint), 0, 3);
    }

    private void Update()
    {
        if (lifePoint != 0) return;
        myAnimator.Play("Die");
        
        touchmanager.gameObject.SetActive(false);
        
        win_text.StartCoroutine("ScaleAnimation");

        if (transform.localPosition.y > -0.20)
        {
            transform.Translate(0, -0.001f, 0);
        }
        else
        {
            GetComponent<DragonScrunch>().StartCoroutine("ScrunchCoroutineMenu");
        }
    }

    public void Hit(int nbDammage)
    {
        lifePoint -= nbDammage;
        if (lifePoint < 0) { lifePoint = 0; }
        var hp = lifePoint / 100f;
        HP_bar.SetProgress(hp);
        destroyed_hitpoints.Add(activeIndex);
        activeIndex = -1;
    }

    public void SwitchHitPoint()
    {
        if (stopshowinghit) {
            foreach (var VARIABLE in list_HitPoints) { VARIABLE.SetActive(false); }
            return; }
        if(!end_entrance)return;
        if (activeIndex != -1) { list_HitPoints[activeIndex].SetActive(false); }

        var newIndex = Random.Range(0, list_HitPoints.Count);
        while (destroyed_hitpoints.Contains(newIndex)) { newIndex = Random.Range(0, list_HitPoints.Count); }
        
        list_HitPoints[newIndex].SetActive(true);
        activeIndex = newIndex;
    }
}
