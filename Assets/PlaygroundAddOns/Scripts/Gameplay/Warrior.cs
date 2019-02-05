using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Playground/Movement/Move Worrior With Arrows")]
[RequireComponent(typeof(Rigidbody2D))]
public class Warrior : Physics2DObject
{
    [Header("Player Sprites")]
    public Sprite _idleSprite;
    public Sprite _walkSprite;
    public Sprite _attackSprite;

    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;
    [Header("Attack key")]
    // The key to press to attack 
    public KeyCode keyToPress = KeyCode.Space;


    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 5f;
    public Enums.MovementType movementType = Enums.MovementType.OnlyHorizontal;

    [Header("Orientation")]
    public bool orientToDirection = false;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;
    private bool isAttack;
    private bool attackFlip;

    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (mySpriteRenderer != null & _idleSprite != null)
            mySpriteRenderer.sprite = _idleSprite;
    }

    // Update gets called every frame
    void Update()
    {
        string msg;
        // Moving with the arrow keys
        if (typeOfControl == Enums.KeyGroups.ArrowKeys)
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }
        else
        {
            moveHorizontal = Input.GetAxis("Horizontal2");
            moveVertical = Input.GetAxis("Vertical2");
        }

        //zero-out the axes that are not needed, if the movement is constrained
        switch (movementType)
        {
            case Enums.MovementType.OnlyHorizontal:
                moveVertical = 0f;
                break;
            case Enums.MovementType.OnlyVertical:
                moveHorizontal = 0f;
                break;
        }

        movement = new Vector2(moveHorizontal, moveVertical);


        bool lastFlip = mySpriteRenderer.flipX;
        //rotate the GameObject towards the direction of movement
        //the axis to look can be decided with the "axis" variable
        if (orientToDirection)
        {
            if (mySpriteRenderer != null)
            {
                if (this.rigidbody2D.velocity.x < 0)
                {
                    // flip the sprite
                    mySpriteRenderer.flipX = true;
                }
                else
                {
                    mySpriteRenderer.flipX = false;
                }
            }
            if (this.rigidbody2D.velocity.magnitude > 0 && !isAttack)
            {
                mySpriteRenderer.sprite = _walkSprite;
            }
            if (this.rigidbody2D.velocity.magnitude == 0 && !isAttack)
            {
                mySpriteRenderer.sprite = _idleSprite;
                mySpriteRenderer.flipX = attackFlip;
            }
        }
        if (Input.GetKey(keyToPress))
        {
            attackFlip = lastFlip;
            mySpriteRenderer.sprite = _attackSprite;
            this.rigidbody2D.velocity = Vector2.zero;

            mySpriteRenderer.flipX = lastFlip;
            isAttack = true;
        }
        else
        {
            isAttack = false;
        }
    }

    // FixedUpdate is called every frame when the physics are calculated
    void FixedUpdate()
    {
        if (this.rigidbody2D == null)
        {
            this.rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Apply the force to the Rigidbody2d
        if (!isAttack)
        {
            this.rigidbody2D.AddForce(movement * speed * 10f);
        }
        else
        {
            mySpriteRenderer.flipX = attackFlip;
        }
    }
}
