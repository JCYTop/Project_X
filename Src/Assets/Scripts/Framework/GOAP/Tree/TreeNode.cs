/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     TreeNode
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/23 14:34:13
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public class TreeNode<TAction>
    {
        /// <summary>
        /// 节点的默认ID
        /// </summary>
        public const int DEFAULT_ID = 0;

        private static int _id;
        public int ID { get; private set; }

        /// <summary>
        /// 默认无父节点，值为null
        /// </summary>
        public TreeNode<TAction> ParentNode { get; set; }

        public IActionHandler<TAction> ActionHandler { get; private set; }
        public IState CurrentState { get; set; }
        public IState GoalState { get; set; }

        public int Cost { get; set; }

        public TreeNode(IActionHandler<TAction> handler)
        {
            ID = _id++;
            ActionHandler = handler;
            Cost = 0;
            ParentNode = null;
            CurrentState = CurrentState.CreateState();
            GoalState = CurrentState.CreateState();
        }

        public void CopyState(TreeNode<TAction> otherNode)
        {
//            CurrentState.Copy(otherNode.CurrentState);
//            GoalState.Copy(otherNode.GoalState);
        }

        public static void ResetID()
        {
            _id = DEFAULT_ID;
        }
    }
}