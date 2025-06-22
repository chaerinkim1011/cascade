using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] frames;
    public float frameRate = 0.1f;

    private int currentFrame = 0;
    private float timer = 0f;

    private void Awake()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame = (currentFrame + 1) % frames.Length;
            spriteRenderer.sprite = frames[currentFrame];
        }
    }
}
