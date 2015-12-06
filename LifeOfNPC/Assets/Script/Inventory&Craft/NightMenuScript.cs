using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NightMenuScript : MonoBehaviour {

	public Inventory _Inventory;
	public GameMaster _GameMaster;

	// Potion craft clicked
	public void PotionCraftClicked(){
		Craft.OpenCraftPanel ();
		_GameMaster.CloseNightMenu ();
	}

	public void OpenInventory(){
		_Inventory.OpenInventoryPanel ();
	}
}
