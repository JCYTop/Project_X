using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Node类将处理代表我们地图的2D格子中其中的每个格子对象 
/// </summary>
public class AStarNode : IComparable
{
    public float NodeTotalCost; // G它是从开始节点到当前节点的代价值
    public float EstimatedCost; // H它是从当前节点到目标节点的估计值
    public Vector3 Position;
    public AStarNode Parent;
    public bool IsObstacle;//判断是不是障碍

    public AStarNode(Vector3 pos)
    {
        EstimatedCost = 0.0f;
        NodeTotalCost = 1.0f;
        IsObstacle = false;
        Parent = null;
        Position = pos;
    }

    public void MarkAsObstacle()
    {
        IsObstacle = true;
    }

    public int CompareTo(object obj)
    {
        AStarNode node = obj as AStarNode;
        //-1,0,1输出,Sort()调用
        return EstimatedCost.CompareTo(node.EstimatedCost);
    }
}