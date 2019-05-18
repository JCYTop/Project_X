using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelfList<T>
{
    void Accept(ISelfListVisitor<T> visitor);
    void Accept(ListVisitorDelegate<T> visitor);
}