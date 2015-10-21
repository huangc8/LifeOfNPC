using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultPanelScript : MonoBehaviour {

	public int sum = 0;
	public Text sumLabel;
	public Button dealButton;
	public GameMaster _GameMaster;
	
	// default start
	void Start(){
		dealButton.interactable = false;
	}

	// deal button clicked
	public void DealButtonClicked(){
		this.transform.parent.GetComponentInParent<SupplyPanelScript> ()._Supply.CloseSupplyPanel ();
	}

	// update the panel info display
	public void UpdatePanel(){
		sumLabel.text = sum.ToString ();
		if (sum <= GameMaster.gold) {
			dealButton.interactable = true;
		} else {
			dealButton.interactable = false;
		}
	}
}
