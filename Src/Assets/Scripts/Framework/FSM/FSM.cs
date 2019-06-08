/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     FSM
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/02 16:44:26
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections.Generic;

/// <summary>
/// FSM回调
/// </summary>
public delegate void FSMCallback(params object[] param);

public class FSM
{
    private FSMState currState;
    private Dictionary<string, FSMState> stateDic = new Dictionary<string, FSMState>();

    /// <summary>
    /// 获得当前状态
    /// </summary>
    public FSMState CurrState
    {
        get { return currState; }
        set { currState = value; }
    }

    public FSM(string name)
    {
        FSMMgr.FSMList.Add(name, this);
    }

    #region 状态机调用

    /// <summary>
    /// 状态机开始
    /// </summary>
    /// <param name="startState">输入开始的状态</param>
    /// <returns></returns>
    public FSM StartState(FSMState startState)
    {
        AddState(startState);
        currState = startState;
        currState.OnEnter();
        return this;
    }

    /// <summary>
    /// 状态机运行
    /// </summary>
    /// <returns></returns>
    public FSM UpdateState()
    {
        foreach (var translation in currState.Translation)
        {
            if (translation.Condition())
            {
                HandleEvent(translation, null);
                return this;
            }
        }

        currState.OnUpdate();
        return this;
    }

    /// <summary>
    /// 状态机退出
    /// </summary>
    /// <returns></returns>
    public FSM ExitState()
    {
        currState.OnExit();
        return this;
    }

    #endregion

    /// <summary>
    /// 清除FSM字典
    /// </summary>
    public void CleanDic()
    {
        stateDic.Clear();
    }

    /// <summary>
    /// 添加状态到Dic
    /// </summary>
    /// <param name="state">要添加的状态</param>
    public FSM AddState(FSMState state)
    {
        if (!stateDic.ContainsKey(state.Name))
            stateDic.Add(state.Name, state);
        else
            LogUtil.LogError(string.Format("已经存在相同的Key"));
        return this;
    }

    /// <summary>
    /// 在状态机中事先添加关系状态
    /// </summary>
    /// <param name="state"></param>
    /// <param name="translation"></param>
    public FSM AddTranslation(FSMState state, FSMTranslation translation)
    {
        if (!stateDic.ContainsKey(state.Name))
        {
            stateDic.Add(state.Name, state);
        }

        if (!stateDic[state.Name].Translation.Contains(translation))
        {
            stateDic[state.Name].Translation.Add(translation);
        }

        return this;
    }

    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="name">处理事件名</param>
    public void HandleEvent(FSMTranslation translation, params object[] param)
    {
        if (currState != null && stateDic[currState.Name].Translation.Contains(translation) && stateDic.ContainsKey(translation.ToStateName))
        {
            currState.OnExit();
            currState = stateDic[translation.ToStateName];
            currState.OnEnter();
            currState.OnUpdate();
            if (translation.Callback != null)
                translation.Callback(param);
        }
        else
            LogUtil.LogError(string.Format("缺少状态机转换必要条件"));
    }
}