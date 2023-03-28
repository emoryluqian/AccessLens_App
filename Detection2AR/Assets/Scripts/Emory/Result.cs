using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Diagnostics;

public class Result : MonoBehaviour
{
    public GameObject ResultPanel;
    public GameObject ExpandResultPanel;
    public GameObject ConfirmRestartPanel;

    public DetectedObject CurrentObj;
    public List<DetectedObject> DetectObjList;
    private int CurrentObjIdx = 0;
    public Text TypeHolder;

    public Dropdown TypeDropDown;
    public GameObject TypePanel;
    public ScrollRect TypeScrollView;
    public GameObject TypeScrollContent;


    public Image ObjImage; // Delete Later
    public Sprite[] ResultImgList; // Delete Later!!
    private int ObjectIdx = 0; // Delete Later!
    public Sprite[] ContentImgList; // Delete later

    // Delete later
    public GameObject btn1;
    private string curURL1;
    public GameObject btn2;
    private string curURL2;
    public GameObject btn3;
    private string curURL3;
    private int IssueType; // 1,2,3
    public GameObject NoResultPanel;
    

    #region Result Panel

    void Start()
    {
        // Temporary code for demo only
        ObjImage.sprite = ResultImgList[ObjectIdx];
        TypeHolder.text = "handle-round_rotate";

        //// Comment out for now
        // SetCurrentObj();
    }

    public void SwipeLeft()
    {
        // Temporary code for demo only
        ObjectIdx = Math.Max(0, ObjectIdx - 1);
        ObjImage.sprite = ResultImgList[ObjectIdx];
        TypeHolder.text = GetTypeName();

        //// Comment out for now
        //CurrentObjIdx = Math.Max(0, CurrentObjIdx-1);
        //SetCurrentObj();
    }

    public void SwipeRight()
    {
        // Temporary code for demo only
        ObjectIdx = Math.Min(ResultImgList.Length - 1, ObjectIdx + 1);
        ObjImage.sprite = ResultImgList[ObjectIdx];
        TypeHolder.text = GetTypeName();

        //// Comment out for now
        // CurrentObjIdx = Math.Max(DetectObjList.Count - 1, CurrentObjIdx + 1);
        //SetCurrentObj();
    }

    private void SetCurrentObj()
    {
        if (DetectObjList == null || DetectObjList.Count == 0)
        {
            return;
        }

        CurrentObj = DetectObjList[CurrentObjIdx];
        ObjImage.sprite = Resources.Load<Sprite>(CurrentObj.FilePath);
        TypeHolder.text = CurrentObj.ObjectType.ToString();
    }

    // Temporary code for demo only
    private string GetTypeName()
    {
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
        TypeDropDown.ClearOptions();
        List<Dropdown.OptionData> indicationOptions = new List<Dropdown.OptionData>()
        {
            new Dropdown.OptionData(DetectedObject.IndicationType.visual.ToString()),
            new Dropdown.OptionData(DetectedObject.IndicationType.tactile.ToString())
        };
        TypeDropDown.options = indicationOptions;
        TypeDropDown.RefreshShownValue();

        // Temporary code for demo only
        IssueType = 1;

        ExpandResult(0);
    }

    public void ClickActuation()
    {
        TypeDropDown.ClearOptions();
        List<Dropdown.OptionData> actuationOptions = new List<Dropdown.OptionData>()
        {
            new Dropdown.OptionData(DetectedObject.ActuationType.hand.ToString()),
            new Dropdown.OptionData(DetectedObject.ActuationType.leg.ToString())
        };
        TypeDropDown.options = actuationOptions;
        TypeDropDown.RefreshShownValue();

        // Temporary code for demo only
        IssueType = 2;

        ExpandResult(1);
    }

    public void ClickConstraint()
    {
        TypeDropDown.ClearOptions();
        List<Dropdown.OptionData> constraintOptions = new List<Dropdown.OptionData>()
        {
            new Dropdown.OptionData(DetectedObject.ConstraintType.general.ToString()),
            new Dropdown.OptionData(DetectedObject.ConstraintType.hazard.ToString())
        };
        TypeDropDown.options = constraintOptions;
        TypeDropDown.RefreshShownValue();

        // Temporary code for demo only
        IssueType = 3;
        ExpandResult(3);
    }

