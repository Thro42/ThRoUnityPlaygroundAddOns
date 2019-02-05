using UnityEngine;
using System.Collections;

[AddComponentMenu("Playground/Movement/Move Player With Arrows")]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMove : Physics2DObject
{
    [Header("Input keys")]
    public Enums.KeyGroups typeOfControl = Enums.KeyGroups.ArrowKeys;

    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed = 5f;
    public Enums.MovementType movementType = Enums.MovementType.OnlyHorizontal;

    [Header("Orientation")]
    public bool orientToDirection = false;

    private Vector2 movement, cachedDirection;
    private float moveHorizontal;
    private float moveVertical;

    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
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


        //rotate the GameObject towards the direction of movement
        //the axis to look can be decided with the "axis" variable
        if (orientToDirection)
        {
            msg = string.Format("Player move to {0}", movement);
            Debug.Log(msg);
            if (movement.sqrMagnitude >= 0.01f)
            {
                cachedDirection = movement;
            }
            if (mySpriteRenderer != null)
            {
                if (movement.x < 0)
                {
                    // flip the sprite
                    mySpriteRenderer.flipX = true;
                }
                else
                {
                    mySpriteRenderer.flipX = false;
                }
            }

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
        this.rigidbody2D.AddForce(movement * speed * 10f);
    }

}
