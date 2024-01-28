using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSheetAnimator : MonoBehaviour
{
    public Texture2D spriteSheet; // The entire sprite sheet
    public int tileWidth; // Width of a single tile/frame in the sprite sheet
    public int tileHeight; // Height of a single tile/frame in the sprite sheet
    public float frameInterval; // Time interval between frames
    public int skipFirstFrames; // Number of frames to skip at the start
    public int skipLastFrames; // Number of frames to skip at the end

    private SpriteRenderer spriteRenderer;
    private int currentFrameIndex;
    private int totalFrames;
    private float timer;
    private int columns;
    private int rows;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        columns = spriteSheet.width / tileWidth;
        rows = spriteSheet.height / tileHeight;
        totalFrames = columns * rows;
        currentFrameIndex = skipFirstFrames;
        CreateSprite();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameInterval)
        {
            timer -= frameInterval;
            currentFrameIndex++;

            if (currentFrameIndex >= totalFrames - skipLastFrames)
            {
                currentFrameIndex = skipFirstFrames;
            }

            CreateSprite();
        }
    }

    void CreateSprite()
    {
        int column = currentFrameIndex % columns;
        int row = currentFrameIndex / columns;

        // Calculate the tile's pixel coordinates from the bottom left of the sprite sheet
        int x = column * tileWidth;
        int y = spriteSheet.height - (row * tileHeight + tileHeight);

        // Extract the tile from the sprite sheet and set it as the current sprite
        Sprite newSprite = Sprite.Create(spriteSheet, new Rect(x, y, tileWidth, tileHeight), new Vector2(0.5f, 0.5f));
        spriteRenderer.sprite = newSprite;
    }
}
