using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int str;
    public int cos;
    public int hp;
    public bool isNear = false;
    Grid refGrid;
    // Use this for initialization
    void Start () {

        refGrid = FindObjectOfType<Grid>();
        //str = 4;
        cos = 3;
        hp = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CheckAdjacent()
    {
        int newI = GetComponentInParent<Cell>().myI;
        int newJ = GetComponentInParent<Cell>().myJ;

        if (refGrid.cellMat[newI + 1, newJ].GetComponentInChildren<Player>())
        {
            isNear = true;
        }

        if (refGrid.cellMat[newI - 1, newJ].GetComponentInChildren<Player>())
        {
            isNear = true;
        }

        if (refGrid.cellMat[newI, newJ + 1].GetComponentInChildren<Player>())
        {
            isNear = true;
        }

        if (refGrid.cellMat[newI, newJ - 1].GetComponentInChildren<Player>())
        {
            isNear = true;
        }
    }
}