    public void HandleDropDown()
    {
        int val = TypeDropDown.value;
        string optionText = TypeDropDown.options[val].text;
        UnityEngine.Debug.Log("val is " + optionText);

        NoResultPanel.SetActive(false);
        if (val == 0) // visual, hand, general
        {
            switch (ObjectIdx)
            {
                case 0: // 0. hande-round_rotate
                    if (IssueType == 1) // indication-visual
                    {
                        btn1.SetActive(false);
                        curURL1 = "";
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                        NoResultPanel.SetActive(true);
                    }
                    else if (IssueType == 2) // actuation-hand
                    {
                        btn1.SetActive(true);
                        curURL1 = "https://www.thingiverse.com/thing:1095439";
                        btn1.GetComponent<Image>().sprite = ContentImgList[0];
                        btn2.SetActive(true);
                        curURL2 = "https://www.thingiverse.com/thing:640852";
                        btn2.GetComponent<Image>().sprite = ContentImgList[1];
                        btn3.SetActive(true);
                        curURL3 = "https://www.thingiverse.com/thing:2729961";
                        btn3.GetComponent<Image>().sprite = ContentImgList[2];

                    }
                    else if (IssueType == 3) // constraint-general
                    {
                        btn1.SetActive(true);
                        curURL1 = "https://www.thingiverse.com/thing:3519694";
                        btn1.GetComponent<Image>().sprite = ContentImgList[3];
                        btn2.SetActive(true);
                        curURL2 = "https://www.thingiverse.com/thing:5151375";
                        btn2.GetComponent<Image>().sprite = ContentImgList[4];
                        btn3.SetActive(false);
                        curURL3 = "";
                    }
                    break;
                case 1: // 1. handle-bar
                    if (IssueType == 1) // indication-visual
                    {
                        btn1.SetActive(false);
                        curURL1 = "";
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                        NoResultPanel.SetActive(true);
                    }
                    else if (IssueType == 2) // actuation-hand
                    {
                        btn1.SetActive(false);
                        curURL1 = "";
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                        NoResultPanel.SetActive(true);
                    }
                    else if (IssueType == 3) // constraint-general
                    {
                        btn1.SetActive(true);
                        curURL1 = "https://www.thingiverse.com/thing:2371391";
                        btn1.GetComponent<Image>().sprite = ContentImgList[5];
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                    }
                    break;
                case 2: // handle-bar
                    if (IssueType == 1) // indication-visual
                    {
                        btn1.SetActive(false);
                        curURL1 = "";
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                        NoResultPanel.SetActive(true);
                    }
                    else if (IssueType == 2) // actuation-hand
                    {
                        btn1.SetActive(false);
                        curURL1 = "";
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                        NoResultPanel.SetActive(true);
                    }
                    else if (IssueType == 3) // constraint-general
                    {
                        btn1.SetActive(true);
                        curURL1 = "https://www.thingiverse.com/thing:2371391";
                        btn1.GetComponent<Image>().sprite = ContentImgList[5];
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                    }
                    break;
                case 3: // 3. light switch-toggle
                    if (IssueType == 1) // indication-visual
                    {
                        btn1.SetActive(true);
                        curURL1 = "https://www.thingiverse.com/thing:4924800";
                        btn1.GetComponent<Image>().sprite = ContentImgList[6];
                        btn2.SetActive(false);
                        curURL2 = "";
                        btn3.SetActive(false);
                        curURL3 = "";
                    }
                    else if (IssueType == 2) // actuation-hand
                    {
                        btn1.SetActive(true);
                        curURL1 = "https://www.thingiverse.com/thing:1215328";
                        btn1.GetComponent<Image>().sprite = ContentImgList[7];
                        btn2.SetActive(true);
                        curURL2 = "https://www.thingiverse.com/thing:1904518";
                        btn2.GetComponent<Image>().sprite = ContentImgList[8];
                        btn3.SetActive(false);
                        curURL3 = "";
                    }
                    else if (IssueType == 3) // constraint-general
                    {
                        btn1.SetActive(true);
                        curURL1 = "https://www.thingiverse.com/thing:4798501";
                        btn1.GetComponent<Image>().sprite = ContentImgList[11];
                        btn2.SetActive(true);
                        curURL2 = "https://www.thingiverse.com/thing:6688";
                        btn2.GetComponent<Image>().sprite = ContentImgList[12];
                        btn3.SetActive(true);
                        curURL3 = "https://www.thingiverse.com/thing:4928263";
                        btn3.GetComponent<Image>().sprite = ContentImgList[13];
                    }
                    break;
            }
        }

        if (val == 1) // tactile, leg, hazard
        {
            UnityEngine.Debug.Log("I am here 1");
            switch (ObjectIdx)
                {
                    case 0: // 0. hande-round_rotate
                        if (IssueType == 1) // indication-tactile
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        else if(IssueType == 2) // actuation-leg
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        else if (IssueType == 3) // constraint-hazard
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        break;
                    case 1: // 1. handle bar
                        if (IssueType == 1) // indication-tactile
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        else if(IssueType == 2) // actuation-leg
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        else if (IssueType == 3) // constraint-hazard
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        break;
                    case 2: // 2. handle bar
                        if (IssueType == 1) // indication-tactile
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        else if (IssueType == 2) // actuation-leg
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        else if (IssueType == 3) // constraint-hazard
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                        break;
                    case 3: // 3. light switch-toggle
                        if (IssueType == 1) // indication-tactile
                        {
                            btn1.SetActive(true);
                            curURL1 = "https://www.thingiverse.com/thing:4924800";
                            btn1.GetComponent<Image>().sprite = ContentImgList[6];
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                        }
                        else if (IssueType == 2) // actuation-leg
                        {
                            btn1.SetActive(true);
                            curURL1 = "https://www.thingiverse.com/thing:1805790";
                            btn1.GetComponent<Image>().sprite = ContentImgList[9];
                            btn2.SetActive(true);
                            curURL2 = "https://www.thingiverse.com/thing:658859";
                            btn2.GetComponent<Image>().sprite = ContentImgList[10];
                            btn3.SetActive(false);
                            curURL3 = "";
                        }
                        else if (IssueType == 3) // constraint-hazard
                        {
                            btn1.SetActive(false);
                            curURL1 = "";
                            btn2.SetActive(false);
                            curURL2 = "";
                            btn3.SetActive(false);
                            curURL3 = "";
                            NoResultPanel.SetActive(true);
                        }
                    break;
                }
        }
    }

