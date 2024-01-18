using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private Rotate_Targets_Script target_rotates_cript;

    private int lvl_index = 1;

    private GameObject lv1;
    private GameObject lv2;

    private void Start()
    {
        var targetcontain = GameObject.Find("Targets_Container");
        target_rotates_cript = targetcontain.GetComponent<Rotate_Targets_Script>();
        
        lv1 = GameObject.FindWithTag("LV1");
        lv2 = GameObject.FindWithTag("LV2");
        lv2.SetActive(false);
    }
    
    private void Update()
    {
        if (target_rotates_cript.getNbEnfants() != 0 || lvl_index != 1) return;
        lv1.SetActive(false);
        lv2.SetActive(true);
        lvl_index = 2;
        Destroy(lv1);
    }
}
