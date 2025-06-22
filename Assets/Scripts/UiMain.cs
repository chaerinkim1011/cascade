using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class UiMain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreValueText;

    private int currentScore = 0;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int score)
    {
        currentScore += score;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreValueText.text = currentScore.ToString();
    }
}
