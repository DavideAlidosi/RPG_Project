using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FogOfWar : MonoBehaviour {

    private Grid grid;
    //private int vista = 4;
    public List<Cell> enemyCell = new List<Cell>();
    public List<Cell> destroyCell = new List<Cell>();
    //Cell enemyCell;

    void Start()
    {
        grid = FindObjectOfType<Grid>();
    }

    public void Fog(Vector2 pos,int vista)
    {
        int _x = (int)pos.x;
        int _y = (int)pos.y;

        Vector2[] directions = new Vector2[4];

        directions[0] = new Vector2(-1, 0);
        directions[1] = new Vector2(0, -1);
        directions[2] = new Vector2(1, 0);
        directions[3] = new Vector2(0, 1);

        for (int i = (_x - vista); i <= (_x + vista); i++)
        {
            for (int y = (_y - vista); y <= (_y + vista); y++)
            {


                if (i < 0)
                    continue;
                if (y < 0)
                    continue;
                if (i > 19)
                    continue;
                if (y > 19)
                    continue;

                if (grid.cellMat[i,y].isWall)
                {
                    continue;
                }
                if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (vista))
                {
                    SpriteRenderer sr = grid.cellMat[i, y].gameObject.GetComponent<SpriteRenderer>();
                    sr.color = Color.blue;
                    grid.cellMat[i, y].isFree = true;
                    destroyCell.Add(grid.cellMat[i, y]);

                    if (grid.cellMat[i,y].GetComponentInChildren<Enemy>())
                    {
                        enemyCell.Add(grid.cellMat[i, y]);
                        //enemyCell = grid.cellMat[i, y];
                        grid.cellMat[i, y].isFree = false;
                        grid.cellMat[i, y].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                    
                }
                //Per rendere le celle meno visibili
                /*if (Mathf.Abs(i - _x) + Mathf.Abs(y - _y) <= (vista / 2))
                {
                    SpriteRenderer sr = grid.cellMat[i, y].gameObject.GetComponent<SpriteRenderer>();
                    sr.color = Color.clear;
                }*/


            }
        }
        if (enemyCell != null)
        {
            GetEnemy();
        }
        
    }

    public void AStar()
    {
        List<Cell> controlled = new List<Cell>();
        bool find = true;
        foreach (var cell in destroyCell)
        {
            
            if (cell.myI < 0)
                continue;
            if (cell.myJ < 0)
                continue;
            if (cell.myI > 18)
                continue;
            if (cell.myJ > 18)
                continue;

            if (grid.cellMat[cell.myI+1,cell.myJ].isFree)            
                continue;
            if (grid.cellMat[cell.myI, cell.myJ+1].isFree)            
                continue;
            if (grid.cellMat[cell.myI - 1, cell.myJ].isFree)
                continue;
            if (grid.cellMat[cell.myI, cell.myJ - 1].isFree)
                continue;

            
            
            cell.isFree = false;
            
            cell.GetComponent<SpriteRenderer>().color = Color.white;
            

        }
    }

    public void CleanMove()
    {
        foreach (var cell in destroyCell)
        {
            cell.isFree = false;
            cell.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        destroyCell.Clear();        
    }

    void GetEnemy()
    {
        foreach (var cell in enemyCell)
        {
            int newI = cell.myI;
            int newJ = cell.myJ;
            if (grid.cellMat[newI + 1, newJ].isFree)
            {
                grid.cellMat[newI + 1, newJ].isCombat = true;
                grid.cellMat[newI + 1, newJ].GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (grid.cellMat[newI - 1, newJ].isFree)
            {
                grid.cellMat[newI - 1, newJ].isCombat = true;
                grid.cellMat[newI - 1, newJ].GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (grid.cellMat[newI, newJ + 1].isFree)
            {
                grid.cellMat[newI, newJ + 1].isCombat = true;
                grid.cellMat[newI, newJ + 1].GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (grid.cellMat[newI, newJ - 1].isFree)
            {
                grid.cellMat[newI, newJ - 1].isCombat = true;
                grid.cellMat[newI, newJ - 1].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        enemyCell.Clear();

        
    }
}
