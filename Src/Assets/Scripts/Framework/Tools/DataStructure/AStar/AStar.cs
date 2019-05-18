using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    private static NodePriorityQueue ClosedList, OpenList;//声明闭合链表，和打开链表
    private float gridCellSize;
    private int numOfColumns;//列
    private int numOfRows;//行
    private Vector3 mOrigin = new Vector3();
    private GameObject[] obstacleList;

    public AStar(int Columns, int Rows, float gridCellSize, GameObject[] obstacleList)
    {
        numOfColumns = Columns;
        numOfRows = Rows;
        this.gridCellSize = gridCellSize;
        this.obstacleList = obstacleList;
        CalculateObstacles();
    }

    public AStar(Vector3 info, GameObject[] obstacleList)
    {
        numOfColumns = (int)info.x;
        numOfRows = (int)info.y;
        this.gridCellSize = (int)info.z;
        this.obstacleList = obstacleList;
        CalculateObstacles();
    }

    #region 
    public GameObject[] ObstacleList
    {
        get { return obstacleList; }
    }

    public int NumOfColumns
    {
        get { return numOfColumns; }
    }

    public int NumOfRows
    {
        get { return numOfRows; }
    }

    public float GridCellSize
    {
        get { return gridCellSize; }
    }

    private AStarNode[,] Nodes { get; set; }

    private Vector3 Origin
    {
        get { return mOrigin; }
    }
    #endregion

    /// <summary>
    /// AStart算法核心
    /// </summary>
    /// <param name="start"></param>
    /// <param name="goal"></param>
    /// <returns></returns>
    public List<AStarNode> FindPath(AStarNode start, AStarNode goal)
    {
        OpenList = new NodePriorityQueue();
        OpenList.Push(start);
        start.NodeTotalCost = 0.0f;
        start.EstimatedCost = HeuristicEstimateCost(start, goal);
        ClosedList = new NodePriorityQueue();
        AStarNode node = null;
        while (OpenList.Length != 0)
        {
            #region  对OpenList链表中的处理
            node = OpenList.First();
            //检查当前节点
            if (node.Position == goal.Position)
            {
                return CalculatePath(node);
            }
            //创建一个动态数组保存所有节点
            List<AStarNode> neighbours = new List<AStarNode>();
            GetNeighbours(node, neighbours);
            for (int i = 0; i < neighbours.Count; i++)
            {
                AStarNode neighbourNode = neighbours[i] as AStarNode;
                if (!ClosedList.Contains(neighbourNode))
                {
                    float cost = HeuristicEstimateCost(node, neighbourNode);
                    float totalCost = node.NodeTotalCost + cost;
                    float neighbourNodeEstCost = HeuristicEstimateCost(neighbourNode, goal);
                    neighbourNode.NodeTotalCost = totalCost;
                    neighbourNode.Parent = node;
                    //neighbourNode.EstimatedCost = totalCost + neighbourNodeEstCost;
                    neighbourNode.EstimatedCost = neighbourNodeEstCost;
                    //标记邻近节点并放入OpenList链表中
                    if (!OpenList.Contains(neighbourNode))
                    {
                        OpenList.Push(neighbourNode);
                    }
                }
            }
            //把当前节点放入到CloseList链表中 
            ClosedList.Push(node);
            #endregion 
            //把当前节点移除OpenList链表中 
            OpenList.Remove(node);
        }
        if (node.Position != goal.Position)
        {
            Debug.LogWarning("Goal Not Found");
            return null;
        }
        return CalculatePath(node);
    }

    /// <summary>
    /// 计算当前节点和目标节点值
    /// </summary>
    /// <param name="curNode"></param>
    /// <param name="goalNode"></param>
    /// <returns></returns>
    private float HeuristicEstimateCost(AStarNode curNode, AStarNode goalNode)
    {
        Vector3 vecCost = curNode.Position - goalNode.Position;
        return vecCost.magnitude;
    }

    private List<AStarNode> CalculatePath(AStarNode node)
    {
        List<AStarNode> list = new List<AStarNode>();
        while (node != null)
        {
            list.Add(node);
            node = node.Parent;
        }
        list.Reverse();
        return list;
    }

    /// <summary>
    /// 获取邻近节点坐标
    /// </summary>
    /// <param name="node"></param>
    /// <param name="neighbors"></param>
    private void GetNeighbours(AStarNode node, List<AStarNode> neighbors)
    {
        Vector3 neighborPos = node.Position;
        int neighborIndex = GetGridIndex(neighborPos);
        int row = GetRow(neighborIndex);
        int column = GetColumn(neighborIndex);
        //Bottom 
        int leftNodeRow = row - 1;
        int leftNodeColumn = column;
        AssignNeighbour(leftNodeRow, leftNodeColumn, neighbors);
        //Top  
        leftNodeRow = row + 1;
        leftNodeColumn = column;
        AssignNeighbour(leftNodeRow, leftNodeColumn, neighbors);
        //Right  
        leftNodeRow = row;
        leftNodeColumn = column + 1;
        AssignNeighbour(leftNodeRow, leftNodeColumn, neighbors);
        //Left  
        leftNodeRow = row;
        leftNodeColumn = column - 1;
        AssignNeighbour(leftNodeRow, leftNodeColumn, neighbors);
    }

    /// <summary>
    /// 判断临近节点是否在节点范围周边边界
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    private bool IsInBounds(Vector3 pos)
    {
        float width = numOfColumns * GridCellSize;
        float height = numOfRows * GridCellSize;
        return (pos.x >= Origin.x && pos.x <= Origin.x + width && pos.z <= Origin.z + height && pos.z >= Origin.z);
    }

    private int GetRow(int index)
    {
        int row = index / numOfColumns;
        return row;
    }

    private int GetColumn(int index)
    {
        int col = index % numOfColumns;
        return col;
    }

    private void AssignNeighbour(int row, int column, List<AStarNode> neighbors)
    {
        if (row != -1 && column != -1 && row < numOfRows && column < numOfColumns)
        {
            AStarNode nodeToAdd = Nodes[row, column];
            if (!nodeToAdd.IsObstacle)
            {
                neighbors.Add(nodeToAdd);
            }
        }
    }

    private Vector3 GetGridCellCenter(int index)
    {
        Vector3 cellPosition = GetGridCellPosition(index);
        cellPosition.x += (GridCellSize / 2.0f);
        cellPosition.z += (GridCellSize / 2.0f);
        return cellPosition;
    }

    private Vector3 GetGridCellPosition(int index)
    {
        int row = GetRow(index);
        int col = GetColumn(index);
        float xPosInGrid = col * GridCellSize;
        float zPosInGrid = row * GridCellSize;
        return Origin + new Vector3(xPosInGrid, 0.0f, zPosInGrid);
    }

    private int GetGridIndex(Vector3 pos)
    {
        if (!IsInBounds(pos))
            return -1;
        pos -= Origin;
        int col = (int)(pos.x / GridCellSize);
        int row = (int)(pos.z / GridCellSize);
        return (row * numOfColumns + col);
    }

    public Vector3 GetGridCellCenter(Vector3 position)
    {
        return GetGridCellCenter(GetGridIndex(position));
    }

    /// <summary>
    /// 寻找所有障碍物
    /// </summary>
    private void CalculateObstacles()
    {
        Nodes = new AStarNode[NumOfColumns, NumOfRows];
        int index = 0;
        for (int i = 0; i < NumOfColumns; i++)
        {
            for (int j = 0; j < NumOfRows; j++)
            {
                Vector3 cellPos = GetGridCellCenter(index);
                AStarNode node = new AStarNode(cellPos);
                Nodes[i, j] = node;
                index++;
            }
        }
        if (obstacleList != null && obstacleList.Length > 0)
        {
            foreach (GameObject data in obstacleList)
            {
                int indexCell = GetGridIndex(data.transform.position);
                int col = GetColumn(indexCell);
                int row = GetRow(indexCell);
                Nodes[row, col].MarkAsObstacle();
            }
        }
    }
}