using UnityEngine;
using System.Collections;

public class PieceInit : MonoBehaviour {
	public GameObject SPawn;
	public GameObject SLance;
	public GameObject SKnight;
	public GameObject SSilver;
	public GameObject SGold;
	public GameObject SKing;
	public GameObject SBishop;
	public GameObject SRook;
	public GameObject SPawn_Promoted;
	public GameObject SLance_Promoted;
	public GameObject SKnight_Promoted;
	public GameObject SSilver_Promoted;
	public GameObject SBishop_Promoted;
	public GameObject SRook_Promoted;

	public GameObject EPawn;
	public GameObject ELance;
	public GameObject EKnight;
	public GameObject ESilver;
	public GameObject EGold;
	public GameObject EKing;
	public GameObject EBishop;
	public GameObject ERook;
	public GameObject EPawn_Promoted;
	public GameObject ELance_Promoted;
	public GameObject EKnight_Promoted;
	public GameObject ESilver_Promoted;
	public GameObject EBishop_Promoted;
	public GameObject ERook_Promoted;

	public GameObject[] PieceObject;

	public GameObject Aura;

	public int PROMOTED = 8;
	public int SELF = 16;
	public int ENEMY = 32;

	public int EMP = 0;
	public int FU = 1;
	public int KY = 2;
	public int KE = 3;
	public int GI = 4;
	public int KI = 5;
	public int KA = 6;
	public int HI = 7;
	public int OU = 8;

	public int TO;
	public int NY;
	public int NK;
	public int NG;
	public int UM;
	public int RY;

	public int SFU;
	public int SKY;
	public int SKE;
	public int SGI;
	public int SKI;
	public int SKA;
	public int SHI;
	public int SOU;
	public int STO;
	public int SNY;
	public int SNK;
	public int SNG;
	public int SUM;
	public int SRY;

	public int EFU;
	public int EKY;
	public int EKE;
	public int EGI;
	public int EKI;
	public int EKA;
	public int EHI;
	public int EOU;
	public int ETO;
	public int ENY;
	public int ENK;
	public int ENG;
	public int EUM;
	public int ERY;
	//初期盤面
	public int[,] board;
	public int[] hand;

	//方向番号
	public int[,] Direct;
	//成ることができる駒か
	public int[] CanPromote;
	//移動できるか
	public int[,] CanMove;
	//飛べるか
	public int[,] CanJump;

	public int SorE;

	//fromを受け取ったか
	public bool fromFlag;
	//toを受け取ったか
	public bool toFlag;
	//成ることができるか
	public bool promoteflag;
	public bool promoteGUIflag;

	//持ち駒を使うか
	public bool handPieceflag;

	//手数カウント
	public int Tesu;

	//指し手情報
	public int fromdan;
	public int fromsuji;
	public int todan;
	public int tosuji;
	public bool promoted;
	public int Koma;
	public int takeKoma;

	//必殺フラグ
	public bool SelfSpecialFlag;
	public bool EnemySpecialFlag;

	public int Jadgement;

	CanMoveCursorCreate cursorcreate;
	hpBerCreate hpbercreate;
	KiKiCheck kiki;
	Sound sound;
	
