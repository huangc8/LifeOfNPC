using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryPanelScript : MonoBehaviour {

	#region Data
	// Inventory Panel
	public List<GameObject> slots;			// the slots of inventory
	GameObject inventoryPanel; 				// the inventory panel
	GameObject slotPanel;					// the slot panel
	int slotAmount = 32;					// the amount of slots *32
	public GameObject backButton;			// the close inventory button

	// Prefabs
	public GameObject inventorySlotPf;		// the inventory slot object
	public GameObject inventoryItemPF;		// the inventory item object
	#endregion

	// Use this for initialization
	void Start () {
		slots = new List<GameObject> ();
		CreatePanels ();
		PopulateSlots ();
		PopulateItems ();
	}

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
	public void PopulateItems(){
		if (Inventory._Items != null) {
			for (int i = 0; i < Inventory._Items.Count; i++) {
				GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
				newItem.GetComponent<Item> ().DisplayItem (Inventory._Items [i]);
				newItem.transform.SetParent (slots [i].transform, false);
			}
		}
	}

	// Close the panel
	public void ClosePanel(){
		Inventory.CloseInventoryPanel ();
		Craft.CloseCraftPanel ();
	}
}
