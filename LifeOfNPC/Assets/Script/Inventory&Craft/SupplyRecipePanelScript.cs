using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;

public class SupplyRecipePanelScript : MonoBehaviour {
	public Supply _Supply;
	public Recipe r;
	public List<Text> materialLabels;

	public void materialColorCheck(){
		for(int i = 0; i < r.materials.Count; i++){
			string[] ss = r.materials[i].Split(new string[] {" x "}, StringSplitOptions.None);
			int required = int.Parse(ss[1]);
			int additional = _Supply.getAdditional(ss[0]);
			if(required <= Inventory.getItemAmount(ss[0]) + additional){
				materialLabels[i].color = HexToColor("608247");
			} else if (required / 2 <= Inventory.getItemAmount(ss[0]) + additional) {
				materialLabels[i].color = HexToColor("dcdd6d");
			} else {
				materialLabels[i].color = HexToColor("824747");
			}
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
