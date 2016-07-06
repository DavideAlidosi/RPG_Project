using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnemyTurn()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        foreach (var enemy in enemies)
        {
            enemy.ManhattanSearch();
            enemy.SearchPlayer();
            enemy.MoveEnemy();
        }
    }
}
