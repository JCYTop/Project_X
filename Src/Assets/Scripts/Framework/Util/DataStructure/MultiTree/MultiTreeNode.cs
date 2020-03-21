/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     MultiTreeNode
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：Unity2019.3.0f6
 *CreateTime:   2020/03/20 14:04:46
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

namespace Base.MultiTree
{
    /// <summary>
    /// 多叉树树节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MultiTreeNode<T>
    {
        private T data;

        /// <summary>
        /// 数据节点
        /// </summary>
        public T Data => data;

        /// <summary>
        /// 父节点
        /// </summary>
        public MultiTreeNode<T> Parent { set; get; }

        /// <summary>
        /// 子节点分类
        /// </summary>
        public List<MultiTreeNode<T>> Childen { set; get; }

        public MultiTreeNode(T data)
        {
            this.data = data;
        }
    }
}