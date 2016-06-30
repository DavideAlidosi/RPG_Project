using UnityEngine;
using System.Collections;

public class PopUp : MonoBehaviour {

    public bool isOver;

	// Use this for initialization
	void Start () {
	
	}

    void OnMouseOver()
    {
        Debug.Log("Over it!!!");
        isOver = true;
    }

    // Update is called once per frame
    void Update () {

    }
}
