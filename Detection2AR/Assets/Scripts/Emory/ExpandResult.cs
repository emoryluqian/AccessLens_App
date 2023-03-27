using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandResult : MonoBehaviour
{
    public GameObject ResultPanel;
    public bool Initialized;

    public void SwipeLeft()
    {

    }

    public void SwipeRight()
    {
        
    }

    public void Back()
    {
        ResultPanel.SetActive(false);
    }
}
