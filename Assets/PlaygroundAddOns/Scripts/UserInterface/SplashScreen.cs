using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public GameObject _splashScreen;
    [Header("Start Options")]
    public KeyCode keyToStart = KeyCode.P;
    public bool useAutoStart;
    public float autoStartTime = 10;

    private float timer = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (_splashScreen == null)
            return;
        if (Input.GetKey(keyToStart))
        {
            Destroy(_splashScreen);
        }
        if (useAutoStart)
        {
            timer += Time.deltaTime;
            if (timer > autoStartTime)
            {
                Destroy(_splashScreen);
            }
        }
    }
}
