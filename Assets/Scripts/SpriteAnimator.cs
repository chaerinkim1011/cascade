using UnityEngine;
using UnityEngine.UI;

public class SpriteFrameAnimator : MonoBehaviour
{
    public Sprite[] frames;           // 프레임 이미지 배열 (Inspector에서 넣기)
    public float frameTime = 0.3f;    // 각 프레임 지속 시간 (초)

    private Image image;
    private int currentFrame = 0;
    private float timer = 0f;

    void Start()
    {
        image = GetComponent<Image>();
        if (frames.Length > 0)
            image.sprite = frames[0];
    }

    void Update()
    {
        if (frames.Length == 0) return;

        timer += Time.deltaTime;

        if (timer >= frameTime)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            image.sprite = frames[currentFrame];
        }
    }
}