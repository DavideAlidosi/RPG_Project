using UnityEngine;
using System.Collections;
public enum GamePhase {Selezione, Movimento,Azione,Combattimento,TurnoNemici,FineTurno }
public class GameControl : MonoBehaviour {
    public GamePhase phase = GamePhase.Selezione;
    public GameObject firstCell;
 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
