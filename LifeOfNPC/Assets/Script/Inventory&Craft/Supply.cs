using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Supply : MonoBehaviour {

	#region Data
	public GameObject canvas;				// the canvas
	public GameObject SupplyPanel;			// the supply panel
	public ResultPanelScript Result;		// the result panel
	public List<Item> supplyList;			// the supply list with all goods that player can buy

	public GameObject SupplyPanelPf;		// supply panel pf
	public GameObject SupplyButtonPf;		// supply button pf

	public int sum = 0;						// the sum of money
	#endregion

	// Use this for initialization
	public void DebugPart () {
		supplyList = new List<Item> ();
		supplyList.Add (new Item ("Apple", 0, "An Apple"));
		supplyList.Add (new Item ("Orange", 0, "A Orange"));
		supplyList.Add (new Item ("Banana", 0, "A Banana"));
		supplyList.Add (new Item ("Watermellon", 0, "A Watermellon"));
	}

	#region Result
	// increase the sum
	public void IncreaseSum(int amount){
		Result.sum += amount;
		Result.UpdatePanel ();
	}

	// decrease the sum
	public void DecreaseSum(int amount){
		Result.sum -= amount;
		Result.UpdatePanel ();
	}
	#endregion

	#region Supply Panel
	// Open Supply Panel
	public void OpenSupplyPanel(){
		if (SupplyPanel == null) {
			SupplyPanel = Instantiate (SupplyPanelPf) as GameObject;
			SupplyPanel.transform.SetParent (canvas.transform, false);
			SupplyPanel.GetComponent<SupplyPanelScript>()._Supply = this;
			Result = SupplyPanel.GetComponent<SupplyPanelScript>().ResultPanel.GetComponent<ResultPanelScript>();
		}
		Result.sum = sum;
		Result.UpdatePanel ();
		PopulateSupplyButton ();
	}

	// populate the buttons
	public void PopulateSupplyButton(){

		GameObject contentPanel = SupplyPanel.GetComponent<SupplyPanelScript> ().ContentPanel;

		for (int i = 0; i < supplyList.Count; i++) {
			GameObject newButton = Instantiate(SupplyButtonPf) as GameObject;
			SupplyButtonScript sbs = newButton.GetComponent<SupplyButtonScript>();
			sbs.nameLabel.text = supplyList[i].name;
			sbs.quantity = supplyList[i].amount;
			sbs.quantityLabel.text = sbs.quantity.ToString();
			sbs.index = i;
			sbs.price = 10;
			sbs._Supply = this;
			newButton.transform.SetParent(contentPanel.transform, false);
		}
	}

	// Close the supply Panel
	public void CloseSupplyPanel(){
		GameObject contents = SupplyPanel.GetComponent<SupplyPanelScript> ().ContentPanel;
		foreach (Transform child in contents.transform) {
			SupplyButtonScript sbs = child.GetComponent<SupplyButtonScript>();
			supplyList[sbs.index].amount = sbs.quantity;
		}
		Destroy (SupplyPanel);
		sum = Result.sum;
		this.GetComponent<GameMaster> ().OpenNightMenu ();
	}
	#endregion
}
