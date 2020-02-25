/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     IContext
 *Author:       @JCY
 *Version:      0.0.1
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.1.0f2
 *CreateTime:   2020/02/25 22:52:55
 *Description:  IndieGame 
 *History:
 ----------------------------------
*/

namespace GOAP
{
    /// <summary>
    /// 与Mono关联的环境接口
    /// 所有Mono数据从接口获取
    /// 主要是一些组件信息
    /// 和一些通用配置参数（基准参数等）
    /// 提供给IAgent数据使用
    /// 属于数据类
    /// </summary>
    public interface IContext
    {
        AIContextBase GetReturnContext { get; }
    }
}