using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class RecipeListButtonScript : MonoBehaviour {

	public CraftPanelScript _CraftPanelScript;
	public Text NameLabel;
	public int listIndex;
	public int recipeIndex;
	public GameObject contentPanel;
	public bool open = false;

	public void RecipeButtonClick(){
		if (!open) {
			_CraftPanelScript.CloseAllRecipePanel();
			_CraftPanelScript.SetUpCraftPanel (recipeIndex);
			_CraftPanelScript.SetUpDetailPanel (recipeIndex);
			Color c = this.GetComponent<Image>().color;
			c.a = 0.2f;
			this.GetComponent<Image>().color = c;
			open = true;
		} else {
			ClosePanel();
		}
	}

	public void ClosePanel(){
		_CraftPanelScript.CleanUpCraftPanel ();
		_CraftPanelScript.CloseDetailPanel ();
		Color c = this.GetComponent<Image>().color;
		c.a = 0;
		this.GetComponent<Image>().color = c;
		open = false;
	}

	public void UpdateColor(){
		Recipe r = Craft._Recipes [recipeIndex];
		int fulfill = 0;
		for (int i = 0; i < r.materials.Count; i++) {
			string[] ss = r.materials[i].Split(new string[] {" x "}, StringSplitOptions.None);
			int required = int.Parse(ss[1]);
			if(required <= Inventory.getItemAmount(ss[0])){
				fulfill++;
			}
		}
		
		if (fulfill == r.materials.Count) {
			NameLabel.color = HexToColor("608247");
		} else if (fulfill >= r.materials.Count / 2) {
			NameLabel.color = HexToColor("dcdd6d");
		} else {
			NameLabel.color = HexToColor("824747");
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
