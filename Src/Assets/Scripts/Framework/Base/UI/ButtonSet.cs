/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     ButtonSet
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2019/06/18 00:09:15
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonSet
{
    private Button btn;
    private GameObject selectImg;
    private GameObject noSelectImg;
    private GameObject panel;
    private GameObject grid;
    private GameObject item;
    public bool IsActive { private set; get; }

    public ButtonSet(Button btn, GameObject selectImg, GameObject noSelectImg, GameObject panel, GameObject grid,
        GameObject item)
    {
        this.btn = btn;
        this.selectImg = selectImg;
        this.noSelectImg = noSelectImg;
        this.panel = panel;
        this.grid = grid;
        this.item = item;
    }

    /// <summary>
    /// 设置数据
    /// </summary>
    /// <param name="script"></param>
    /// <param name="data"></param>
    /// <typeparam name="T">获取Refresh()</typeparam>
    public void SetData<T>(object data) where T : UIActionBase
    {
        var go = UIUtil.CreateChildGameObject(item, grid);
        go.GetComponent<T>().Refresh(data);
    }

    /// <summary>
    /// 清除子物体下的child选项
    /// </summary>
    /// <param name="callBack"></param>
    public void CleanGridChild(UnityAction callBack = null)
    {
        UIUtil.CleanAllChild(grid, callBack);
    }

    /// <summary>
    /// 设置激活或者关闭的组集
    /// </summary>
    /// <param name="isActive"></param>
    public void SetActiveSet(bool isActive)
    {
        IsActive = isActive;
        selectImg.SetActive(isActive);
        noSelectImg.SetActive(!isActive);
        panel.SetActive(isActive);
    }

    /// <summary>
    /// 指定设置激活或者关闭 
    /// </summary>
    /// <param name="target"></param>
    /// <param name="isActive"></param>
    public void SetActiveSet(GameObject target, bool isActive)
    {
        target.SetActive(isActive);
    }
}