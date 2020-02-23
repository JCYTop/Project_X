/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     Tree
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/23 14:34:03
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public class Tree<TAction>
    {
        public TreeNode<TAction> CreateTopNode()
        {
            TreeNode<TAction>.ResetID();
            return new TreeNode<TAction>(null);
        }

        public TreeNode<TAction> CreateNode(IActionHandler<TAction> handler = null)
        {
            return new TreeNode<TAction>(handler);
        }
    }
}