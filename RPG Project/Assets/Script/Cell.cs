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

    // Use this for initialization
    void Start () {
        gcRef = FindObjectOfType<GameControl>();
        playerRef = FindObjectOfType<Player>();
        
    }
	
	// Update is called once per frame
	void Update () {
        fg = FindObjectOfType<FogOfWar>();
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
                fg.Fog(pos);
                //
            }
            

        }
        else if(gcRef.phase == GamePhase.Movimento)
        {
            if (isFree)
            {
                
                playerRef.MovePlayer(myI,myJ);
                gcRef.phase = GamePhase.Selezione;
                gcRef.firstCell.GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;
                
                

            }
            
        }


    }
}
