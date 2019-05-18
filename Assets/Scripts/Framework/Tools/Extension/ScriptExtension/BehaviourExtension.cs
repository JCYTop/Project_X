using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BehaviourExtension
{

    public static T Enable<T>(this T selfBehaviour) where T : Behaviour
    {
        selfBehaviour.enabled = true;
        return selfBehaviour;
    }

    public static T Disable<T>(this T selfBehaviour) where T : Behaviour
    {
        selfBehaviour.enabled = false;
        return selfBehaviour;
    }
}