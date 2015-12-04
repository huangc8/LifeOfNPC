using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayPanelScript : MonoBehaviour {

	public GameMaster _GameMaster;
	public Text GoldLabel;
	public Text DayLabel;

	public void ChangePhase(){
		_GameMaster.ChangePhase ();
	}
}
