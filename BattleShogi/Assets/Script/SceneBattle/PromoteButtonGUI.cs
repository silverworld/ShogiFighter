using UnityEngine;
using System.Collections;

public class PromoteButtonGUI : MonoBehaviour {
	private float width;

	PieceInit pieceInit;
	public Vector3 toPos;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		width = Screen.width;
		pieceInit=GameObject.Find("PieceInit").GetComponent<PieceInit>();
	}
	
	// Update is called once per frame
	void Update () {
		toPos = new Vector3 (pieceInit.todan,pieceInit.tosuji,-5);
		pos=camera.WorldToScreenPoint(toPos);
	}

	void OnGUI(){
		if(pieceInit.promoteGUIflag==true) {
			if(GUI.Button(new Rect(pos.y,pos.x-width/3,40,20),"成")){
				pieceInit.promoteflag=true;
				pieceInit.promoteGUIflag=false;
				pieceInit.TakePiece();
			}		
			if(GUI.Button(new Rect(pos.y,pos.x-width/3+20,40,20),"不成")){
				pieceInit.promoteGUIflag=false;
				pieceInit.TakePiece();
			}	
		}
	}
}
