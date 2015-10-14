using UnityEngine;
using System.Collections;

public class NightMenuScript : MonoBehaviour {

	public void PotionCraftClicked(){
		Inventory.OpenInventoryPanel();
		Craft.OpenCraftPanel ();
	}
}
