using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
    public GameObject playerPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(playerPosition.transform.position.x, playerPosition.transform.position.y, -10);
	}
}
