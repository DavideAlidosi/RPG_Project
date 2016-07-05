using UnityEngine;
using System.Collections;
public enum GamePhase {Selezione, Movimento,Azione,Combattimento,TurnoNemici,FineTurno }
public class GameControl : MonoBehaviour {
    public GamePhase phase = GamePhase.Selezione;
    public GameObject playerCell;
    public GameObject enemyCell;

    Player plRef;
    FogOfWar fogRef;
    MenuPopUp refMPU;

    // Use this for initialization
    void Start () {
        plRef = FindObjectOfType<Player>();
        fogRef = FindObjectOfType<FogOfWar>();
        refMPU = FindObjectOfType<MenuPopUp>();
    }
	
	// Update is called once per frame
	void Update () {
        if (phase == GamePhase.Azione)
        {
            if (Input.GetMouseButtonUp(1))
            {
                plRef.MovePlayer(playerCell.GetComponent<Cell>().myI, playerCell.GetComponent<Cell>().myJ);
                phase = GamePhase.Selezione;
                fogRef.CleanMove();
                refMPU.Deactivate();
                playerCell.GetComponent<Cell>().sBox.GetComponent<SpriteRenderer>().color = Color.clear;

            }
        }
        
    }
}
