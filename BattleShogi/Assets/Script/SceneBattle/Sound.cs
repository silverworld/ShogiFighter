using UnityEngine;
using System.Collections;

public class Sound : MonoBehaviour {
	// BGM
	private AudioSource[] BGMsource = new AudioSource[2];
	// SE
	private AudioSource[] SEsources = new AudioSource[12];

	// BGM
	public AudioClip[] BGM;
	// SE
	public AudioClip[] SE;

	hpBerCreate hp;

	// Use this for initialization
	void Awake () {
		hp=GameObject.Find("hpBerGUI").GetComponent<hpBerCreate>();
		// BGM AudioSource
		for(int i = 0 ; i < BGMsource.Length ; i++ ){
		BGMsource[i] = gameObject.AddComponent<AudioSource>();
		}
		// BGMはループを有効にする
		BGMsource[0].loop = true;
		BGMsource[1].loop = false;

		// SE AudioSource
		for(int i = 0 ; i < SEsources.Length ; i++ ){
			SEsources[i] = gameObject.AddComponent<AudioSource>();
		}
	}
	public void PlayBGM(int Index){
		BGMsource[0].Stop();
		BGMsource[Index].clip = BGM [Index];
		BGMsource[Index].Play ();
	}
	public void PutSound(int Index){
		SEsources[Index].clip = SE [Index];
		SEsources[Index].Play ();	
	}
}
