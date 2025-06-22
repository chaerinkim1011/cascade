using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISettingsPopup : MonoBehaviour
{
    [SerializeField] private GameObject uiSettingsPopupPanel;  // ����â �г� ������Ʈ ����

    private void Start()
    {
        if (uiSettingsPopupPanel != null)
            uiSettingsPopupPanel.SetActive(false);  // ���� �� ����â �����
    }

    public void ShowPopup()
    {
        if (uiSettingsPopupPanel != null)
        {
            uiSettingsPopupPanel.SetActive(true);
            Time.timeScale = 0f;  // ���� �Ͻ�����
        }
    }

    public void HidePopup()
    {
        if (uiSettingsPopupPanel != null)
        {
            uiSettingsPopupPanel.SetActive(false);
            Time.timeScale = 1f;  // ���� �簳
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToIntro()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("IntroScene"); 
    }
}