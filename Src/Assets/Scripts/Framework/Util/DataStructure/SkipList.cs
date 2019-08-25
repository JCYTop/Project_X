/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     SkipList
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/08/25 23:06:50
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using UnityEngine;

public class SkipList
{
    public static int MAX_LEVEL = 16;
    private int levelCount = 1;
    private Node head = new Node(); //带头链表
    private Random r = new Random();

    public Node find(int value)
    {
        Node p = head;
        for (int i = levelCount - 1; i >= 0; --i)
        {
            while (p.forwards[i] != null && p.forwards[i].data < value)
            {
                p = p.forwards[i];
            }
        }

        if (p.forwards[0] != null && p.forwards[0].data == value)
        {
            return p.forwards[0];
        }
        else
        {
            return null;
        }
    }
}

public class Node
{
    public int data = -1;
    public Node[] forwards = new Node[SkipList.MAX_LEVEL];
    private int maxLevel = 0;
}