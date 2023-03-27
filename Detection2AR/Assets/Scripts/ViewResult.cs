using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System;


public class ViewResult : MonoBehaviour
{
    public GameObject ToRecordButton;
    public GameObject RecordingButton;
    public GameObject LoadingViewPanel;
    public Image LoadingImage;
    public float zSpeed = 0.0f;

    public void StartRecording()
    {
        RecordingButton.SetActive(true);
        ToRecordButton.SetActive(false);
    }

    public void StopRecording()
    {
        ToRecordButton.SetActive(true);
        RecordingButton.SetActive(false);
        LoadingView();
        
        //JumpToResult();
    }

    private void TakeVideo()
    {

    }

    public void LoadingView()
    {    
        LoadingViewPanel.SetActive(true);
    }

   
    float lerpDuration = 0.5f;
    IEnumerator Rotate90()
    {
        
        float timeElapsed = 0;
        Quaternion startRotation = LoadingImage.transform.rotation;
        Quaternion targetRotation = LoadingImage.transform.rotation * Quaternion.Euler(0, 0, 60);
        while (timeElapsed < lerpDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        LoadingImage.transform.rotation = targetRotation;
        
    }

    public void JumpToResult()
    {      
        SceneManager.LoadScene(2); // Load 'Result` scene
    }

    private void CollectObjList()
    {
        // create and fill a new object list for every new scan 
    }

    public void Update()
    {
        // StartCoroutine(Rotate90());
        float rotationSpeed = 30f;
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
    }
}
