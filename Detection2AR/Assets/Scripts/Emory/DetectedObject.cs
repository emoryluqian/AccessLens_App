using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DetectedObject : MonoBehaviour
{
    public Type ObjectType;

    public string VideoID; // Each video has a unique video ID, could be its file name
    public int FrameID;    // Each frame in a video has a unique ID

    public float X;
    public float Y;
    public float Width;  // In pixel
    public float Height; // In pixel

    public string FileName; // Cropped image file name
    public string FilePath; // Cropped image file path

    public IndicationType Object_Indication;
    public ActuationType Object_Actuation;
    public ConstraintType Object_Constrain;

    public static List<DetectedObject> DetectedObjectList;
    public static bool ListCompleted;

    #region Static Type Enums

    public enum Type
    {
        hande_round_rotate = 0,
        handle_bar = 1,
        light_switch_toggle = 2
        // Add more in the future
    };

    public enum IndicationType
    {
        visual = 0,
        tactile = 1
        // Add more in the future
    };

    public enum ActuationType
    {
        operation = 0,
        reach = 1
        // Add more in the future
    };

    public enum ConstraintType
    {
        general = 0,
        hazard = 1
        // Add more in the future
    };

    #endregion

    public DetectedObject(Type objType, string videoId, int frameId, float x, float y, float width, float height)
    {
        ObjectType = objType;
        VideoID = videoId;
        FrameID = frameId;
        X = x;
        Y = y;
        Width = width;
        Height = height; 
    }
}
