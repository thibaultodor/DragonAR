using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragonBehavior : MonoBehaviour
{
    private float speed = 1.0f;
    
    private Camera mainCamera;

    public GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("RotateTowardsCamera", 0, 0.1f);
        Instantiate(player, mainCamera.transform.position, mainCamera.transform.rotation);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        player.transform.SetPositionAndRotation(mainCamera.transform.position, mainCamera.transform.rotation);
    }

    // Définir la fonction RotateTowardsCamera
    void RotateTowardsCamera()
    {
        // Calculer la rotation cible en fonction de la rotation de la caméra
        float targetYRotation = mainCamera.transform.rotation.eulerAngles.y;
        // Interpoler la rotation du gameobject vers la rotation cible
        transform.Rotate(0,-180,0,Space.Self);
        Quaternion currentYRotation = transform.rotation;
        Quaternion targetYRotationQuat = Quaternion.Euler (transform.rotation.x, targetYRotation, transform.rotation.z);
        transform.rotation = Quaternion.Slerp (currentYRotation, targetYRotationQuat, speed * Time.deltaTime);
        transform.Rotate(0,180,0,Space.Self);
        //_ShowAndroidToastMessage(mainCamera.transform.position.ToString());
    }
    
    private void _ShowAndroidToastMessage(string message)
    {
        var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        var unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity == null) return;
        var toastClass = new AndroidJavaClass("android.widget.Toast");
        unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
        {
            var toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity, message, 0);
            toastObject.Call("show");
        }));
    }
}
