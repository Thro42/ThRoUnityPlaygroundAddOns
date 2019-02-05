using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

[AddComponentMenu("Playground/Conditions/Condition Attack count down")]
public class ConditionAttackCountDown : ConditionBase
{
    [Header("Attack key")]
    public KeyCode keyToPress = KeyCode.Space;

    [Header("Attack count")]
    public int attackCount = 5;

    [Header("Type of Event")]
    public KeyEventTypes eventType = KeyEventTypes.JustPressed;

    [Header("Game Objects")]
    // This is the target the object is going to move towards
    public Collider2D player;
    public Collider2D enemy;

    public float frequency = 0.5f;

    private float timeLastEventFired;

    private int anzAttack = 0;
    private bool isAttack;
    private bool hasCollision;
    private bool lastResult;

    private void Awake()
    {
        enemy = GetComponent<Collider2D>();
        if (player == null)
        {
            if (this.filterByTag)
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
                }
                if (Input.GetKey(keyToPress) && hasCollision)
                {
                    isAttack = true;
                }
                break;
            case KeyEventTypes.Released:
                if (Input.GetKeyUp(keyToPress) && hasCollision)
                {
                    isAttack = true;
                }
                break;
            case KeyEventTypes.KeptPressed:
                if (Time.time >= timeLastEventFired + frequency
                    && Input.GetKey(keyToPress) && hasCollision)
                {
                    isAttack = true;
                    timeLastEventFired = Time.time;
                }
                break;
        }
        if (!lastResult && isAttack)
        {
            anzAttack++;
            lastResult = isAttack;
            if (anzAttack > attackCount)
                ExecuteAllActions(null);
        }
        if (!isAttack)
            lastResult = isAttack;
    }

    public enum KeyEventTypes
    {
        JustPressed,
        Released,
        KeptPressed
    }
}
