using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplowAction : Action
{
    public Sprite[] spriteList;
    public float delayTime = 0.4f;
    public int scaleFactor = 10;

    private int anzSprite;
    private float timer = 0.0f;
    private int lastSprite = 0;
    private SpriteRenderer mySpriteRenderer;
    private bool _animating = false;


    public override bool ExecuteAction(GameObject otherObject)
    {
        if(mySpriteRenderer == null)
            mySpriteRenderer = GetComponent<SpriteRenderer>();
        _animating = true;
        // variable to hold a reference to our SpriteRenderer component
        if (mySpriteRenderer != null && lastSprite < spriteList.Length)
        {
            mySpriteRenderer.sprite = spriteList[lastSprite];
            mySpriteRenderer.sortingOrder = +2; 
            lastSprite++;
        }
        Vector3 newScale = new Vector3(scaleFactor, scaleFactor, 0);
        this.gameObject.transform.localScale = newScale;
        return true; //always returns true
    }

    private void Update()
    {
        if (mySpriteRenderer == null)
            mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (_animating)
        {
            timer += Time.deltaTime;
            if(timer > delayTime)
            {
                timer = timer - delayTime;
                if (mySpriteRenderer != null)
                {
                    anzSprite = spriteList.Length;
                    if (spriteList.Length > lastSprite)
                    {
                        mySpriteRenderer.sprite = spriteList[lastSprite];
                        lastSprite++;
                    } else
                    {
                        this.gameObject.SetActive(false);
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
