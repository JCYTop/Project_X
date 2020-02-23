/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IMap
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/22 14:45:44
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    public interface IMap<TAction, TGoal>
    {
        IActionHandler<TAction> GetActionHandler(TAction actionLabel);
        IGoal<TGoal> GetGoal(TGoal label);
        void SetGameData<Tkey>(Tkey key, object data);
         object GetGameData<Tkey>(Tkey key);
    }
}