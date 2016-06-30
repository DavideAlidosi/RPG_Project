using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public SpriteRenderer sr;
    Grid gridRef;
    GameControl gcRef;
    // Use this for initialization
    void Awake()
    {
        
    }
	void Start () {
        gcRef = FindObjectOfType<GameControl>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SpawnPlayer()
    {
        gridRef = FindObjectOfType<Grid>();

        for (int i = 0; i < 20; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                if (gridRef.cellMat[i, j].isSpawnCell)
                {                   
                    this.transform.parent = gridRef.cellMat[i, j].transform;
                    this.transform.localPosition = new Vector3(0, 0, 1);
                }
            }
        }
    }

    public void MovePlayer(int iCell, int jCell)
    {
        this.transform.parent = gridRef.cellMat[iCell, jCell].transform;
        this.transform.localPosition = new Vector3(0, 0, 1);
    }

    void OnMouseUp()
    {
        
    }

    
}
