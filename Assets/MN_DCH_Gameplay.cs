/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MN_DCH_Gameplay : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] SpriteRenderer spriteRenderer;
    


    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float maxAlpha = 0f;
        float spriteWidth = spriteRenderer.sprite.rect.width;
        float spriteHeight = spriteRenderer.sprite.rect.height;

        Texture2D texture = spriteRenderer.sprite.texture;

        for (int x = 0; x < spriteWidth; x++)
        {
            for (int y = 0; y < spriteHeight; y++)
            {
                Color pixelColor = texture.GetPixel((int)(x + spriteRenderer.sprite.rect.x), (int)(y + spriteRenderer.sprite.rect.y));
                maxAlpha = Mathf.Max(maxAlpha, pixelColor.a);
            }
        }

        boxCollider2D.size = new Vector2(spriteWidth * maxAlpha* , spriteHeight * maxAlpha * );
    }
}*/