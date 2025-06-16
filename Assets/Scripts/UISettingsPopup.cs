using UnityEngine;
using UnityEngine.SceneManagement;

public class UISettingsPopup : MonoBehaviour
{
    [SerializeField] private GameObject root;

    public void Show()
    {
        root.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Hide()
    {
        root.SetActive(false);
        Time.timeScale = 1f;
    }


    public void OnClickRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnClickQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
