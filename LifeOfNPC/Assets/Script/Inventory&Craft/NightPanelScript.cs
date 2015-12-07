using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NightPanelScript : MonoBehaviour {
	public GameMaster _GameMaster;
	public Inventory _Inventory;
	public Supply _Supply;
	public Text GoldLabel;
	public Text DayLabel;
	
	public void ChangePhase(){
		_GameMaster.ChangePhase ();
	}

	// Supply button clicked
	public void SupplyButtonClicked(){
		if (Inventory.InventoryPanel == null && Inventory.SetPricePanel == null 
		    && Craft.CraftPanel == null) {
			_Supply.OpenSupplyPanel ();
			_GameMaster.CloseNightMenu ();
		}
	}

	public void OpenSetPrice(){
		if (_Supply.SupplyPanel == null && Inventory.InventoryPanel == null
		    && Craft.CraftPanel == null) {
			_Inventory.OpenSetPricePanel ();
		}
	}
}
