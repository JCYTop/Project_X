using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStartGizmos
{
    private AStar aStar;
    public bool ShowGrid = true;
    public bool ShowObstacleBlocks = true;
    private GameObject plane;

    public AStartGizmos(AStar aStar, GameObject plane, bool ShowGrid = true, bool ShowObstacleBlocks = true)
    {
        this.aStar = aStar;
        this.plane = plane;
        this.ShowGrid = ShowGrid;
        this.ShowObstacleBlocks = ShowObstacleBlocks;
    }

    public void OnDrawGizmos(List<AStarNode> PathArray)
    {
        if (ShowGrid)
        {
            DebugDrawGrid(plane.transform.position, aStar.NumOfRows, aStar.NumOfColumns, aStar.GridCellSize, Color.red);
        }
        Gizmos.DrawSphere(plane.transform.position, 0.5f);
        if (ShowObstacleBlocks)
        {
            Vector3 cellSize = new Vector3(aStar.GridCellSize, 1.0f, aStar.GridCellSize);
            if (aStar.ObstacleList != null && aStar.ObstacleList.Length > 0)
            {
                foreach (GameObject data in aStar.ObstacleList)
                {
                    Gizmos.DrawCube(aStar.GetGridCellCenter(data.transform.position), cellSize);
                }
            }
        }
        if (PathArray == null)
            return;
        if (PathArray.Count > 0)
        {
            int index = 1;
            foreach (AStarNode node in PathArray)
            {
                if (index < PathArray.Count)
                {
                    AStarNode nextNode = PathArray[index];
                    Debug.DrawLine(node.Position, nextNode.Position, Color.green);
                    index++;
                }
            }
        }
    }

    public void DebugDrawGrid(Vector3 origin, int numRows, int numCols, float cellSize, Color color)
    {
        float width = (numCols * cellSize);
        float height = (numRows * cellSize);
        for (int i = -numRows - 1 / 2; i < numRows + 1; i++)
        {
            Vector3 startPos = origin + i * cellSize * new Vector3(0.0f, 0.0f, 1.0f);
            Vector3 endPos = startPos + width * new Vector3(1.0f, 0.0f, 0.0f);
            Debug.DrawLine(startPos, endPos, color);
            //Debug.DrawLine(-startPos, -endPos, color);
        }
        for (int i = -numCols - 1 / 2; i < numCols + 1; i++)
        {
            Vector3 startPos = origin + i * cellSize * new Vector3(1.0f, 0.0f, 0.0f);
            Vector3 endPos = startPos + height * new Vector3(0.0f, 0.0f, 1.0f);
            Debug.DrawLine(startPos, endPos, color);
            //Debug.DrawLine(-startPos, -endPos, color);
        }
    }
}
