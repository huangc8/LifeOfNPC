using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class Supply : MonoBehaviour {

	#region Data
	public GameObject canvas;				// the canvas
	public GameObject SupplyPanel;			// the supply panel
	public List<Item> supplyList;			// the supply list with all goods that player can buy
	public GameObject SupplyPanelPf;		// supply panel pf
	public GameObject SupplyItemButtonPf;	// supply item button pf
	public GameObject SupplyRecipeButtonPf;	// supply recipe button pf
	public GameObject SupplyRecipeLabelPf;

	public int sum = 0;						// the sum of money
	#endregion

	#region Result
	// increase the sum
	public void IncreaseSum(int cost){
		sum += cost;
		SupplyPanel.GetComponent<SupplyPanelScript> ().UpdateTotal (sum);
	}

	// decrease the sum
	public void DecreaseSum(int cost){
		sum -= cost;
		SupplyPanel.GetComponent<SupplyPanelScript> ().UpdateTotal (sum);
	}

	// confirm order
	public void Confirm(){
		CloseSupplyPanel ();
	}

	// check for additional
	public int getAdditional(string name){
		foreach (Item it in supplyList) {
			if(it.name == name){
				return it.amount;
			}
		}
		return 0;
	}

	public void UpdateRecipeButtons(){
		GameObject contentPanel = SupplyPanel.GetComponent<SupplyPanelScript> ().RecipeContentPanel;
		foreach (Transform gb in contentPanel.transform) {
			if(gb.GetComponent<SupplyRecipeButtonScript>() != null){
				gb.GetComponent<SupplyRecipeButtonScript>().UpdateColor();
			}else if (gb.GetComponent<SupplyRecipePanelScript>() != null){
				gb.GetComponent<SupplyRecipePanelScript>().materialColorCheck();
			}
		}
	}

	public void CloseAllPanel(){
		GameObject contentPanel = SupplyPanel.GetComponent<SupplyPanelScript> ().RecipeContentPanel;
		foreach (Transform gb in contentPanel.transform) {
			if(gb.GetComponent<SupplyRecipeButtonScript>() != null){
				gb.GetComponent<SupplyRecipeButtonScript>().CloseDetailPanel();
			}
		}
	}
	#endregion

	#region Supply Panel
	// Open Supply Panel
	public void OpenSupplyPanel(){
		if (SupplyPanel == null) {
			SupplyPanel = Instantiate (SupplyPanelPf) as GameObject;
			SupplyPanel.transform.SetParent (canvas.transform, false);
			SupplyPanel.GetComponent<SupplyPanelScript>()._Supply = this;
			SupplyPanel.GetComponent<SupplyPanelScript>().TotalLabel.text = "Total Cost: " + sum.ToString();
		}
		PopulateSupplyItemButton ();
		PopulateSupplyRecipeButton ();
	}

	// populate the buttons
	public void PopulateSupplyItemButton(){

		GameObject contentPanel = SupplyPanel.GetComponent<SupplyPanelScript> ().ItemConstentPanel;

		for (int i = 0; i < supplyList.Count; i++) {
			GameObject newButton = Instantiate(SupplyItemButtonPf) as GameObject;
			SupplyButtonScript sbs = newButton.GetComponent<SupplyButtonScript>();
			sbs.nameLabel.text = supplyList[i].name;
			sbs.quantity = supplyList[i].amount;
			sbs.quantityLabel.text = sbs.quantity.ToString();
			sbs.index = i;
			sbs.cost = supplyList[i].supplyPrice;
			sbs.costLabel.text = sbs.cost.ToString();
			sbs._Supply = this;
			newButton.transform.SetParent(contentPanel.transform, false);
		}
	}

	// populate supply recipe buttons
	public void PopulateSupplyRecipeButton(){

		GameObject contentPanel = SupplyPanel.GetComponent<SupplyPanelScript> ().RecipeContentPanel;


		int index = 0;

		GameObject newLabel = Instantiate (SupplyRecipeLabelPf) as GameObject;
		newLabel.GetComponentInChildren<Text> ().text = "Potions";
		newLabel.transform.SetParent (contentPanel.transform, false);
		for (int i = 0; i < Craft._Recipes.Count; i++) {
			if(Craft._Recipes[i].type == 3){
				GameObject newButton = Instantiate(SupplyRecipeButtonPf) as GameObject;
				SupplyRecipeButtonScript srbs = newButton.GetComponent<SupplyRecipeButtonScript>();
				srbs.index = index;
				srbs.nameLabel.text = Craft._Recipes[i].name;
				srbs._Supply = this;
				srbs.UpdateColor();
				newButton.transform.SetParent(contentPanel.transform, false);
			}
			index++;
		}
		index = 0;

		GameObject newLabel2 = Instantiate (SupplyRecipeLabelPf) as GameObject;
		newLabel2.GetComponentInChildren<Text> ().text = "Armor";
		newLabel2.transform.SetParent (contentPanel.transform, false);
		for (int i = 0; i < Craft._Recipes.Count; i++) {
			if(Craft._Recipes[i].type == 1){
				GameObject newButton = Instantiate(SupplyRecipeButtonPf) as GameObject;
				SupplyRecipeButtonScript srbs = newButton.GetComponent<SupplyRecipeButtonScript>();
				srbs.index = index;
				srbs.nameLabel.text = Craft._Recipes[i].name;
				srbs._Supply = this;
				srbs.UpdateColor();
				newButton.transform.SetParent(contentPanel.transform, false);
			}
			index++;
		}
		index = 0;

		GameObject newLabel3 = Instantiate (SupplyRecipeLabelPf) as GameObject;
		newLabel3.GetComponentInChildren<Text> ().text = "Weapon";
		newLabel3.transform.SetParent (contentPanel.transform, false);
		for (int i = 0; i < Craft._Recipes.Count; i++) {
			if(Craft._Recipes[i].type == 2){
				GameObject newButton = Instantiate(SupplyRecipeButtonPf) as GameObject;
				SupplyRecipeButtonScript srbs = newButton.GetComponent<SupplyRecipeButtonScript>();
				srbs.index = index;
				srbs.nameLabel.text = Craft._Recipes[i].name;
				srbs._Supply = this;
				srbs.UpdateColor();
				newButton.transform.SetParent(contentPanel.transform, false);
			}
			index++;
		}
	}

	// Close the supply Panel
	public void CloseSupplyPanel(){
		Destroy (SupplyPanel);
		this.GetComponent<GameMaster> ().OpenNightMenu ();
	}
	#endregion

}
