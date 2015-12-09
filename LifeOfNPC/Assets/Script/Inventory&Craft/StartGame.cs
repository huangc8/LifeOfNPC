using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	public AudioSource startSound;

	// Use this for initialization
	void Start () {
	
	}
	
	public void startGame(){
		startSound.Play ();
		Application.LoadLevel ("Main");
	}
}
