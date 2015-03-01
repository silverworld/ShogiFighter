using UnityEngine;
using System.Collections;

public class KiKiCheck : MonoBehaviour {
	public int[,] SelfKiKi;
	public int[,] EnemyKiKi;

	PieceInit pieceInit;
	hpBerCreate hpbercreate;

	bool[] CanJumpFlag;
	// Use this for initialization
	void Start () {
		pieceInit=GameObject.Find("PieceInit").GetComponent<PieceInit>();
		hpbercreate=GameObject.Find("hpBerGUI").GetComponent<hpBerCreate>();

		SelfKiKi = new int[9,9]{
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0}
		};
		EnemyKiKi = new int[9,9]{
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0}
		};
	}

	public void CanMove(int dan,int suji,int Koma){

		switch(Koma){
		case 17:
			if((dan-1)<0){
				break;
			}
			if(pieceInit.board[dan-1,suji]==pieceInit.EMP || pieceInit.EFU<=pieceInit.board[dan-1,suji] && pieceInit.board[dan-1,suji]<=pieceInit.ERY){
				SelfKiKi[dan-1,suji]=1;
			}
			break;
		case 18:
			for(int lanceMove=1;lanceMove<=dan;lanceMove++){
				if(pieceInit.board[dan-lanceMove,suji]==pieceInit.EMP){
					SelfKiKi[dan,suji]=1;
				}
				else if(pieceInit.EFU<=pieceInit.board[dan-lanceMove,suji] && pieceInit.board[dan-lanceMove,suji]<=pieceInit.ERY){
					SelfKiKi[dan-lanceMove,suji]=1;
					break;
				}
				else{
					break;
				}
			}
			break;
		case 19:
			if((dan-2)<0 || (suji-1)<0 || (suji+1)>8){
				break;
			}
			if(pieceInit.board[dan-2,suji-1]<pieceInit.SFU || pieceInit.SRY<pieceInit.board[dan-2,suji-1]){
				SelfKiKi[dan-2,suji-1]=1;
			}
			if(pieceInit.board[dan-2,suji+1]<pieceInit.SFU || pieceInit.SRY<pieceInit.board[dan-2,suji+1]){
				SelfKiKi[dan-2,suji+1]=1;
			}
			break;
		case 20:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.SFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.SRY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.SGI]==1){
						SelfKiKi[(dan-i),(suji+j)]=1;
					}
					else{}
				}
			}
			break;
		case 21:
		case 25:
		case 26:
		case 27:
		case 28:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.SFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.SRY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.SKI]==1){
						SelfKiKi[(dan-i),(suji+j)]=1;
					}
					else{}
				}
			}
			break;
		case 22:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SKA]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		case 23:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SHI]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		case 24:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.SFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.SRY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.SOU]==1){
						SelfKiKi[(dan-i),(suji+j)]=1;
					}
					else{}
				}
			}
			break;
		case 30:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.SFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.SRY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.SUM]==1){
						SelfKiKi[(dan-i),(suji+j)]=1;
					}
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SUM]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		case 31:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.SFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.SRY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.SRY]==1){
						SelfKiKi[(dan-i),(suji+j)]=1;
					}
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SRY]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		case 33:
			if((dan+1)>8){
				break;
			}
			if(pieceInit.board[dan+1,suji]==pieceInit.EMP || pieceInit.SFU<=pieceInit.board[dan+1,suji] && pieceInit.board[dan+1,suji]<=pieceInit.SRY){
				EnemyKiKi[dan+1,suji]=1;
			}
			break;
		case 34:
			for(int lanceMove=1;lanceMove<=8-dan;lanceMove++){
				if(pieceInit.board[dan+lanceMove,suji]==pieceInit.EMP){
					EnemyKiKi[dan+lanceMove,suji]=1;
				}
				else if(pieceInit.SFU<=pieceInit.board[dan+lanceMove,suji] && pieceInit.board[dan+lanceMove,suji]<=pieceInit.SRY){
					EnemyKiKi[dan+lanceMove,suji]=1;
					break;
				}
				else{
					break;
				}
			}
			break;
		case 35:
			if((dan+2)<0 || (suji-1)<0 || (suji+1)>8){
				break;
			}
			if(pieceInit.board[dan+2,suji-1]<pieceInit.EFU || pieceInit.ERY<pieceInit.board[dan+2,suji-1]){
				EnemyKiKi[dan+2,suji-1]=1;
			}
			if(pieceInit.board[dan+2,suji+1]<pieceInit.EFU || pieceInit.ERY<pieceInit.board[dan+2,suji+1]){
				EnemyKiKi[dan+2,suji+1]=1;
			}
			break;
		case 36:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.EFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.ERY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.EGI]==1){
						EnemyKiKi[(dan-i),(suji+j)]=1;
					}
					else{}
				}
			}
			break;
		case 37:
		case 41:
		case 42:
		case 43:
		case 44:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.EFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.ERY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.EKI]==1){
						EnemyKiKi[(dan-i),(suji+j)]=1;
					}
					else{}
				}
			}
			break;
		case 38:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.EKA]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								EnemyKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								EnemyKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		case 39:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.EHI]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								EnemyKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								EnemyKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		case 40:
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.EFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.ERY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.EOU]==1){
						EnemyKiKi[(dan-i),(suji+j)]=1;
					}
					else{}
				}
			}
			break;
		case 46:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.EFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.ERY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.EUM]==1){
						EnemyKiKi[(dan-i),(suji+j)]=1;
					}
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.EUM]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								SelfKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								EnemyKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		case 47:
			CanJumpFlag= new bool[8]{false,false,false,false,false,false,false,false};
			for(int i=-1;i<=1;i++){
				for(int j=-1;j<=1;j++){
					if((dan-i)<0 || (dan-i)>8 || (suji+j)<0 || (suji+j)>8 || (i==0 && j==0)){
					}
					else if(pieceInit.EFU<=pieceInit.board[dan-i,suji+j] && pieceInit.board[dan-i,suji+j]<=pieceInit.ERY){
					}
					else if(pieceInit.CanMove[pieceInit.Direct[i+1,j+1],pieceInit.ERY]==1){
						EnemyKiKi[(dan-i),(suji+j)]=1;
					}
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.ERY]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								EnemyKiKi[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
								EnemyKiKi[(dan-i*mass),(suji+j*mass)]=1;
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CanJumpFlag[pieceInit.Direct[i+1,j+1]]=true;
							}
							else{}
						}
					}
				}
			}
			break;
		default:
			break;
		}
	}

	public void CheckControl(){
		for(int dan=0;dan<9;dan++){
			for(int suji=0;suji<9;suji++){
				SelfKiKi[dan,suji]=0;
				EnemyKiKi[dan,suji]=0;
			}
		}
		for(int dan=0;dan<9;dan++){
			for(int suji=0;suji<9;suji++){
				CanMove (dan,suji,pieceInit.board[dan,suji]);
			}
		}
	}

	public void AntiCheck(){
		int turn=0;
		if(pieceInit.SorE==pieceInit.SELF){
			turn=pieceInit.ENEMY;
		}
		else{
			turn=pieceInit.SELF;
		}
		CheckControl ();
		for(int dan=0;dan<9;dan++){
			for(int suji=0;suji<9;suji++){
				if(pieceInit.board[dan,suji]==(pieceInit.OU+turn)){
					if(pieceInit.SorE==pieceInit.SELF && SelfKiKi[dan,suji]==1){
						if(hpbercreate.EnemyHP+10>=50){
							hpbercreate.EnemyHP=50;
							pieceInit.EnemySpecialFlag=true;
						}
						else{
							hpbercreate.EnemyHP+=10;
						}
					}
					else if(pieceInit.SorE==pieceInit.ENEMY && EnemyKiKi[dan,suji]==1){
						if(hpbercreate.SelfHP+10>=50){
							hpbercreate.SelfHP=50;
							pieceInit.SelfSpecialFlag=true;
						}
						else{
							hpbercreate.SelfHP+=10;

						}
					}
					else{}
				}
			}
		}
	}
}
