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

    [Header("Default Attack")]
    [SerializeField] List<Sprite> defaultAttackRightSprites;
    [SerializeField] List<Sprite> defaultAttackLeftSprites;

    [Header("Skin 2")]
    [SerializeField] List<Sprite> skin2WalkRightSprites;
    [SerializeField] List<Sprite> skin2WalkLeftSprites;

    [Header("Skin 2")]
    [SerializeField] List<Sprite> skin2AttackRightSprites;
    [SerializeField] List<Sprite> skin2AttackLeftSprites;

    [Header("Skin 3")]
    [SerializeField] List<Sprite> skin3WalkRightSprites;
    [SerializeField] List<Sprite> skin3WalkLeftSprites;

    [Header("Skin 3")]
    [SerializeField] List<Sprite> skin3AttackRightSprites;
    [SerializeField] List<Sprite> skin3AttackLeftSprites;

    [Header("Skin 4")]
    [SerializeField] List<Sprite> skin4WalkRightSprites;
    [SerializeField] List<Sprite> skin4WalkLeftSprites;

    [Header("Skin 4")]
    [SerializeField] List<Sprite> skin4AttackRightSprites;
    [SerializeField] List<Sprite> skin4AttackLeftSprites;

    [SerializeField] List<Sprite> defaultSkin;

    [SerializeField] bool IsPlayer = false;
    private bool Right;

    // Parameters

    public float MoveX { get; set; }

    public float MoveY { get; set; }

    public bool IsMoving { get; set; }

    // States
    SpriteAnimator defaultWalkDownAnim;
    SpriteAnimator defaultWalkUpAnim;
    SpriteAnimator defaultWalkRightAnim;
    SpriteAnimator defaultWalkLeftAnim;

    SpriteAnimator defaultAttackRightAnim;
    SpriteAnimator defaultAttackLeftAnim;

    SpriteAnimator skin2WalkRightAnim;
    SpriteAnimator skin2WalkLeftAnim;

    SpriteAnimator skin2AttackRightAnim;
    SpriteAnimator skin2AttackLeftAnim;

    SpriteAnimator skin3WalkRightAnim;
    SpriteAnimator skin3WalkLeftAnim;

    SpriteAnimator skin3AttackRightAnim;
    SpriteAnimator skin3AttackLeftAnim;

    SpriteAnimator skin4WalkRightAnim;
    SpriteAnimator skin4WalkLeftAnim;

    SpriteAnimator skin4AttackRightAnim;
    SpriteAnimator skin4AttackLeftAnim;

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

        defaultAttackRightAnim = new SpriteAnimator(defaultAttackRightSprites, spriteRenderer);
        defaultAttackLeftAnim = new SpriteAnimator(defaultAttackLeftSprites, spriteRenderer);

        skin2WalkRightAnim = new SpriteAnimator(skin2WalkRightSprites, spriteRenderer);
        skin2WalkLeftAnim = new SpriteAnimator(skin2WalkLeftSprites, spriteRenderer);

        skin2AttackRightAnim = new SpriteAnimator(skin2AttackRightSprites, spriteRenderer);
        skin2AttackLeftAnim = new SpriteAnimator(skin2AttackLeftSprites, spriteRenderer);

        skin3WalkRightAnim = new SpriteAnimator(skin3WalkRightSprites, spriteRenderer);
        skin3WalkLeftAnim = new SpriteAnimator(skin3WalkLeftSprites, spriteRenderer);

        skin3AttackRightAnim = new SpriteAnimator(skin3AttackRightSprites, spriteRenderer);
        skin3AttackLeftAnim = new SpriteAnimator(skin3AttackLeftSprites, spriteRenderer);

        skin4WalkRightAnim = new SpriteAnimator(skin4WalkRightSprites, spriteRenderer);
        skin4WalkLeftAnim = new SpriteAnimator(skin4WalkLeftSprites, spriteRenderer);

        skin4AttackRightAnim = new SpriteAnimator(skin4AttackRightSprites, spriteRenderer);
        skin4AttackLeftAnim = new SpriteAnimator(skin4AttackLeftSprites, spriteRenderer);

        currentAnim = new SpriteAnimator(defaultSkin, spriteRenderer);
    }

    private void Update()
    {
        var prevAnim = currentAnim;
        if (IsPlayer)
        {
            if (tag == "Player" && MoveX == 1)
            {
                Right = true;
                currentAnim = defaultWalkRightAnim;
            }                
            else if (tag == "Player" && MoveX == -1)
            {
                Right = false;
                currentAnim = defaultWalkLeftAnim;
            }
            else if (tag == "Player" && MoveY == 1 || tag == "Player" && MoveY == -1)
            {
                if (Right)
                {
                    currentAnim = defaultWalkRightAnim;
                }
                else
                {
                    currentAnim = defaultWalkLeftAnim;
                }
            }

            else if (Input.GetKey(KeyCode.C) && tag == "Player" && Right == true)
            {
                currentAnim = defaultAttackRightAnim;
            }
            else if (Input.GetKeyDown(KeyCode.C) && tag == "Player" && Right == false)
            {
                Right = false;
                currentAnim = defaultAttackLeftAnim;
            }
            else if (Input.GetKeyDown(KeyCode.C) && tag == "Player" && (MoveY == 1 || Input.GetKeyDown(KeyCode.C) && tag == "Player" && MoveY == -1))
            {
                if (Right)
                {
                    currentAnim = defaultAttackRightAnim;
                }
                else
                {
                    currentAnim = defaultAttackLeftAnim;
                }
            }

            else if (tag == "Skin 2" && MoveX == 1)
            {
                Right = true;
                currentAnim = skin2WalkRightAnim;
            }              
            else if (tag == "Skin 2" && MoveX == -1)
            {
                Right = false;
                currentAnim = skin2WalkLeftAnim;
            }
                
            else if (tag == "Skin 2" && MoveY == 1 || tag == "Skin 2" && MoveY == -1)
            {
                if (Right)
                {
                    currentAnim = skin2WalkRightAnim;
                }
                else
                {
                    currentAnim = skin2WalkLeftAnim;
                }
            }

            else if (tag == "Skin 3" && MoveX == 1)
            {
                Right = true;
                currentAnim = skin3WalkRightAnim;
            }
                
            else if (tag == "Skin 3" && MoveX == -1)
            {
                Right = false;
                currentAnim = skin3WalkLeftAnim;
            }
                
            else if (tag == "Skin 3" && MoveY == 1 || tag == "Skin 3" && MoveY == -1)
            {
                if (Right)
                {
                    currentAnim = skin3WalkRightAnim;
                }
                else
                {
                    currentAnim = skin3WalkLeftAnim;
                }
            }

            else if (tag == "Skin 4" && MoveX == 1)
            {
                Right = true;
                currentAnim = skin4WalkRightAnim;
            }
                
            else if (tag == "Skin 4" && MoveX == -1)
            {
                Right = false;
                currentAnim = skin4WalkLeftAnim;
            }
                
            else if (tag == "Skin 4" && MoveY == 1 || tag == "Skin 4" && MoveY == -1)
            {
                if (Right)
                {
                    currentAnim = skin4WalkRightAnim;
                }
                else
                {
                    currentAnim = skin4WalkLeftAnim;
                }

            }
        }
        else
        {
            if (tag == "Player" && MoveX == 1)
                currentAnim = defaultWalkRightAnim;
            else if (tag == "Player" && MoveX == -1)
                currentAnim = defaultWalkLeftAnim;
            else if (tag == "Player" && MoveY == 1)
                currentAnim = defaultWalkUpAnim;
            else if (tag == "Player" && MoveY == -1)
                currentAnim = defaultWalkDownAnim;         
        }
        
        if (currentAnim != prevAnim || IsMoving != wasPreviouslyMoving)
            currentAnim.Start();

        if (IsMoving)
            currentAnim.HandleUpdate();
        else
            spriteRenderer.sprite = currentAnim.Frames[0];

        wasPreviouslyMoving = IsMoving;
    }

    public void AttackAnim()
    {

    }
}
