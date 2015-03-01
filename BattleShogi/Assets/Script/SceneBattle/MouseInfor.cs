using UnityEngine;
using System.Collections;

public class MouseInfor : MonoBehaviour {
	private Vector3 cameraVec;
	PieceInit pieceInit;
	SpecialMove spemove;
	// Use this for initialization
	void Start () {
		pieceInit=GameObject.Find("PieceInit").GetComponent<PieceInit>();
		spemove=GameObject.Find("SpecialMoveCreate").GetComponent<SpecialMove>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("mouse 0") && pieceInit.promoteGUIflag==false && pieceInit.Jadgement==0) {
			cameraVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			for(int dan=0;dan<9;dan++){
				for(int suji=0;suji<9;suji++){
					if(suji-4.5<cameraVec.x && cameraVec.x<suji-3.5 && 4.5-dan>cameraVec.y && cameraVec.y>3.5-dan){
						if(pieceInit.SelfSpecialFlag==true && pieceInit.SorE==pieceInit.SELF && pieceInit.SFU<=pieceInit.board[dan,suji] && pieceInit.board[dan,suji]<=pieceInit.SRY){
							pieceInit.SelfSpecialFlag=false;
							spemove.Special(dan,suji);
							pieceInit.BoardDisplay();
						}
						else if(pieceInit.EnemySpecialFlag==true && pieceInit.SorE==pieceInit.ENEMY && pieceInit.EFU<=pieceInit.board[dan,suji] && pieceInit.board[dan,suji]<=pieceInit.ERY){
							pieceInit.EnemySpecialFlag=false;
							spemove.Special(dan,suji);
							pieceInit.BoardDisplay();
						}
						else if(pieceInit.fromFlag == false && pieceInit.FU+pieceInit.SorE<=pieceInit.board[dan,suji] && pieceInit.board[dan,suji]<=pieceInit.RY+pieceInit.SorE){
							pieceInit.RecieveFromMessage(dan,suji);
						}
						else if(pieceInit.fromFlag == true && pieceInit.handPieceflag==true && pieceInit.FU+pieceInit.SorE<=pieceInit.board[dan,suji] && pieceInit.board[dan,suji]<=pieceInit.RY+pieceInit.SorE){
							pieceInit.handPieceflag=false;
							pieceInit.RecieveFromMessage(dan,suji);
						}
						else if(pieceInit.fromFlag == true){
							pieceInit.RecieveToMessage(dan,suji);
						}
						else{}
					}
				}
			}
			int x=0;
			int y=0;
			for(int i=pieceInit.FU;i<=pieceInit.HI;i++){
				if(5.8+x*1.5<cameraVec.x && cameraVec.x<6.8+x*1.5 && -2-y*1.2<cameraVec.y && -1-y*1.2>cameraVec.y && pieceInit.hand[i+pieceInit.SELF]>=1 && pieceInit.SorE==pieceInit.SELF && pieceInit.SelfSpecialFlag==false
				   ){
					pieceInit.handPieceflag=true;
					pieceInit.toFlag=false;
					pieceInit.RecieveFromMessage(i,0);
				}
				else if(-5.8-x*1.5>cameraVec.x && cameraVec.x>-6.8-x*1.5 && 2+y*1.2>cameraVec.y && 1+y*1.2<cameraVec.y && pieceInit.hand[i+pieceInit.ENEMY]>=1 && pieceInit.SorE==pieceInit.ENEMY && pieceInit.EnemySpecialFlag==false){
					pieceInit.handPieceflag=true;
					pieceInit.toFlag=false;
					pieceInit.RecieveFromMessage(i,0);
				}
				else{}
				x++;
				if(x%3==0){
					x=0;
					y++;
				}
			}
		}
		if (pieceInit.fromFlag == true && pieceInit.toFlag == true && pieceInit.promoteGUIflag == false) {
			pieceInit.MoveCheck ();
		}
	}
}