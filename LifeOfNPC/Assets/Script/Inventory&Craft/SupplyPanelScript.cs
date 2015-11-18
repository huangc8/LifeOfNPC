using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SupplyPanelScript : MonoBehaviour {

	public Supply _Supply;
	public GameObject ItemConstentPanel;
	public GameObject RecipeContentPanel;
	public Text TotalLabel;
	public Button confirmButton;
	
	// confirm clicked
	public void ConfirmClick(){
		_Supply.Confirm ();
	}

	// update total text
	public void UpdateTotal(int newt){
		TotalLabel.text = "Total: " + newt.ToString();
		if (newt > GameMaster.gold) {
			confirmButton.interactable = false;
		} else {
			confirmButton.interactable = true;
		}
	}
}
