using UnityEngine;
using UnityEngine.SceneManagement;

public class Landing : MonoBehaviour
{
    public void StartScan()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // PhoneARCamera.OnRefresh();
    }
}
