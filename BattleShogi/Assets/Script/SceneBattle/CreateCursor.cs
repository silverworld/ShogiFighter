using UnityEngine;
using System.Collections;

public class CreateCursor : MonoBehaviour {
	public GameObject obj;
	private Vector3 cursorVec;

	void OnMouseEnter(){
		cursorVec = this.transform.position;
		cursorVec.z = -1;
		Instantiate (obj,cursorVec,Quaternion.identity);
	}
	void OnMouseExit() {
		Destroy (GameObject.Find("Cursor(Clone)"));
	}
}
