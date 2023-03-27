using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

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
    public GameObject Type1Panel;
    public ScrollRect Type1ScrollView;
    public GameObject Type1ScrollContent;
    public Text Type2;
    public GameObject Type2Panel;
    public ScrollRect Type2ScrollView;
    public GameObject Type2ScrollContent;
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
        StartCoroutine(FetchPreview("https://www.thingiverse.com/thing:1095439", Type1ScrollContent));
        Type2.text = "tactile";
        StartCoroutine(FetchPreview("https://www.thingiverse.com/thing:1095439", Type2ScrollContent));
        ExpandResult(0);
    }

    public void ClickActuation()
    {
        Type1.text = "hand";
        Type2.text = "leg";
        ExpandResult(1);
    }

    public void ClickConstraint()
    {
        Type1.text = "general";
        Type2.text = "hazard";
        ExpandResult(3);
    }

    public void ExpandResult(int typeIdx) // Add parameter later
    {
        Expand(typeIdx); // Add parameter later
        ExpandResultPanel.SetActive(true);
    }

    #endregion


    #region Expand Result Panel

    

    private void Expand(int typeIdx) // Add parameter later
    {
        switch (typeIdx)
        {
            case 0: // Indication
                break;
            case 1: // Actuation
                break;
            case 2: // Constraint
                break;
        }
        // pull out result information to expand result
    }

    private IEnumerator FetchPreview(string url, GameObject scrollContent)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error fetching link preview: " + www.error);
        }
        else
        {
            string html = www.downloadHandler.text;
            string title = GetMetaTagContent(html, "og:title");
            string description = GetMetaTagContent(html, "og:description");
            string imageUrl = GetMetaTagContent(html, "og:image");

            GameObject child = new GameObject();
            child.transform.SetParent(scrollContent.transform);

            //Text urlComponent = child.AddComponent<Text>();
            //urlComponent.text = url; 
            Text titleComponent = child.AddComponent<Text>();
            titleComponent.text = title;
            Image imageComponent = child.AddComponent<Image>();
            imageComponent.sprite = DownloadImage(imageUrl);
       
            //GameObject preview = Instantiate(scrollContent);
            //preview.transform.localScale = Vector3.one;

            //preview.AddComponent<Text>().text = title;
            //preview.AddComponent<Image>().sprite = DownloadImage(imageUrl);

            //preview.transform.SetParent(transform.GetChild(0), false);

            //Debug.Log("Title: " + title);
            //Debug.Log("Description: " + description);
            //Debug.Log("Image URL: " + imageUrl);
        }
    }

    private string GetMetaTagContent(string html, string property)
    {
        string tag = "<meta property=\"" + property + "\" content=\"";
        int startIndex = html.IndexOf(tag) + tag.Length;
        int endIndex = html.IndexOf("\"", startIndex);
        return html.Substring(startIndex, endIndex - startIndex);
    }

    private Sprite DownloadImage(string imageUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageUrl);
        www.SendWebRequest();
        while (!www.isDone) { }

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Error downloading image: " + www.error);
            return null;
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
    }

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
