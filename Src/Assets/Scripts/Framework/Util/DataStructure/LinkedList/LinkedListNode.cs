using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkedListNode<T>
{
    private T data;
    private LinkedListNode<T> next;

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public LinkedListNode<T> Next
    {
        get { return next; }
        set { next = value; }
    }
}