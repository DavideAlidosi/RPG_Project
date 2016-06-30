using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

    public GameObject cell;
    Player playerLinking;

    public Cell[,] cellMat;
    GameControl refGC;

	// Use this for initialization
	void Start () {
        refGC = FindObjectOfType<GameControl>();
        playerLinking = FindObjectOfType<Player>(); ;
        int n = 0;
        cellMat = new Cell[20, 19];

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 19; j++)
            {

                GameObject newCellGO = Instantiate(cell);
                newCellGO.transform.position = new Vector3(j-10, i-8, 0);
                cellMat[i, j] = newCellGO.GetComponent<Cell>();
                cellMat[i, j].myI = i;
                cellMat[i, j].myJ = j;
                newCellGO.name = i + " " + j;
                
                n++;

                if (n == 200)
                {
                    cellMat[i, j].isSpawnCell = true;
                    
                    
                }
            }
        }
        playerLinking.SpawnPlayer();
	}
	
	// Update is called once per frame
	void Update () {
        /*if (refGC.phase == GamePhase.Movimento)
        {
            foreach (var cell in cellMat)
            {
                cell.GetComponent<SpriteRenderer>().color = Color.blue;
                cell.isFree = true;

            }
        }
        
        
            int n = 0;
            foreach (var cell in cellMat)
            {
                if (n % 2 == 0)
                {
                    cell.GetComponent<SpriteRenderer>().color = Color.black;

                }
                else
                {
                    cell.GetComponent<SpriteRenderer>().color = Color.white;
                }
                cell.isFree = false;
                n++;
            }
        }*/
	}

    
}
