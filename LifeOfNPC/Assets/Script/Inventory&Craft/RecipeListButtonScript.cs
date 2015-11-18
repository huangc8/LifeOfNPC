using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class RecipeListButtonScript : MonoBehaviour {

	public CraftPanelScript _CraftPanelScript;
	public Text NameLabel;
	public Image icon;
	public int index;
	public GameObject contentPanel;
	public GameObject RecipeListPanel;
	public GameObject RecipeListPanelPf;

	public void RecipeButtonClick(){
		if (RecipeListPanel == null) {
			RecipeListPanel = Instantiate (RecipeListPanelPf) as GameObject;
			RecipeListPanelScript rlps = RecipeListPanel.GetComponent<RecipeListPanelScript> ();
			Recipe re = Craft._Recipes [index];
			for (int i = 0; i < rlps.materialLabels.Count; i++) {
				if (i < re.materials.Count) {
					rlps.materialLabels [i].text = re.materials [i];
				} else {
					rlps.materialLabels [i].text = null;
				}
			}
			rlps.r = re;
			rlps.materialColorCheck ();
			RecipeListPanel.transform.SetParent (contentPanel.transform, false);	
			RecipeListPanel.transform.SetSiblingIndex (this.transform.GetSiblingIndex()+1);
			_CraftPanelScript.SetUpCraftPanel(index);
			_CraftPanelScript.SetUpDetailPanel(index);
		} else {
			Destroy(RecipeListPanel);
			_CraftPanelScript.CleanUpCraftPanel();
			_CraftPanelScript.CloseDetailPanel();
		}
	}

	public void UpdateColor(){
		Recipe r = Craft._Recipes [index];
		int fulfill = 0;
		for (int i = 0; i < r.materials.Count; i++) {
			string[] ss = r.materials[i].Split(new string[] {" x "}, StringSplitOptions.None);
			int required = int.Parse(ss[1]);
			if(required <= Inventory.getItemAmount(ss[0])){
				fulfill++;
			}
		}
		
		if (fulfill == r.materials.Count) {
			NameLabel.color = Color.green;
		} else if (fulfill >= r.materials.Count / 2) {
			NameLabel.color = Color.yellow;
		} else {
			NameLabel.color = Color.red;
		}

		if (RecipeListPanel != null) {
			RecipeListPanel.GetComponent<RecipeListPanelScript>().materialColorCheck();
		}
	}
}
