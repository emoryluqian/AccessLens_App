using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Result : MonoBehaviour
{
    public GameObject ResultPanel;
    public GameObject ExpandResultPanel;
    public GameObject ConfirmRestartPanel;

    // public DetectObject CurrentObj;
    // public List<DetectObject> DetectObjList;
    public int CurrentObjIdx;
    public Text TypeHolder;

    public Image ResultImage;
    public Sprite[] ResultTypeList;
    public Image ObjImage; // Change Later
    public Sprite[] ResultImgList; // Change Later!!
    public Text ActuationHolder;
    public Text ContextHolder;
    public Text DesignHolder;

    private int ObjectIdx = 0; // Change Later!

    #region Result Panel

    void Start()
    {
        ObjImage.sprite = ResultImgList[ObjectIdx];
        TypeHolder.text = "Lamp";
    }

    public void SwipeLeft()
    {
        //if (DetectObjList == null || DetectObjList.Count == 0)
        //{
        //    return;
        //}

        CurrentObjIdx = Math.Max(0, CurrentObjIdx-1);
        ObjectIdx = Math.Max(0, ObjectIdx - 1);
        ObjImage.sprite = ResultImgList[ObjectIdx];

        // Change later!!
        switch (ObjectIdx)
        {
            case 0:
                TypeHolder.text = "Lamp";
                break;
            case 1:
                TypeHolder.text = "Couch";
                break;
            case 2:
                TypeHolder.text = "Table";
                break;
        }
        // CurrentObj = DetectObjList[CurrentObjIdx];
        // TypeHolder.text = CurrentObj.Label;
    }

    public void SwipeRight()
    {
        //if (DetectObjList == null || DetectObjList.Count == 0)
        //{
        //    return;
        //}

        ObjectIdx = Math.Min(2, ObjectIdx + 1);
        ObjImage.sprite = ResultImgList[ObjectIdx];
        // Change later!!
        switch (ObjectIdx)
        {
            case 0:
                TypeHolder.text = "Lamp";
                break;
            case 1:
                TypeHolder.text = "Couch";
                break;
            case 2:
                TypeHolder.text = "Table";
                break;
        }
        // CurrentObjIdx = Math.Max(DetectObjList.Count - 1, CurrentObjIdx + 1);
        // CurrentObj = DetectObjList[CurrentObjIdx];
        // TypeHolder.text = CurrentObj.Label;
    }

    public void ClickEye()
    {
        ResultImage.sprite = ResultTypeList[0];
        ExpandResult();
    }

    public void ClickHand()
    {
        ResultImage.sprite = ResultTypeList[1];
        ExpandResult();
    }

    public void ClickWarning()
    {
        ResultImage.sprite = ResultTypeList[2];
        ExpandResult();
    }

    public void ExpandResult() // Add parameter later
    {
        Expand(); // Add parameter later
        ExpandResultPanel.SetActive(true);
    }

    private void Expand() // Add parameter later
    {
        
        // pull out result information to expand result
    }

    #endregion


    #region Expand Result Panel

    

    public void BackToResult()
    {
        ResultPanel.SetActive(true);
        ExpandResultPanel.SetActive(false);
    }

    #endregion


    #region Confirm Restart Panel

    public void Restart()
    {
        ConfirmRestartPanel.SetActive(true);
    }

    public void Cancel()
    {
        ConfirmRestartPanel.SetActive(false);
    }

    public void Confirm()
    {
        //ConfirmRestartPanel.SetActive(false);
        //ExpandResultPanel.SetActive(false);
        SceneManager.LoadScene(1); // Load the `Detect` scene

    }

    #endregion

}
