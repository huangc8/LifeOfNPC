using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryPanelScript : MonoBehaviour {

	#region Data
	// Inventory Panel
	public Inventory _Inventory;			// the inventory reference
	public List<GameObject> slots;			// the slots of inventory
	public GameObject inventoryPanel; 		// the inventory panel
	public GameObject slotPanel;			// the slot panel
	public int slotAmount = 32;				// the amount of slots *32
	public GameObject backButton;			// the close inventory button

	public int currentTab = -2;				// current tab = -1 - all, 0 - item, 1 - armor, 2 - weapon

	// Prefabs
	public GameObject inventorySlotPf;		// the inventory slot object
	public GameObject inventoryItemPF;		// the inventory item object
	#endregion

	// Use this for initialization
	void Start () {
		currentTab = -2;
		slots = new List<GameObject> ();
		CreatePanels ();
		PopulateSlots ();
		PopulateAll ();
	}

	#region function
	// Create the UI Panels
	public void CreatePanels(){
		inventoryPanel = this.gameObject;
		slotPanel = inventoryPanel.transform.FindChild ("SlotPanel").gameObject;
		slotPanel.transform.SetParent (inventoryPanel.transform);
	}

	// Populate the panels with slots
	public void PopulateSlots(){
		for (int i = 0; i < slotAmount; i++) {
			GameObject newSlot = Instantiate(inventorySlotPf) as GameObject;
			newSlot.transform.SetParent(slotPanel.transform, false);
			slots.Add(newSlot);
		}
	}

	// Populate the slots with item
	public void PopulateAll(){
		if (currentTab != -1) {
			if (Inventory._Items != null) {
				for (int i = 0; i < Inventory._Items.Count; i++) {
					GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
					newItem.GetComponent<Item> ().DisplayItem (Inventory._Items [i]);
					newItem.transform.SetParent (slots [i].transform, false);
				}
			}
			currentTab = -1;
		}
	}

	// populate specific item list
	public void PopulateSpecific(int type){
		if (Inventory._Items != null) {
			for (int i = 0; i < Inventory._Items.Count; i++) {
				if(Inventory._Items[i].type == type){
				GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
				newItem.GetComponent<Item> ().DisplayItem (Inventory._Items [i]);
					newItem.transform.SetParent (slots [i].transform, false);
				}
			}
		}
	}

	// click on specific tab
	public void TabClick(int type){
		ClearSlots ();
		PopulateSpecific (type);
		currentTab = type;
	}

	// clear the items in slots
	public void ClearSlots(){
		foreach (GameObject gb in slots) {
			Transform tf = gb.transform;
			foreach(Transform child in tf){
				GameObject.Destroy(child.gameObject);
			}
		}
	}
	
	// Close the panel
	public void ClosePanel(){
		_Inventory.CloseInventoryPanel ();
		Craft.CloseCraftPanel ();
	}
	#endregion
}
