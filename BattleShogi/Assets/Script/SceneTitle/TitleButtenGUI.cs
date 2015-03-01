using UnityEngine;
using System.Collections;

public class TitleButtenGUI : MonoBehaviour {
	private int height;
	private int width;
	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if (GUI.Button (new Rect (width/3f, height/1.3f, width/3, height/10), "対局開始")) {
			Application.LoadLevel("Battle");		
		}
	}
}
