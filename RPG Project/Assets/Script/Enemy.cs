using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int str;
    public int cos;
    public int hp;
    public bool isNear = false;    
    Grid refGrid;
    public Cell refMyCell;
    // Use this for initialization
    void Start () {

        refGrid = FindObjectOfType<Grid>();
        refMyCell = GetComponentInParent<Cell>();
        //str = 4;
        cos = 3;
        hp = 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    
    


}
