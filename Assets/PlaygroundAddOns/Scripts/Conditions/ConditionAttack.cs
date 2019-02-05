using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Attack")]
public class ConditionAttack : ConditionBase
{
    [Header("Attack key")]
    public KeyCode keyToPress = KeyCode.Space;

    [Header("Type of Event")]
    public KeyEventTypes eventType = KeyEventTypes.JustPressed;

    [Header("Game Objects")]
    // This is the target the object is going to move towards
    public Collider2D player;
    public Collider2D enemy;

    public float frequency = 0.5f;

    private float timeLastEventFired;

    private bool isAttack;
    private bool hasCollision;

    private void Awake()
    {
        enemy = GetComponent<Collider2D>();
        if(player == null)
        {
            if(this.filterByTag)
            {
                GameObject[] thePlayers = GameObject.FindGameObjectsWithTag(this.filterTag);
                player = thePlayers[0].GetComponent<Collider2D>();
            }
            else
            {
                GameObject[] thePlayers = GameObject.FindGameObjectsWithTag("Player");
                player = thePlayers[0].GetComponent<Collider2D>();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        timeLastEventFired = -frequency;
    }

    // Update is called once per frame
    void Update()
    {
        isAttack = false;
        if (enemy != null)
            hasCollision = player.IsTouching(enemy);
        switch (eventType)
        {
            case KeyEventTypes.JustPressed:
                if (Input.GetKeyDown(keyToPress) && hasCollision)
                {
                    isAttack = true;
                    //ExecuteAllActions(null);
                }
                if (Input.GetKey(keyToPress) && hasCollision)
                {
                    isAttack = true;
                    ExecuteAllActions(null);
                }
                break;
            case KeyEventTypes.Released:
                if (Input.GetKeyUp(keyToPress) && hasCollision)
                {
                    isAttack = true;
                    ExecuteAllActions(null);
                }
                break;
            case KeyEventTypes.KeptPressed:
                if (Time.time >= timeLastEventFired + frequency
                    && Input.GetKey(keyToPress) && hasCollision)
                {
                    isAttack = true;
                    ExecuteAllActions(null);
                    timeLastEventFired = Time.time;
                }
                break;
        }
    }

    public enum KeyEventTypes
    {
        JustPressed,
        Released,
        KeptPressed
    }

}
