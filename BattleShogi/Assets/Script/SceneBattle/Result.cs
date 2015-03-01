using UnityEngine;
using System.Collections;

public class Result : MonoBehaviour {
	private int height;
	private int width;
	
	Color color;
	GUIStyle style;
	PieceInit init;

	PieceInit pieceInit;

	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;
		style = new GUIStyle ();
		style.normal.textColor = Color.yellow;
		style.fontSize = 50;
		pieceInit=GameObject.Find("PieceInit").GetComponent<PieceInit>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void OnGUI(){
		switch(pieceInit.Jadgement){
		case 1:
			GUI.Label(new Rect(width/2.7f, height/2.2f, width/3, height/10), "先手の勝ち",style);
			break;
		case 2:
			GUI.Label(new Rect(width/2.7f, height/2.2f, width/3, height/10), "後手の勝ち",style);
			break;
		case 3:
			GUI.Label(new Rect(width/2.7f, height/2.2f, width/3, height/10), " 引き分け ",style);
			break;
		default:
			
			break;
		}
		if (pieceInit.Jadgement!=0 && GUI.Button (new Rect (width/3f, height/1.2f, width/3, height/10), "タイトル画面に戻る")) {
			Application.LoadLevel("Title");		
		}
	}
}

