using UnityEngine;
using System.Collections;

public class CanMoveCursorCreate : MonoBehaviour {
	public int[,] CursorRange;
	PieceInit pieceInit;
	public GameObject obj;

	bool[] CanJumpFlag;

	// Use this for initialization
	void Start () {
		CursorRange = new int[9,9]{
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
		pieceInit = GameObject.Find ("PieceInit").GetComponent<PieceInit> ();
	}

	public void CanMoveCursorDisplay(int dan,int suji){
		CursorDestroy ();
		for(int i=0;i<9;i++){
			for(int j=0;j<9;j++){
				CursorRange[i,j]=0;
			}
		}
		if(pieceInit.handPieceflag==true){
			switch(pieceInit.fromdan){
			case 1:
				for(int canputdan=0;canputdan<9;canputdan++){
					for(int canputsuji=0;canputsuji<9;canputsuji++){
						if(canputdan==0 && pieceInit.SorE==pieceInit.SELF){}
						else if(canputdan==8 && pieceInit.SorE==pieceInit.ENEMY){}
						else if(pieceInit.board[canputdan,canputsuji]==pieceInit.EMP){
							CursorRange[canputdan,canputsuji]=1;
						}
						else{}
					}
				}
				for(int canputsuji=0;canputsuji<9;canputsuji++){
					for(int canputdan=0;canputdan<9;canputdan++){
						if(canputdan==0 && pieceInit.SorE==pieceInit.SELF){}
						else if(canputdan==8 && pieceInit.SorE==pieceInit.ENEMY){}
						else if(pieceInit.board[canputdan,canputsuji]==pieceInit.SFU && pieceInit.SorE==pieceInit.SELF){
							for(int delete=0;delete<9;delete++){
								CursorRange[delete,canputsuji]=0;
							}
						}
						else if(pieceInit.board[canputdan,canputsuji]==pieceInit.EFU && pieceInit.SorE==pieceInit.ENEMY){
							for(int delete=0;delete<9;delete++){
								CursorRange[delete,canputsuji]=0;
							}
						}
						else{}
					}
				}
				break;
			case 2:
				for(int canputdan=0;canputdan<9;canputdan++){
					for(int canputsuji=0;canputsuji<9;canputsuji++){
						if(canputdan==0 && pieceInit.SorE==pieceInit.SELF){}
						else if(canputdan==8 && pieceInit.SorE==pieceInit.ENEMY){}
						else if(pieceInit.board[canputdan,canputsuji]==pieceInit.EMP){
							CursorRange[canputdan,canputsuji]=1;
						}
						else{}
					}
				}
				break;
			case 3:
				for(int canputdan=0;canputdan<9;canputdan++){
					for(int canputsuji=0;canputsuji<9;canputsuji++){
						if((canputdan==0 || canputdan==1) && pieceInit.SorE==pieceInit.SELF){}
						else if((canputdan==7 || canputdan==8) && pieceInit.SorE==pieceInit.ENEMY){}
						else if(pieceInit.board[canputdan,canputsuji]==pieceInit.EMP){
							CursorRange[canputdan,canputsuji]=1;
						}
						else{}
					}
				}
				break;
			case 4:
			case 5:
			case 6:
			case 7:
				for(int canputdan=0;canputdan<9;canputdan++){
					for(int canputsuji=0;canputsuji<9;canputsuji++){
						if(pieceInit.board[canputdan,canputsuji]==pieceInit.EMP){
							CursorRange[canputdan,canputsuji]=1;
						}
					}
				}
				break;
			default:
				break;
			}
		}
		else{
		switch(pieceInit.board[dan,suji]){
		case 17:
			if((dan-1)<0){
				break;
			}
			if(pieceInit.board[dan-1,suji]==pieceInit.EMP || pieceInit.EFU<=pieceInit.board[dan-1,suji] && pieceInit.board[dan-1,suji]<=pieceInit.ERY){
				CursorRange[dan-1,suji]=1;
			}
			break;
		case 18:
			for(int lanceMove=1;lanceMove<=dan;lanceMove++){
				if(pieceInit.board[dan-lanceMove,suji]==pieceInit.EMP){
					CursorRange[dan-lanceMove,suji]=1;
				}
				else if(pieceInit.EFU<=pieceInit.board[dan-lanceMove,suji] && pieceInit.board[dan-lanceMove,suji]<=pieceInit.ERY){
					CursorRange[dan-lanceMove,suji]=1;
					break;
				}
				else{
					break;
				}
			}
			break;
		case 19:
			if((dan-2)<0){
				break;
			}
			if((suji-1)>=0){
				if(pieceInit.board[dan-2,suji-1]<pieceInit.SFU || pieceInit.SRY<pieceInit.board[dan-2,suji-1]){
					CursorRange[dan-2,suji-1]=1;
				}
			}
			if((suji+1)<=8){
				if(pieceInit.board[dan-2,suji+1]<pieceInit.SFU || pieceInit.SRY<pieceInit.board[dan-2,suji+1]){
					CursorRange[dan-2,suji+1]=1;
				}
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
						CursorRange[(dan-i),(suji+j)]=1;
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
						CursorRange[(dan-i),(suji+j)]=1;
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
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
						CursorRange[(dan-i),(suji+j)]=1;
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
						CursorRange[(dan-i),(suji+j)]=1;
					}
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SUM]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
						CursorRange[(dan-i),(suji+j)]=1;
					}
					for(int mass=1;mass<=9;mass++){
						if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
							
						}
						else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.SRY]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
							if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
							}
							else if(pieceInit.EFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.ERY){
								CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
					CursorRange[dan+1,suji]=1;
				}
				break;
			case 34:
				for(int lanceMove=1;lanceMove<=8-dan;lanceMove++){
					if(pieceInit.board[dan+lanceMove,suji]==pieceInit.EMP){
						CursorRange[dan+lanceMove,suji]=1;
					}
					else if(pieceInit.SFU<=pieceInit.board[dan+lanceMove,suji] && pieceInit.board[dan+lanceMove,suji]<=pieceInit.SRY){
						CursorRange[dan+lanceMove,suji]=1;
						break;
					}
					else{
						break;
					}
				}
				break;
			case 35:
				if((dan+2)<0){
					break;
				}
				if((suji-1)>=0){
					if(pieceInit.board[dan+2,suji-1]<pieceInit.EFU || pieceInit.ERY<pieceInit.board[dan+2,suji-1]){
						CursorRange[dan+2,suji-1]=1;
					}
				}
				if((suji+1)<=8){
					if(pieceInit.board[dan+2,suji+1]<pieceInit.EFU || pieceInit.ERY<pieceInit.board[dan+2,suji+1]){
						CursorRange[dan+2,suji+1]=1;
					}
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
							CursorRange[(dan-i),(suji+j)]=1;
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
							CursorRange[(dan-i),(suji+j)]=1;
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
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
								}
								else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
								}
								else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
							CursorRange[(dan-i),(suji+j)]=1;
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
							CursorRange[(dan-i),(suji+j)]=1;
						}
						for(int mass=1;mass<=9;mass++){
							if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
								
							}
							else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.EUM]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
								if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
								}
								else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
							CursorRange[(dan-i),(suji+j)]=1;
						}
						for(int mass=1;mass<=9;mass++){
							if((dan-i*mass)<0 || (dan-i*mass)>8 || (suji+j*mass)<0 || (suji+j*mass)>8){
								
							}
							else if(pieceInit.CanJump[pieceInit.Direct[i+1,j+1],pieceInit.ERY]==1 && CanJumpFlag[pieceInit.Direct[i+1,j+1]]==false){
								if(pieceInit.board[dan-i*mass,suji+j*mass]==pieceInit.EMP){
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
								}
								else if(pieceInit.SFU<=pieceInit.board[dan-i*mass,suji+j*mass] && pieceInit.board[dan-i*mass,suji+j*mass]<=pieceInit.SRY){
									CursorRange[(dan-i*mass),(suji+j*mass)]=1;
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
		for(dan=0;dan<9;dan++){
			for(suji=0;suji<9;suji++){
				if(CursorRange[dan,suji]==1){
					Instantiate(obj,new Vector3(suji-4,4-dan,-1),Quaternion.identity);
				}
			}
		}
	}

	public void CursorDestroy(){
		for(int i=0;i<9;i++){
			for(int j=0;j<9;j++){
				CursorRange[i,j]=0;
			}
		}
		GameObject[] obstacles  = GameObject.FindGameObjectsWithTag("Cursor");
		foreach(GameObject obs in obstacles ){
			Destroy(obs);
		}
	}
}
