using UnityEngine;
using System.Collections;

public class SpecialMove : MonoBehaviour {
	PieceInit pieceInit;
	CanMoveCursorCreate cursorcreate;
	hpBerCreate hpbercreate;
	Sound sound;
	// Use this for initialization
	void Start () {
		pieceInit = GameObject.Find ("PieceInit").GetComponent<PieceInit> ();
		cursorcreate = GameObject.Find("CanMoveCreateCursor").GetComponent<CanMoveCursorCreate>();
		hpbercreate=GameObject.Find("hpBerGUI").GetComponent<hpBerCreate>();
		sound=GameObject.Find("SoundControl").GetComponent<Sound>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Special(int dan,int suji){
		int mdan = 0;
		int msuji = 0;
		cursorcreate.CursorDestroy ();
		switch(pieceInit.board[dan,suji]){
		case 17:
		case 33:
			pieceInit.board[dan,suji]+=pieceInit.PROMOTED;
			sound.PutSound(2);
			break;
		case 18:
			for(int lance=dan-1;lance>=0;lance--){
				pieceInit.board[lance,suji]=0;
			}
			sound.PutSound(3);
			break;
		case 19:
			if((suji-1)>=0){
				pieceInit.board[dan-2,suji-1]=0;
			}
			if((suji+1)<=8){
				pieceInit.board[dan-2,suji+1]=0;
			}
			sound.PutSound(4);
			break;
		case 20:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.SGI]==1){
						pieceInit.board[(dan-i),(suji+j)]=0;
					}
					else{}
				}
			}
			sound.PutSound(5);
			break;
		case 21:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.SKI]==1){
						pieceInit.board[(dan-i),(suji+j)]=0;
					}
					else{}
				}
			}
			sound.PutSound(6);
			break;
		case 22:
		case 38:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8 || (i==0 && j==0)){
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SKA]==1){
							pieceInit.board[dan-i*mass,suji+j*mass]=0;
						}
					}
				}
			}
			sound.PutSound(7);
			break;
		case 23:
		case 39:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8 || (i==0 && j==0)){
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SHI]==1){
							pieceInit.board[dan-i*mass,suji+j*mass]=0;
						}
					}
				}
			}
			sound.PutSound(8);
			break;
		case 24:
			mdan=0;
			msuji=0;
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.board[dan-i,suji+j]==pieceInit.EMP){
						mdan=dan-i;
						msuji=suji+j;
					}
					else{}
				}
			}
			pieceInit.board[mdan,msuji]=24;
			sound.PutSound(9);
			break;
		case 25:
			pieceInit.board[dan,suji]=pieceInit.SRY;
			sound.PutSound(10);
			break;
		case 26:
			pieceInit.board[dan,suji]=pieceInit.SHI;
			sound.PutSound(10);
			break;
		case 27:
			pieceInit.board[dan,suji]=pieceInit.SUM;
			sound.PutSound(10);
			break;
		case 28:
			pieceInit.board[dan,suji]=pieceInit.SKI;
			sound.PutSound(10);
			break;
		case 30:
		case 31:
			pieceInit.board[dan,suji]-=pieceInit.PROMOTED;
			sound.PutSound(11);
			break;
		case 34:
			for(int lance=dan+1;lance<=8;lance++){
				pieceInit.board[lance,suji]=0;
			}
			sound.PutSound(3);
			break;
		case 35:
			if((suji-1)>=0){
				pieceInit.board[dan+2,suji-1]=0;
			}
			if((suji+1)<=8){
				pieceInit.board[dan+2,suji+1]=0;
			}
			sound.PutSound(4);
			break;
		case 36:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.EGI]==1){
						pieceInit.board[(dan-i),(suji+j)]=0;
					}
					else{}
				}
			}
			sound.PutSound(5);
			break;
		case 37:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.EKI]==1){
						pieceInit.board[(dan-i),(suji+j)]=0;
					}
					else{}
				}
			}
			sound.PutSound(6);
			break;
		case 40:
			mdan=0;
			msuji=0;
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.board[dan-i,suji+j]==pieceInit.EMP){
						mdan=dan-i;
						msuji=suji+j;
					}
					else{}
				}
			}
			pieceInit.board[mdan,msuji]=40;
			sound.PutSound(9);
			break;
		case 41:
			pieceInit.board[dan,suji]=pieceInit.ERY;
			sound.PutSound(10);
			break;
		case 42:
			pieceInit.board[dan,suji]=pieceInit.EHI;
			sound.PutSound(10);
			break;
		case 43:
			pieceInit.board[dan,suji]=pieceInit.EUM;
			sound.PutSound(10);
			break;
		case 44:
			pieceInit.board[dan,suji]=pieceInit.EKI;
			sound.PutSound(10);
			break;
		case 46:
		case 47:
			pieceInit.board[dan,suji]-=pieceInit.PROMOTED;
			sound.PutSound(11);
			break;
		default:
			break;
		}
		if(pieceInit.SorE==pieceInit.SELF){
			hpbercreate.SelfHP = 0;
		}
		else{
			hpbercreate.EnemyHP = 0;
		}
	}
}
