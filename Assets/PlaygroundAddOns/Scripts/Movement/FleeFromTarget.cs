using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Playground/Movement/Flee from Player")]
[RequireComponent(typeof(Rigidbody2D))]
public class FleeFromTarget : Physics2DObject
{
    // This is the target the object is going to move towards
    public Transform target;

    [Header("Movement")]
    // Speed used to move towards the target
    public float speed = 1f;
    public Enums.MovementType movementType = Enums.MovementType.OnlyHorizontal;
    // When the Target is closer the this, the Object start to flee
    public float fleeDistance = 10;

    // Used to decide if the object will look to direction of moving
    public bool lookAtMoving = false;

    [Header("Sprits")]
    public Sprite _walkSprite;
    private Sprite _idleSprite;

    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (mySpriteRenderer != null & _idleSprite == null)
            _idleSprite = mySpriteRenderer.sprite;

        if (target == null)
        {
            GameObject[] thePlayers = GameObject.FindGameObjectsWithTag("Player");
            target = thePlayers[0].transform;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 speedTo = Vector2.zero;
        if (target == null)
            return;
        if (this.rigidbody2D == null)
        {
            this.rigidbody2D = GetComponent<Rigidbody2D>();
        }        //Move towards the target
        // calculate the distance to the player
        float dist2Target = Vector2.Distance(transform.position, target.position);
        // is the distance smaler then devined
        if (dist2Target < fleeDistance)
        {
            Vector2 moveTo = transform.position;
            if (movementType == Enums.MovementType.AllDirections || movementType == Enums.MovementType.OnlyHorizontal)
            {
                // calc the new targer Pos on X-axis
                float sign = Mathf.Sign(transform.position.x - target.position.x);
                float xDif = fleeDistance - Mathf.Abs(transform.position.x - target.position.x);
                xDif = xDif * sign;
                moveTo.x = moveTo.x + xDif;
                moveTo.x = Mathf.Round(moveTo.x * 10) / 10;
            }
            if (movementType == Enums.MovementType.AllDirections || movementType == Enums.MovementType.OnlyVertical)
            {
                // calc the new targer Pos on Y-axis
                float sign = Mathf.Sign(transform.position.y - target.position.y);
                float yDif = fleeDistance - Mathf.Abs(transform.position.y - target.position.y);
                yDif = yDif * sign;
                moveTo.y = moveTo.y + yDif;
                moveTo.y = Mathf.Round(moveTo.y * 10) / 10;
            }
            Vector2 newTargetPos = Vector2.Lerp(transform.position, moveTo, Time.fixedDeltaTime * speed);
            if (movementType == Enums.MovementType.OnlyHorizontal)
                newTargetPos.y = transform.position.y;
            this.rigidbody2D.MovePosition(newTargetPos);
            // flip the sprite in direction of moving
            if (lookAtMoving)
            {
                speedTo = this.rigidbody2D.GetPointVelocity(newTargetPos);
                this.rigidbody2D.velocity = speedTo;
                if (speedTo.x > 0)
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
        else
        {
            this.rigidbody2D.velocity = Vector2.zero;
        }
        // change the sprite when the Objekt ist moving
        if (_walkSprite != null) // did we have a Sprite
        {
            if (Mathf.Abs(speedTo.x) > 0.001 && mySpriteRenderer.sprite == _idleSprite)
            {
                mySpriteRenderer.sprite = _walkSprite;
            }
            else if (Mathf.Abs(speedTo.x) <= 0.001 && mySpriteRenderer.sprite == _walkSprite)
            {
                mySpriteRenderer.sprite = _idleSprite;
            }
        }
    }
}
