using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [Header("Default or NPC Skin")]
    [SerializeField] List<Sprite> defaultWalkDownSprites;
    [SerializeField] List<Sprite> defaultWalkUpSprites;
    [SerializeField] List<Sprite> defaultWalkRightSprites;
    [SerializeField] List<Sprite> defaultWalkLeftSprites;

    [SerializeField] List<Sprite> defaultSkin;

    // Parameters

    public float MoveX { get; set; }

    public float MoveY { get; set; }

    public bool IsMoving { get; set; }

    // States
    SpriteAnimator defaultWalkDownAnim;
    SpriteAnimator defaultWalkUpAnim;
    SpriteAnimator defaultWalkRightAnim;
    SpriteAnimator defaultWalkLeftAnim;

    SpriteAnimator currentAnim;
    bool wasPreviouslyMoving;

    // References
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultWalkDownAnim = new SpriteAnimator(defaultWalkDownSprites, spriteRenderer);
        defaultWalkUpAnim = new SpriteAnimator(defaultWalkUpSprites, spriteRenderer);
        defaultWalkRightAnim = new SpriteAnimator(defaultWalkRightSprites, spriteRenderer);
        defaultWalkLeftAnim = new SpriteAnimator(defaultWalkLeftSprites, spriteRenderer);

        currentAnim = new SpriteAnimator(defaultSkin, spriteRenderer);
    }

    private void Update()
    {
        var prevAnim = currentAnim;

        if (tag == "Player" && MoveX == 1)
            currentAnim = defaultWalkRightAnim;
        else if (tag == "Player" && MoveX == -1)
            currentAnim = defaultWalkLeftAnim;
        else if (tag == "Player" && MoveY == 1)
            currentAnim = defaultWalkUpAnim;
        else if (tag == "Player" && MoveY == -1)
            currentAnim = defaultWalkDownAnim;

        if (currentAnim != prevAnim || IsMoving != wasPreviouslyMoving)
            currentAnim.Start();

        if (IsMoving)
            currentAnim.HandleUpdate();
        else
            spriteRenderer.sprite = currentAnim.Frames[0];

        wasPreviouslyMoving = IsMoving;
    }
}
