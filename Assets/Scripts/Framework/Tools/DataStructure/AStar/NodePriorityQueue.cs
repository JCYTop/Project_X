using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodePriorityQueue
{
    private List<AStarNode> nodes = new List<AStarNode>();

    public int Length
    {
        get { return nodes.Count; }
    }

    /// <summary>
    /// 相同的节点进行连接
    /// </summary>
    /// <param name="node"></param>
    /// <returns></returns>
    public bool Contains(object node)
    {
        return nodes.Contains(node as AStarNode);
    }

    public AStarNode First()
    {
        if (nodes.Count > 0)
            return nodes[0];
        return null;
    }

    public void Push(AStarNode node)
    {
        nodes.Add(node);
        //这里调用IComparable接口
        nodes.Sort();
    }

    public void Remove(AStarNode node)
    {
        nodes.Remove(node);
        //这里调用IComparable接口
        nodes.Sort();
    }
}