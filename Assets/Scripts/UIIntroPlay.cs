using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroUI : MonoBehaviour
{
    // �÷��� ��ư ������ �� ���� ������ �̵��ϴ� �Լ�
    public void OnPlayButtonClicked()
    {
        SceneManager.LoadScene("GameScene");  // ���� �� �̸����� �ٲٱ�
    }
}