using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using Valve.VR;

public class SteamVRInput : MonoBehaviour
{
    [SerializeField] SteamVR_Input_Sources hand;
    [SerializeField] SteamVR_Action_Boolean action;

    void Update()
    {
        if (action.GetState(hand))
        {
            Debug.Log("Action!");
        }
    }
}
