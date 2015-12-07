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
			_Supply.CloseAllPanel();
			SupplyRecipePanel = Instantiate(SupplyRecipePanelPf) as GameObject;
			SupplyRecipePanelScript rs = SupplyRecipePanel.GetComponent<SupplyRecipePanelScript> ();
			for(int i = 0; i < rs.materialLabels.Count; i++){
				if(i < Craft._Recipes[index].materials.Count){
					rs.materialLabels[i].text = "-" + Craft._Recipes[index].materials[i];
				}else{
					rs.materialLabels[i].text = null;
				}
			}
			rs.r = Craft._Recipes[index];
			rs._Supply = _Supply;
			rs.materialColorCheck();
			SupplyRecipePanel.transform.SetParent (this.transform.parent.transform, false);
			SupplyRecipePanel.transform.SetSiblingIndex (this.transform.GetSiblingIndex()+1);
			Color c = this.GetComponent<Image>().color;
			c.a = 0.2f;
			this.GetComponent<Image>().color = c;
		} else {
			CloseDetailPanel();
		}
	}

	public void CloseDetailPanel(){
		if (SupplyRecipePanel != null) {
			Destroy(SupplyRecipePanel);
			Color c = this.GetComponent<Image>().color;
			c.a = 0;
			this.GetComponent<Image>().color = c;
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
			nameLabel.color = HexToColor("608247");
		} else if (fulfill >= r.materials.Count / 2) {
			nameLabel.color = HexToColor("dcdd6d");
		} else {
			nameLabel.color = HexToColor("824747");
		}
	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}
}