    // Change Later!
    public void ExpandResult(int typeIdx) // Add parameter later
    {
        Expand(typeIdx); // Add parameter later
        ExpandResultPanel.SetActive(true);
    }

    #endregion


    #region Expand Result Panel

    // Temporary code for demo only
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

    #region Delete later! Temp code for demo only


    public void clickContent1()
    {
        string url = Uri.EscapeUriString(curURL1);
        Application.OpenURL(url);
    }

    public void clickContent2()
    {
        // string url = Uri.EscapeUriString("https://www.thingiverse.com/thing:640852");
        string url = Uri.EscapeUriString(curURL2);
        Application.OpenURL(url);
    }

    public void clickContent3()
    {
        // string url = Uri.EscapeUriString("https://www.thingiverse.com/thing:2729961");
        string url = Uri.EscapeUriString(curURL3);
        Application.OpenURL(url);
    }

    public void clickContent4()
    {
        string url = Uri.EscapeUriString("https://www.thingiverse.com/thing:1805790");
        Application.OpenURL(url);
    }

    public void clickContent5()
    {
        string url = Uri.EscapeUriString("https://www.thingiverse.com/thing:658859");
        Application.OpenURL(url);
    }

    #endregion

    private IEnumerator FetchPreview(string url, GameObject scrollContent)
    {
        UnityWebRequest www = UnityWebRequest.Get(url);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            UnityEngine.Debug.Log("Error fetching link preview: " + www.error);
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
            UnityEngine.Debug.Log("Error downloading image: " + www.error);
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
        SceneManager.LoadScene(1); // Load the `Detect` scene
    }

    #endregion

    public void Update()
    {
        HandleDropDown();
    }

}
