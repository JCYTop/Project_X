using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iterator<T>
{
    bool HasNext
    {
        get;
    }

    T Next
    {
        get;
    }
}