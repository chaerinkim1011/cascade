using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISettingsPopup : MonoBehaviour
{
    [SerializeField] private GameObject uiSettingsPopupPanel;  // 설정창 패널 오브젝트 연결

    private void Start()
    {
        if (uiSettingsPopupPanel != null)
            uiSettingsPopupPanel.SetActive(false);  // 시작 시 설정창 숨기기
    }

    public void ShowPopup()
    {
        if (uiSettingsPopupPanel != null)
        {
            uiSettingsPopupPanel.SetActive(true);
            Time.timeScale = 0f;  // 게임 일시정지
        }
    }

    public void HidePopup()
    {
        if (uiSettingsPopupPanel != null)
        {
            uiSettingsPopupPanel.SetActive(false);
            Time.timeScale = 1f;  // 게임 재개
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