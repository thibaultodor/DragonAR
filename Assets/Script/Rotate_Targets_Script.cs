using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class Rotate_Targets_Script : MonoBehaviour
{
    // Le composant AR Tracked Object Manager
    private ARTrackedImageManager manager;

    private int nbenfants = -1;

    private int sens = 1;
    
    // Update is called once per frame
    private void Update()
    {
        nbenfants = transform.childCount;
        
        if (nbenfants % 2 == 0) { sens = 1; }
        else { sens = -1; }
        
        transform.Rotate (0, (25*(9-nbenfants))*Time.deltaTime*sens, 0);
    }

    public int getNbEnfants()
    {
        return nbenfants;
    }
}
