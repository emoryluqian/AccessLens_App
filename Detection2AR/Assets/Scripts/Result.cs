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

    // public Image ResultImage;
    public Text Type1;
    public Text Type2;
    public Sprite[] ResultTypeList;
    public Image ObjImage; // Change Later
    public Sprite[] ResultImgList; // Change Later!!

    private int ObjectIdx = 0; // Change Later!

    #region Result Panel

    void Start()
    {
        ObjImage.sprite = ResultImgList[ObjectIdx];
        // Change later!!
        TypeHolder.text = "handle-round_rotate";
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
        TypeHolder.text = GetTypeName(ObjectIdx);
        // CurrentObj = DetectObjList[CurrentObjIdx];
        // TypeHolder.text = CurrentObj.Label;
    }

    public void SwipeRight()
    {
        //if (DetectObjList == null || DetectObjList.Count == 0)
        //{
        //    return;
        //}

        ObjectIdx = Math.Min(ResultImgList.Length, ObjectIdx + 1);
        ObjImage.sprite = ResultImgList[ObjectIdx];
        // Change later!!
        TypeHolder.text = GetTypeName(ObjectIdx);
        
        // CurrentObjIdx = Math.Max(DetectObjList.Count - 1, CurrentObjIdx + 1);
        // CurrentObj = DetectObjList[CurrentObjIdx];
        // TypeHolder.text = CurrentObj.Label;
    }

    private string GetTypeName(int ObjectIdx)
    {
        // Change later!!
        string typeHolder = "";
        switch (ObjectIdx)
        {
            case 0:
                typeHolder = "handle-round_rotate";
                break;
            case 1:
                typeHolder = "handle-bar";
                break;
            case 2:
                typeHolder = "handle-bar";
                break;
            case 3:
                typeHolder = "light switch-toggle";
                break;
        }
        return typeHolder;
    }

    public void ClickIndication()
    {
        // ResultImage.sprite = ResultTypeList[0];
        Type1.text = "visual";
        Type2.text = "tactile";
        ExpandResult();
    }

    public void ClickActuation()
    {
        Type1.text = "hand";
        Type2.text = "leg";
        ExpandResult();
    }

    public void ClickConstraint()
    {
        Type1.text = "general";
        Type2.text = "hazard";
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
