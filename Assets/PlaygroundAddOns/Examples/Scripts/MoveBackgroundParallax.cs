using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackgroundParallax : MonoBehaviour
{
    public FreeParallax parallax;
    public GameObject _player;
    public float _speedFactor = 1;

    private Rigidbody2D playerRigidbody;

    private void Awake()
    {
        if (playerRigidbody == null)
            playerRigidbody = _player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parallax != null && _player != null)
        {
            if (playerRigidbody == null)
                playerRigidbody = _player.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                float newSpeed = 0;
                if (playerRigidbody.velocity.x > 0)
                {
                    newSpeed = playerRigidbody.velocity.magnitude * _speedFactor * -1f;
                }
                if (playerRigidbody.velocity.x < 0)
                {
                    newSpeed = playerRigidbody.velocity.magnitude * _speedFactor * 1f;
                }
                parallax.Speed = newSpeed;
            }


        }
    }
}

