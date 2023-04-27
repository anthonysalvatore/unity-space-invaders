using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 1.0f;
    public System.Action killed;

    private SpriteRenderer spriteRenderer;
    private int animationFrame;
    
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), animationTime, animationTime);
    }

    private void AnimateSprite()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            gameObject.SetActive(false);
            killed.Invoke();
        }
    }
}
