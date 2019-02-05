using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreAction : Action
{
    public int pointsWorth = 1;

    private UIScript userInterface;
    private bool _pointSet;

    // Start is called before the first frame update
    void Start()
    {
        // Find the UI in the scene and store a reference for later use
        userInterface = GameObject.FindObjectOfType<UIScript>();
    }

    public override bool ExecuteAction(GameObject dataObject)
    {
        if(!_pointSet)
        {
            _pointSet = true;
            if (userInterface == null)
                userInterface = GameObject.FindObjectOfType<UIScript>();
            if (userInterface != null)
            {
                // add one point
                int playerId = 0;
                userInterface.AddPoints(playerId, pointsWorth);
            }
        }
        return true; //always returns true
    }
}

