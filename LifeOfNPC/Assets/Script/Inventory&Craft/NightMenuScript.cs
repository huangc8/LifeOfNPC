using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NightMenuScript : MonoBehaviour {

	public Inventory _Inventory;
	public Supply _Supply;
	public GameMaster _GameMaster;

	// Potion craft clicked
	public void PotionCraftClicked(){
		_Inventory.OpenInventoryPanel();
		Craft.OpenRecipePanel ();
		_GameMaster.CloseNightMenu ();
	}

	// Supply button clicked
	public void SupplyButtonClicked(){
		_Supply.OpenSupplyPanel ();
		_GameMaster.CloseNightMenu ();
	}

	// Next Day Clicked
	public void NextDayClicked(){
		_GameMaster.newDay ();
		_GameMaster.OpenNightMenu ();
	}	

	public void OpenInventory(){
		_Inventory.OpenInventoryPanel ();
	}

	public void OpenSetPrice(){
		_Inventory.OpenSetPricePanel ();
	}
}
