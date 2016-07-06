using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour {

    public int str;
    public int cos;
    public int hp;
    public int agi;
    public bool isNear = false;
    public bool isPlayerVisible = false;
    Grid refGrid;
    int vista;
    GameControl refGC;
    public Cell refMyCell;
    public Cell nearestCell;
    public List<Cell> mnhttnCell = new List<Cell>();

    // Use this for initialization
    void Start () {

        refGrid = FindObjectOfType<Grid>();
        refMyCell = GetComponentInParent<Cell>();
        refGC = FindObjectOfType<GameControl>();
        //str = 4;
        cos = 3;
        hp = cos*4;
        agi = Random.Range(1,10);
        vista = 4;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Test()
    {
        Debug.Log("Test");
    }



    public void ManhattanSearch()
    {
        int myI = refMyCell.myI;
        int myJ = refMyCell.myJ;
        mnhttnCell.Clear();
        isPlayerVisible = false;

        for (int i = (myI - vista); i <= (myI + vista); i++)
        {
            for (int j = (myJ - vista); j <= (myJ + vista); j++)
            {
                if (i < 0)
                    continue;
                if (j < 0)
                    continue;
                if (i > 19)
                    continue;
                if (j > 19)
                    continue;

                if (refGrid.cellMat[i, j].isWall)
                {
                    continue;
                }
                if (refGrid.cellMat[i, j].GetComponentInChildren<Player>())
                {
                    isPlayerVisible = true;
                    continue;
                }
                if (refGrid.cellMat[i, j].GetComponentInChildren<Enemy>())
                {
                    continue;
                }
                if (Mathf.Abs(i - myI) + Mathf.Abs(j - myJ) <= (vista))
                {
                    mnhttnCell.Add(refGrid.cellMat[i,j]);
                    //refGrid.cellMat[i, j].GetComponent<SpriteRenderer>().color = Color.red;
                }
            }
        }
    }

    public void SearchPlayer()
    {
        //Cell nearestCell;
        int playerX = refGC.playerCell.GetComponent<Cell>().myI;
        int playerY = refGC.playerCell.GetComponent<Cell>().myJ;
        int distance = 1000;

        if (isPlayerVisible)
        {
            foreach (var cell in mnhttnCell)
            {


                if (distance > Mathf.Abs(playerX - cell.myI) + Mathf.Abs(playerY - cell.myJ))
                {
                    distance = Mathf.Abs(playerX - cell.myI) + Mathf.Abs(playerY - cell.myJ);
                    nearestCell = cell;

                }
            }
        }
        
    }

    public void MoveEnemy()
    {
        if (nearestCell != null)
        {
            int nearestI = nearestCell.myI;
            int nearestJ = nearestCell.myJ;
            this.transform.parent = refGrid.cellMat[nearestI, nearestJ].transform;
            this.transform.localPosition = new Vector3(0, 0, 1);
            refMyCell = nearestCell;
            nearestCell = null;
        }
    }

}
