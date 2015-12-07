using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {
	
	public AudioSource dayTheme;
	public AudioSource nightTheme;
	public AudioSource metalCraft;
	public AudioSource woodCraft;
	public AudioSource potionCraft;

	public void playDayTheme(){
		if (nightTheme.isPlaying) {
			nightTheme.Stop();
		}
		dayTheme.Play ();
	}

	public void playNightTheme(){
		if (dayTheme.isPlaying) {
			dayTheme.Stop();
		}
		nightTheme.Play ();
	}

	public void playMetalCraft(){
		metalCraft.Play ();
	}

	public void playWoodCraft(){
		woodCraft.Play ();
	}

	public void playPotionCraft(){
		potionCraft.Play ();
	}
}
