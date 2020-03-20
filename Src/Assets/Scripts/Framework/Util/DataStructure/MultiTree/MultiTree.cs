/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     MultiTree
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/20 15:02:47
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace Base.MultiTree
{
    public class MultiTree<T>
    {
        public int Count { set; get; } = 0;
        public MultiTreeNode<T> Head { get; }

        public MultiTree(T head)
        {
            this.Head = new MultiTreeNode<T>(head);
            Count++;
        }

        public void Clear()
        {
            Count = 0;
        }
    }
}