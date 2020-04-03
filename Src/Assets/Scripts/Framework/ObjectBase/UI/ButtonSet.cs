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

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Framework.Base
{
    public class ButtonSet
    {
        private Button btn;
        private GameObject selectImg;
        private GameObject noSelectImg;
        private GameObject panel;
        private GameObject grid;
        private GameObject item;
        private bool isActive = false;

        public bool IsActive
        {
            private set { isActive = value; }
            get { return isActive; }
        }

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
        /// 初始化
        /// </summary>
        /// <param name="btn"></param>
        /// <param name="selectImg"></param>
        /// <param name="noSelectImg"></param>
        public ButtonSet(Button btn, GameObject selectImg, GameObject noSelectImg)
        {
            this.btn = btn;
            this.selectImg = selectImg;
            this.noSelectImg = noSelectImg;
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="script"></param>
        /// <param name="data"></param>
        /// <typeparam name="T">获取Refresh()</typeparam>
        public T SetData<T>(object data) where T : UIActionBase
        {
            var go = UIUtil.CreateChildGameObject(item, grid);
            var type = go.GetComponent<T>();
            type.Refresh(data);
            return type;
        }

        public T SetData<T>(object[] data) where T : UIActionBase
        {
            var go = UIUtil.CreateChildGameObject(item, grid);
            var type = go.GetComponent<T>();
            type.Refresh(data);
            return type;
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
            if (selectImg != null) selectImg.SetActive(isActive);
            if (noSelectImg != null) noSelectImg.SetActive(!isActive);
            if (panel != null) panel.SetActive(isActive);
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
}