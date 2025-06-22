using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    // 플레이 버튼 눌렀을 때 메인 씬으로 이동하는 함수
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("GameScene");  // 실제 씬 이름으로 바꾸기
    }
}