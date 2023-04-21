using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
public Camera mainCamera;
 Vector3 cameraPos;

 [SerializeField] float shakeRange = 0.05f;
 [SerializeField] float duration = 0.5f;


public void Shake(){
    cameraPos = mainCamera.transform.position;
    InvokeRepeating("Shaking",0f,0.005f);
    Invoke("StopShake",duration);
}

void Shaking(){
    float cameraPosX = Random.value * shakeRange * 2 - shakeRange;
    float cameraPosY = Random.value * shakeRange * 2 - shakeRange;
    Vector3 cameraPos = mainCamera.transform.position;
    cameraPos.x += cameraPosX;
    cameraPos.y += cameraPosY;
    mainCamera.transform.position = cameraPos;
}
void StopShake(){
    CancelInvoke("Shaking");
    mainCamera.transform.position = cameraPos;
}
}
