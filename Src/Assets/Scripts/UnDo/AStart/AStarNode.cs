/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AStarNode
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/05/30 16:45:29
 *Description:   
 *History:
 ----------------------------------
*/

public enum E_Node_Type
{
    //走
    Walke,

    //不能走
    Stop,
}

/// <summary>
/// AStar格子
/// </summary>
public class AStarNode
{
    /// <summary>
    /// 格子对象的坐标
    /// </summary>
    public int x;

    public int y;

    /// <summary>
    /// 寻路消耗
    /// </summary>
    public float f;

    /// <summary>
    /// 寻路起点距离
    /// </summary>
    public float g;

    /// <summary>
    /// 寻路重点距离
    /// </summary>
    public float h;

    /// <summary>
    /// 父对象
    /// </summary>
    public AStarNode father;

    /// <summary>
    /// 格子的类型
    /// </summary>
    public E_Node_Type type;

    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="type"></param>
    public AStarNode(int x, int y, E_Node_Type type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }
}