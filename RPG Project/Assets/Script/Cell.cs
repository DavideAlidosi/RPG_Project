using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {
    public int myI, myJ;
    public bool isSpawnCell = false;
    GameControl gcRef;
    public SpriteRenderer sBox;
    public bool isFree = false;
    public Player playerRef;
    Vector2 pos;
    public FogOfWar fg;
    public bool isWall = false;
    public bool isCombat = false;
    public Enemy enemyRef;

    // Use this for initialization
    void Start () {
        gcRef = FindObjectOfType<GameControl>();
        playerRef = FindObjectOfType<Player>();
        fg = FindObjectOfType<FogOfWar>();
        enemyRef = GetComponentInChildren<Enemy>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isWall)
        {
            GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    void OnMouseUp()
    {
        
        
        if (gcRef.phase == GamePhase.Selezione)
        {
            
            if (GetComponentInChildren<Player>())
            {

                sBox.color = Color.green;
                gcRef.phase++;
                gcRef.firstCell = this.gameObject;
                
                pos = new Vector2(myI, myJ);
                fg.Fog(pos,4);
                fg.AStar();
                //<enemyRef.CheckAdjacent();
            }
            

        }
        else if(gcRef.phase == GamePhase.Movimento)
        {
            if (isFree)
            {
                
                playerRef.MovePlayer(myI,myJ);
                if (isCombat)
                {
                    gcRef.phase = GamePhase.Combattimento;
                    gcRef.firstCell.GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;
                    fg.CleanMove();

                }
                else if(!isCombat)
                {
                    gcRef.phase = GamePhase.Selezione;
                    gcRef.firstCell.GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;
                    fg.CleanMove();
                }
            }
        }
        else if (gcRef.phase == GamePhase.Combattimento)
        {
            if (GetComponentInChildren<Enemy>() && GetComponentInChildren<Enemy>().isNear)
            {
                Destroy(GetComponentInChildren<Enemy>().gameObject);
                gcRef.phase = GamePhase.Selezione;
            }
        }


    }
}