	// Use this for initialization
	void Start () {
		PieceObject = new GameObject[]{
			null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,null,
			SPawn,
			SLance,
			SKnight,
			SSilver,
			SGold,
			SBishop,
			SRook,
			SKing,
			SPawn_Promoted,
			SLance_Promoted,
			SKnight_Promoted,
			SSilver_Promoted,
			null,
			SBishop_Promoted,
			SRook_Promoted,
			null,
			EPawn,
			ELance,
			EKnight,
			ESilver,
			EGold,
			EBishop,
			ERook,
			EKing,
			EPawn_Promoted,
			ELance_Promoted,
			EKnight_Promoted,
			ESilver_Promoted,
			null,
			EBishop_Promoted,
			ERook_Promoted
		};

		TO = FU + PROMOTED;
		NY = KY + PROMOTED;
		NK = KE + PROMOTED;
		NG = GI + PROMOTED;
		UM = KA + PROMOTED;
		RY = HI + PROMOTED;

		SFU = FU + SELF;
		SKY = KY + SELF;
		SKE = KE + SELF;
		SGI = GI + SELF;
		SKI = KI + SELF;
		SOU = OU + SELF;
		SKA = KA + SELF;
		SHI = HI + SELF;
		STO = TO + SELF;
		SNY = NY + SELF;
		SNK = NK + SELF;
		SNG = NG + SELF;
		SUM = UM + SELF;
		SRY = RY + SELF;

		EFU = FU + ENEMY;
		EKY = KY + ENEMY;
		EKE = KE + ENEMY;
		EGI = GI + ENEMY;
		EKI = KI + ENEMY;
		EOU = OU + ENEMY;
		EKA = KA + ENEMY;
		EHI = HI + ENEMY;
		ETO = TO + ENEMY;
		ENY = NY + ENEMY;
		ENK = NK + ENEMY;
		ENG = NG + ENEMY;
		EUM = UM + ENEMY;
		ERY = RY + ENEMY;

		board = new int[9,9]{
			{EKY,EKE,EGI,EKI,EOU,EKI,EGI,EKE,EKY},
			{EMP,EHI,EMP,EMP,EMP,EMP,EMP,EKA,EMP},
			{EFU,EFU,EFU,EFU,EFU,EFU,EFU,EFU,EFU},
			{EMP,EMP,EMP,EMP,EMP,EMP,EMP,EMP,EMP},
			{EMP,EMP,EMP,EMP,EMP,EMP,EMP,EMP,EMP},
			{EMP,EMP,EMP,EMP,EMP,EMP,EMP,EMP,EMP},
			{SFU,SFU,SFU,SFU,SFU,SFU,SFU,SFU,SFU},
			{EMP,SKA,EMP,EMP,EMP,EMP,EMP,SHI,EMP},
			{SKY,SKE,SGI,SKI,SOU,SKI,SGI,SKE,SKY}
		};
		hand = new int[41]{
			//0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		};
		Direct = new int[,]{
			{0,1,2},
			{3,0,4},
			{5,6,7}
		};
		CanPromote = new int[]{
			//空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,1,1,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		};
		CanMove = new int[,]{{
			// |／
			//  ￣
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,1,1,0,0,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ↓
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,1,0,0,1,1,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ＼|
			// ￣
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,1,1,0,0,1,1,1,1,1,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ←
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// →
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			//  __
			// |＼
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,1,1,1,1,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ↑
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,1,1,0,0,1,1,1,1,1,1,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,1,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// __
			// ／|
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1,1,1,1,1,1,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 先手の桂馬
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 先手の桂馬
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 後手の桂馬
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 後手の桂馬
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		}
		};
		CanJump = new int[,]{
		{
			// |／
			//  ￣
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ↓
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ＼|
			// ￣
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ←
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// →
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			//  __
			// |＼
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// ↑
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,0,1,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// __
			// ／|
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 先手の桂馬飛び
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 先手の桂馬飛び
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 後手の桂馬飛び
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		},{
			// 後手の桂馬飛び
			//  空空空空空空空空空空空空空空空空空歩香桂銀金角飛王と杏圭全金馬龍
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
			//	空歩香桂銀金角飛王と杏圭全金馬龍壁空空空空空空空空空空空空空空空
			0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0
		}
		};
		SorE = ENEMY;
		fromFlag = false;
		toFlag = false;

		promoteflag = false;
		promoteGUIflag = false;

		handPieceflag = false;

		SelfSpecialFlag = false;
		EnemySpecialFlag = false;

		Jadgement = 0;

		Tesu = 0;

		BoardDisplay ();

		cursorcreate = GameObject.Find ("CanMoveCreateCursor").GetComponent<CanMoveCursorCreate> ();
		hpbercreate=GameObject.Find("hpBerGUI").GetComponent<hpBerCreate>();
		kiki=GameObject.Find("KiKiCheck").GetComponent<KiKiCheck>();
		sound=GameObject.Find("SoundControl").GetComponent<Sound>();

		sound.PlayBGM (0);
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void RecieveFromMessage(int dan,int suji){
		fromdan = dan;
		fromsuji = suji;

		if(handPieceflag==true){
			fromFlag=true;
			cursorcreate.CanMoveCursorDisplay(fromdan,fromsuji);
		}
		else if (FU+SorE <= board [dan,suji] && board [dan,suji] <= RY+SorE) {
			Koma=board[dan,suji];
			fromFlag=true;
			cursorcreate.CanMoveCursorDisplay(fromdan,fromsuji);
		}
		else{}
		}

	public void RecieveToMessage(int dan,int suji){
		todan = dan;
		tosuji = suji;
		toFlag=true;
	}

	public void PromoteCheck(){
		if((todan<3 || fromdan<3) && SorE==SELF && handPieceflag==false){
		switch(board[fromdan,fromsuji]){
		case 17:
			if(todan==0){
				promoteflag=true;
			}
			else{
				promoteGUIflag=true;
			}
			break;
		case 18:
			if(todan==0){
				promoteflag=true;
			}
			else{
				promoteGUIflag=true;
			}
			break;
		case 19:
			if(todan==0 || todan==1){
				promoteflag=true;
			}
			else{
				promoteGUIflag=true;
			}
			break;
		case 20:
		case 22:
		case 23:
			promoteGUIflag=true;
			break;
		default:
			break;
		}
		}
		if((todan>5 || fromdan>5) && SorE==ENEMY && handPieceflag==false){
			switch(board[fromdan,fromsuji]){
			case 33:
				if(todan==8){
					promoteflag=true;
				}
				else{
					promoteGUIflag=true;
				}
				break;
			case 34:
				if(todan==8){
					promoteflag=true;
				}
				else{
					promoteGUIflag=true;
				}
				break;
			case 35:
				if(todan==8 || todan==7){
					promoteflag=true;
				}
				else{
					promoteGUIflag=true;
				}
				break;
			case 36:
			case 38:
			case 39:
				promoteGUIflag=true;
				break;
			default:
				break;
			}
			
		}
	}

	public void TakePiece(){
		if (handPieceflag==true) {
			hand [fromdan+SorE]--;
			board[todan,tosuji]=fromdan+SorE;
			handPieceflag=false;
			sound.PutSound (0);
		} 
		else {
			if (SorE==SELF) {
				if(EFU <= board [todan, tosuji] && board [todan, tosuji] <= EOU){
					takeKoma=board[todan,tosuji];
					hand [board [todan, tosuji] - SELF]++;
					if(hpbercreate.EnemyHP+5>=50){
						hpbercreate.EnemyHP=50;
						EnemySpecialFlag=true;
					}
					else{
						hpbercreate.EnemyHP+=5;
					}
				}
				else if(ETO <= board [todan, tosuji] && board [todan, tosuji] <= ERY){
					takeKoma=board[todan,tosuji];
					hand [board [todan, tosuji] - SELF-PROMOTED]++;
					if(hpbercreate.EnemyHP+5>=50){
						hpbercreate.EnemyHP=50;
						EnemySpecialFlag=true;
					}
					else{
						hpbercreate.EnemyHP+=5;
					}
				}

			}
			else if(SorE==ENEMY){
				if(SFU <= board [todan, tosuji] && board [todan, tosuji] <= SOU){
					takeKoma=board[todan,tosuji];
					hand [board [todan, tosuji] + SELF]++;
					if(hpbercreate.SelfHP+5>=50){
						hpbercreate.SelfHP=50;
						SelfSpecialFlag=true;
					}
					else{
						hpbercreate.SelfHP+=5;
					}
				}
				else if(STO <= board [todan, tosuji] && board [todan, tosuji] <= SRY){
					takeKoma=board[todan,tosuji];
					hand [board [todan, tosuji] + SELF-PROMOTED]++;
					if(hpbercreate.SelfHP+5>=50){
						hpbercreate.SelfHP=50;
						SelfSpecialFlag=true;
					}
					else{
						hpbercreate.SelfHP+=5;
					}
				}

			}
			if (promoteflag == true) {
					board [fromdan, fromsuji] += PROMOTED;
				sound.PutSound (1);
			}
			else{
				sound.PutSound (0);
			}
			board [todan, tosuji] = board [fromdan, fromsuji];
			board [fromdan, fromsuji] = EMP;
		}
		kiki.AntiCheck ();
		cursorcreate.CursorDestroy ();

		fromFlag = false;
		toFlag = false;
		promoteflag = false;
		promoteGUIflag = false;
		BoardDisplay();
	}

	public void MoveCheck(){
		if (handPieceflag==true) {
				} else {
						if (FU+SorE <= board [todan, tosuji] && board [todan, tosuji] <= RY+SorE) {
								fromFlag = true;
								toFlag = false;
								cursorcreate.CursorDestroy ();
								RecieveFromMessage (todan, tosuji);
								return;
						}
		}
		if(cursorcreate.CursorRange[todan,tosuji]==1){
			PromoteCheck ();
		}
		if (promoteGUIflag == false && cursorcreate.CursorRange[todan,tosuji]==1) {
			TakePiece ();
			}
	}

	public void BoardDisplay(){
		GameObject[] obstacles  = GameObject.FindGameObjectsWithTag("Piece");
		foreach(GameObject obs in obstacles ){
			Destroy(obs);
		}
		obstacles  = GameObject.FindGameObjectsWithTag("Aura");
		foreach(GameObject obs in obstacles ){
			Destroy(obs);
		}
		for(int dan=0;dan<9;dan++){
			for(int suji=0;suji<9;suji++){
				if(SFU <= board[dan,suji] && board[dan,suji] <= SRY){
					Instantiate(PieceObject[board[dan,suji]],new Vector3(suji-4,4-dan,-5),Quaternion.Euler(0,0,0));
					if(SelfSpecialFlag == true){
					Instantiate(Aura,new Vector3(suji-4,4-dan,-5),Quaternion.Euler(0,0,0));
					}
				}
				else if(EFU <= board[dan,suji] && board[dan,suji] <= ERY){
					Instantiate(PieceObject[board[dan,suji]],new Vector3(suji-4,4-dan,-5),Quaternion.Euler(0,0,180));
					if(EnemySpecialFlag == true){
					Instantiate(Aura,new Vector3(suji-4,4-dan,-5),Quaternion.Euler(0,0,0));
					}
				}
				else{}
			}
		}
		int x=0;
		int y=0;
		for(int i=SFU;i<=SHI;i++){
			if(hand[i]>=1){
				Instantiate(PieceObject[i],new Vector3(6.3f+x*1.5f,-1.5f-y*1.2f,-5),Quaternion.Euler(0,0,0));
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
		x = 0;
		y = 0;
		for(int i=EFU;i<=EHI;i++){
			if(hand[i]>=1){
				Instantiate(PieceObject[i],new Vector3(-6.3f-x*1.5f,1.5f+y*1.2f,-5),Quaternion.Euler(0,0,180));
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
		if (SorE == SELF) {
			SorE = ENEMY;
			} 
		else {
			SorE=SELF;		
		}
		JadgeCheck ();
		Tesu++;
	}

	public void JadgeCheck(){
		int SKingCount = 0;
		int EKingCount = 0;
		for(int dan=0;dan<9;dan++){
			for(int suji=0;suji<9;suji++){
				if(board[dan,suji]==EOU){
					EKingCount++;
				}
				if(board[dan,suji]==SOU){
					SKingCount++;
				}
			}
		}
		if(SKingCount==0 && EKingCount==0){
			Jadgement=3;
			sound.PlayBGM(1);
		}
		else if(EKingCount==0){
			//sente win
			Jadgement=1;
			sound.PlayBGM(1);
		}
		else if(SKingCount==0){
			//sente win
			Jadgement=2;
			sound.PlayBGM(1);
		}
		else{}
	}
}
