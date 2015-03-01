using UnityEngine;
using System.Collections;

public class hpBerCreate : MonoBehaviour {
	private float height;
	private float width;

	public int SelfHP;
	public int EnemyHP;

	public GUIStyle SelfStyle;
	public GUIStyle EnemyStyle;

	public GUIStyle SelfHPBer;
	public GUIStyle EnemyHPBer;

	public GameObject SelfObj;
	public GameObject EnemyObj;

	public Vector3 cameraVec1;
	public Vector3 cameraVec2;
	// Use this for initialization
	void Start () {
		height = Screen.height;
		width = Screen.width;

		SelfHP = 0;
		EnemyHP = 0;
		SelfStyle = new GUIStyle();
		SelfStyle.fontSize = 30;
		EnemyStyle = new GUIStyle();
		EnemyStyle.fontSize = 30;
		SelfHPBer = new GUIStyle ();
		EnemyHPBer = new GUIStyle ();

		cameraVec1 = Camera.main.WorldToScreenPoint(SelfObj.transform.position);
		cameraVec2 = Camera.main.WorldToScreenPoint(EnemyObj.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		SelfObj.transform.localScale = new Vector3 ((float)SelfHP/10,3,0);
		EnemyObj.transform.localScale = new Vector3 ((float)EnemyHP/10,3,0);
	}
	void OnGUI(){
		//GUI.Label(new Rect(width/20+60,height/50,width/10,height/10),"先手   必殺"+SelfHP+"/50",SelfStyle);
		GUI.Label(new Rect(cameraVec1.x,height/50,width/10,height/10),"先手   憤怒ゲージ",SelfStyle);
		GUI.Label(new Rect(cameraVec2.x-width/3,height/50,width/10,height/10),"後手   憤怒ゲージ",EnemyStyle);
	}
}
