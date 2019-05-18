using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelfListVisitor<T>
{
    void Visit(T data);
}

public delegate void ListVisitorDelegate<T>(T data);