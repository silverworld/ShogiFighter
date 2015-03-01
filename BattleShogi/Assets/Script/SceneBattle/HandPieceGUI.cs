using UnityEngine;
using System.Collections;

public class HandPieceGUI : MonoBehaviour {
	PieceInit pieceInit;
	private int x;
	private int y;

	private float height;
	private float width;

	public GameObject SelfHandBoard;
	public GameObject EnemyHandBoard;
	private Vector3 Selfpos;
	private Vector3 Enemypos;

	public GUIStyle TurnStyle;
	// Use this for initialization
	void Start () {
		pieceInit=GameObject.Find("PieceInit").GetComponent<PieceInit>();
		height = Screen.height;
		width = Screen.width;

		TurnStyle = new GUIStyle();
		TurnStyle.fontSize = 30;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		Selfpos = camera.WorldToScreenPoint(SelfHandBoard.transform.position);
		Enemypos = camera.WorldToScreenPoint(EnemyHandBoard.transform.position);
		x=0;
		y=0;
		for(int i=pieceInit.SFU;i<=pieceInit.SHI;i++){
			if(pieceInit.hand[i]>1){
				Rect r = new Rect(Selfpos.x+x*height/336*32-height/336*30, Selfpos.y+y*width/456*25+width/456*70, 50, 50);
				GUI.Label(r, "×"+pieceInit.hand[i]);
				x++;
			}
			else{
				x++;
			}
			if(x%3==0){
				x=0;
				y++;
			}
		}
		for(int i=pieceInit.EFU;i<=pieceInit.EHI;i++){
			if(pieceInit.hand[i]>1){
				Rect r = new Rect(Enemypos.x-x*height/336*32+height/336*70, Enemypos.y-y*width/456*25-width/456*30, 50, 50);
				GUI.Label(r, "×"+pieceInit.hand[i]);
				x++;
			}
			else{
				x++;
			}
			if(x%3==0){
				x=0;
				y++;
			}
		}
		GUI.Label (new Rect(width/20, height - height / 5, 40, 40),pieceInit.Tesu+"手目",TurnStyle);
		if (pieceInit.SorE == pieceInit.SELF) {
			GUI.Label (new Rect (width/20, height - height / 10, 40, 40), "先手の番", TurnStyle);
		} 
		else {
			GUI.Label (new Rect (width/20, height - height / 10, 40, 40), "後手の番", TurnStyle);
		}
	}
}
