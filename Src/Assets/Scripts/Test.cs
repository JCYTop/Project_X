/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Test
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/09/15 19:18:40
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public IntList intli = new IntList();

    // Start is called before the first frame update
    void Start()
    {
        intli.Insert(1);
        intli.Insert(10);
        intli.Insert(2);
        intli.Insert(5);
        intli.Insert(17);
        intli.PrintAll();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

public class IntList : SkipList<int>
{
    public override int Compare(int x, int y)
    {
        if (x < y)
        {
            return -1;
        }
        else if (x == y)
        {
            return 0;
        }
        else if (x > y)
        {
            return 1;
        }

        return 0;
    }
}