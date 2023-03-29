using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;
using System;
using System.IO;
using UnityEditor;
using UnityEngine.Video;


public class ViewResult : MonoBehaviour
{
    public GameObject RawImage;
    public VideoPlayer MyVideoPlayer;
    public GameObject ToRecordButton;
    public GameObject RecordingButton;
    public GameObject LoadingViewPanel;
    public Image LoadingImage;

    public string VideoFolderPath => "Assets/Video";
    public static string VideoPath;

    #region Record and Save Video

    public void StartRecording()
    {
        RecordingButton.SetActive(true);
        ToRecordButton.SetActive(false);
        RawImage.SetActive(true);
        MyVideoPlayer.Play();
        
        TakeVideo();
    }

    public void StopRecording()
    {
        ToRecordButton.SetActive(true);
        RecordingButton.SetActive(false);
        MyVideoPlayer.Stop();
       
        StopVideo();
        LoadingView();
        RawImage.SetActive(false);
        //VideoImage.SetActive(true);
    }

    private void TakeVideo()
    {
        //if (!Directory.Exists(VideoFolderPath))
        //{
        //    DirectoryInfo videoDirect = Directory.CreateDirectory(VideoFolderPath);
        //    Debug.Log($"videoDirect = {videoDirect.FullName}");
        //}

        //if (!AssetDatabase.IsValidFolder(VideoFolderPath))
        //{
        //    AssetDatabase.CreateFolder("Assets", "Video");
        //    Debug.Log($"Video folder created.");
        //}


        // Start recording video
    }

    private void StopVideo()
    {
        // Stop recording video
        // Save video

        // // Change "3/27/2023 2:36:15 PM" to "3-27-2023_2-37-15_PM" in order to avoid invalid characters in file name
        //string today = DateTime.Now.ToString("G").Replace("/","-").Replace(":","-").Replace(" ", "_");
        //VideoPath = $@"{VideoFolderPath}/{today}.MOV"; // Or use other file extensions
        //FileStream fs = new FileStream(VideoPath, FileMode.Create, FileAccess.Write);
        //Byte[] videoData = ...;
        //fs.Write(videoData, 0, videoData.Length);
    }

    #endregion

    #region Frontend-Backend Communication

    public static string GetVideoPath()
    {
        return VideoPath;
    }

    public void LoadingView()
    {   
        LoadingViewPanel.SetActive(true);
        // Temporary set for demo. Change Later!!!
        VideoPath = $@"{VideoFolderPath}/3-27-2023_3-40-22_PM.MOV";
    }

    /* Backend Tasks
     * 
     * 1. Extract a list of representative images from the video (15th image in 30 frames/sec)
     *    - for example, if the video has 3 seconds, in each second there are 30 frames, get the 15th image from each second
     *    - to obtain the video, use given `VideoPath` (refer to line 83)
     * 
     * 2. Run object detection model and get a list of detected objects
     * 
     * 3. For each detected object, create a `DetectedObject` class object, assign values according to `DetectedObject.cs`
     *    - Every public member in `DetectedObject.cs` needs to be assigned value
     *    - Except `DetectedObjectList` and `ListCompleted` are assigned later in step 4
     * 
     * 4. Put all `DetectedObject` class objects in the List<DetectedObject> DetectedObjectList
     *    - List<DetectedObject> DetectedObjectList is a public static object in `DetectedObject.cs`
     *    - Boolean `ListCompleted` is a public static object in `DetectedObject.cs`
     *    
     *    - For each video, 
     *          - a. initialize the list and set list completion status to false using syntax:
     *              - "DetectedObject.DetectedObjectList = new List<DetectedObject>();"
     *              - "DetectedObject.ListCompleted = false;"
     *          - b. then for each created detected object `obj`, add it to the list using syntax:
     *              - "DetectedObject.DetectedObjectList.Add(obj);"
     *          - c. at the end, set the boolean `ListCompleted` in `DetectedObject.cs` to true:
     *              - "DetectedObject.ListCompleted = true;"
     *              
     * After the 4 tasks, the frontend would have a completed detected objects list, and can use each object's info to fill UI
     */

    public void JumpToResult()
    {      
        SceneManager.LoadScene(2); // Temporary code for demo. Detele this line later.

        // Comment below codes for now. Add back later
        //while (!DetectedObject.ListCompleted)
        //{
        //    // Update()
        //    // Keep ratating the image;
        //}
        //SceneManager.LoadScene(2); // Load 'Result` scene
    }

    #endregion

    public void Update()
    {
        float rotationSpeed = 30f;
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(new Vector3(0, 0, rotationAmount));
    }
}
