using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Iteratable<T>
{
    Iterator<T> Iterator();
}