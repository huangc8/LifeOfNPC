using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;

public class RecipeListPanelScript : MonoBehaviour {

	public List<Text> materialLabels;
	public Recipe r;

	public void materialColorCheck(){
		for(int i = 0; i < r.materials.Count; i++){
			string[] ss = r.materials[i].Split(new string[] {" x "}, StringSplitOptions.None);
			int required = int.Parse(ss[1]);
			if(required <= Inventory.getItemAmount(ss[0])){
				materialLabels[i].color = Color.green;
			} else if (required / 2 <= Inventory.getItemAmount(ss[0])) {
				materialLabels[i].color = Color.yellow;
			} else {
				materialLabels[i].color = Color.red;
			}
		}
	}
}
