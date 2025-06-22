using UnityEngine;
using UnityEngine.UI;

public class WaterfallAnimator : MonoBehaviour
{
    public Image targetImage;     
    public Sprite[] frames;
    public float frameRate = 0.1f;

    private int currentFrame = 0;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            targetImage.sprite = frames[currentFrame];
        }
    }
}
