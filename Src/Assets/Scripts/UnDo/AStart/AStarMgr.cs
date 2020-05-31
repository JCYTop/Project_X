/** 
----------------------------------
 *Copyright(C) 2019 by IndieGame
 *All rights reserved.
 *FileName:     AStarMgr
 *Author:       @JCY
 *Version:      0.1.0
 *AuthorEmail:  jcyemail@qq.com
 *UnityVersion：2019.3.1f1
 *CreateTime:   2020/05/31 13:12:50
 *Description:   
 *History:
 ----------------------------------
*/

using System.Collections.Generic;
using System.Linq;
using Framework.Singleton;
using Pathfinding.Ionic.Zip;
using UnityEngine;

public class AStarMgr : Singleton<AStarMgr>
{
    public float mapW;
    public float mapH;

    /// <summary>
    /// 地图相关的格子对象
    /// </summary>
    public AStarNode[,] nodes;

    /// <summary>
    /// 开启列表
    /// </summary>
    public List<AStarNode> openList = new List<AStarNode>();

    /// <summary>
    /// 关闭列表
    /// </summary>
    public List<AStarNode> closeList = new List<AStarNode>();

    public void InitMapInfo(int w, int h)
    {
        //TODO 根据宽高 创建格子
        mapW = w;
        mapH = h;
        //TODO 考虑阻挡问题
        nodes = new AStarNode[w, h];
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                var node = new AStarNode(i, j, Random.Range(0, 100) < 20 ? E_Node_Type.Stop : E_Node_Type.Walke);
                nodes[i, j] = node;
            }
        }
    }

    /// <summary>
    /// 寻路算法
    /// </summary>
    /// <param name="startPos"></param>
    /// <param name="endPos"></param>
    /// <returns></returns>
    public List<AStarNode> FindPath(Vector2 startPos, Vector3 endPos)
    {
        //TODO 首先判断传入点是否合法
        //TODO 要在地图范围内
        if (startPos.x < 0 || startPos.x >= mapW || startPos.y < 0 || startPos.y >= mapH
            ||
            endPos.x < 0 || endPos.x >= mapW || endPos.y < 0 || endPos.y >= mapH)
        {
            Debug.Log("开始或者结束点在格子外");
            return null;
        }

        var start = nodes[(int) startPos.x, (int) startPos.y];
        var end = nodes[(int) endPos.x, (int) endPos.y];
        //TODO 是不是阻挡
        if (start.type == E_Node_Type.Stop
            ||
            end.type == E_Node_Type.Stop)
        {
            Debug.Log("开始或者结束点是阻挡");
            return null;
        }

        //清空
        openList.Clear();
        closeList.Clear();
        start.father = null;
        start.f = 0;
        start.g = 0;
        start.h = 0;
        closeList.Add(start);

        while (true)
        {
            //起点开始，找周围点 并放入开启列表
            //左上 x-1 y-1 
            FindNearlyNodeToNodeToOpenList(start.x - 1, start.y - 1, 1.4f, start, end);
            //上 x y-1 
            FindNearlyNodeToNodeToOpenList(start.x, start.y - 1, 1, start, end);
            //右上 x+1 y-1 
            FindNearlyNodeToNodeToOpenList(start.x + 1, start.y - 1, 1.4f, start, end);
            //左 x-1 y 
            FindNearlyNodeToNodeToOpenList(start.x - 1, start.y, 1, start, end);
            //右 x+1 y 
            FindNearlyNodeToNodeToOpenList(start.x + 1, start.y, 1, start, end);
            //左下 x-1 y+1 
            FindNearlyNodeToNodeToOpenList(start.x - 1, start.y + 1, 1.4f, start, end);
            //下 x y+1 
            FindNearlyNodeToNodeToOpenList(start.x, start.y + 1, 1, start, end);
            //右下 x+1 y+1 
            FindNearlyNodeToNodeToOpenList(start.x + 1, start.y + 1, 1.4f, start, end);
            if (openList.Count == 0)
            {
                Debug.Log("开始或者阻挡");
                return null;
            }

            //排序
            openList.Sort(SortOpenList);
            closeList.Add(openList[0]);
            start = openList[0];
            openList.RemoveAt(0);
            if (start == end)
            {
                //找完了 找到路径了
                var path = new List<AStarNode>();
                path.Add(end);
                while (end.father != null)
                {
                    path.Add(end.father);
                    end = end.father;
                }

                //反转
                path.Reverse();
            }

            return null;
        }
    }

    private int SortOpenList(AStarNode a, AStarNode b)
    {
        if (a.f > b.f)
            return 1;
        else if (a.f == b.f)
            return 1;
        else
            return -1;
    }

    private void FindNearlyNodeToNodeToOpenList(int x, int y, float g, AStarNode father, AStarNode end)
    {
        //边界判断
        if (x < 0 || x >= mapW || y < 0 || y >= mapH)
        {
            return;
        }

        var node = nodes[x, y];
        if (node == null || node.type == E_Node_Type.Stop || closeList.Contains(node) || openList.Contains(node))
            return;

        node.father = father;
        node.g = father.g + g;
        node.h = Mathf.Abs(end.x - node.x) + Mathf.Abs(end.y - node.y);
        node.f = node.g + node.h;

        //如果通过了上面的合法验证 ，就存到开启列表
        openList.Add(node);
    }
}