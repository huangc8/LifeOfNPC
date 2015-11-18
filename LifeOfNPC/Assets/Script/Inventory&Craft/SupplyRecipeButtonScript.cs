using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class SupplyRecipeButtonScript : MonoBehaviour {
	public Supply _Supply;
	public Text nameLabel;
	public int index;
	public GameObject SupplyRecipePanel;
	public GameObject SupplyRecipePanelPf;

	public void recipeButtonClick(){
		if (SupplyRecipePanel == null) {
			SupplyRecipePanel = Instantiate(SupplyRecipePanelPf) as GameObject;
			SupplyRecipePanelScript rs = SupplyRecipePanel.GetComponent<SupplyRecipePanelScript> ();
			rs.icon.sprite = Resources.Load<Sprite> ("Sprite/" + nameLabel.text);
			for(int i = 0; i < rs.materialLabels.Count; i++){
				if(i < Craft._Recipes[index].materials.Count){
					rs.materialLabels[i].text = Craft._Recipes[index].materials[i];
				}else{
					rs.materialLabels[i].text = null;
				}
			}
			rs.r = Craft._Recipes[index];
			rs._Supply = _Supply;
			rs.materialColorCheck();
			SupplyRecipePanel.transform.SetParent (this.transform.parent.transform, false);
			SupplyRecipePanel.transform.SetSiblingIndex (this.transform.GetSiblingIndex()+1);
		} else {
			Destroy(SupplyRecipePanel);
		}
	}

	public void UpdateColor(){
		Recipe r = Craft._Recipes [index];
		int fulfill = 0;
		for (int i = 0; i < r.materials.Count; i++) {
			string[] ss = r.materials[i].Split(new string[] {" x "}, StringSplitOptions.None);
			int required = int.Parse(ss[1]);
			if(required <= Inventory.getItemAmount(ss[0]) + _Supply.getAdditional(ss[0])){
				fulfill++;
			}
		}

		if (fulfill == r.materials.Count) {
			nameLabel.color = Color.green;
		} else if (fulfill >= r.materials.Count / 2) {
			nameLabel.color = Color.yellow;
		} else {
			nameLabel.color = Color.red;
		}
	}
}
