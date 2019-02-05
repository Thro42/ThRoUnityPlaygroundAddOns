using System.Collections;
using UnityEngine;

[AddComponentMenu("Playground/Movement/Follow Player")]
[RequireComponent(typeof(Rigidbody2D))]
public class FollowPlayer : Physics2DObject
{

    // This is the target the object is going to move towards
    public Transform target;

    [Header("Movement")]
    // Speed used to move towards the target
    public float speed = 1f;
    public Enums.MovementType movementType = Enums.MovementType.OnlyHorizontal;

    // Used to decide if the object will look at the target while pursuing it
    public bool lookAtTarget = false;

    // variable to hold a reference to our SpriteRenderer component
    private SpriteRenderer mySpriteRenderer;

    private void Awake()
    {
        // get a reference to the SpriteRenderer component on this gameObject
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        string msg;
        //do nothing if the target hasn't been assigned or it was detroyed for some reason
        if (target == null)
            return;

        Vector2 newTargetPos = Vector2.Lerp(transform.position, target.position, Time.fixedDeltaTime * speed);
        if (movementType == Enums.MovementType.OnlyHorizontal)
            newTargetPos.y = transform.position.y;

        msg = string.Format("newTargetPos {0}", newTargetPos);
        //Debug.Log(msg);
        if (this.rigidbody2D == null)
        {
            this.rigidbody2D = GetComponent<Rigidbody2D>();
        }        //Move towards the target
        //look towards the target
        Vector2 distance = transform.position - target.position;
        if (lookAtTarget && mySpriteRenderer != null && this.rigidbody2D != null)
        {
            msg = string.Format("show to {0}", distance.x);
//            Debug.Log(msg);
            if (distance.x < 0)
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
            }
            else if (distance.x > 0)
            {
                mySpriteRenderer.flipX = false;
            }
        }
        this.rigidbody2D.MovePosition(newTargetPos);

    }
}
