using UnityEngine;
using UnityEngine.UI;
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
	public GameObject detailPanel;			// the detail panel
	public Text detailName;					// the detail name
	public Text detailDescription;			// the detail description
	public Image detailImage;				// the detail image

	public int currentTab = -2;				// current tab = 0 - material, 1 - armor, 2 - weapon, 3 - potion

	// Prefabs
	public GameObject inventorySlotPf;		// the inventory slot object
	public GameObject inventoryItemPF;		// the inventory item object
	#endregion

	// Use this for initialization
	void Start () {
		currentTab = -2;
		slots = new List<GameObject> ();
		PopulateSlots ();
		PopulateAll ();
	}

	#region function
	// Populate the panels with slots
	public void PopulateSlots(){
		for (int i = 0; i < slotAmount; i++) {
			GameObject newSlot = Instantiate(inventorySlotPf) as GameObject;
			newSlot.GetComponent<DropBoxScript>()._IPS = this;
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
					newItem.GetComponent<ClickandDrag>()._IPS = this;
					newItem.transform.SetParent (slots [i].transform, false);
				}
			}
			currentTab = -1;
		}
	}

	// populate specific item list
	public void PopulateSpecific(int type){
		if (Inventory._Items != null) {
			int slotindex = 0;
			for (int i = 0; i < Inventory._Items.Count; i++) {
				if(Inventory._Items[i].type == type){
					GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
					newItem.GetComponent<Item> ().DisplayItem (Inventory._Items [i]);
					newItem.transform.SetParent (slots [slotindex].transform, false);
					slotindex++;
				}
			}
		}
	}

	// click on specific tab
	public void TabClick(int type){
		ClearSlots ();
		PopulateSpecific (type);
		currentTab = type;
		CloseDetail ();
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

	public void RefreshSlots(){
		ClearSlots ();
		PopulateAll ();
	}

	// Close the panel
	public void ClosePanel(){
		_Inventory.CloseInventoryPanel ();
		Craft.CloseCraftPanel ();
	}

	public void OpenDetail(Item it){
		detailPanel.SetActive (true);
		detailName.text = it.name;
		detailDescription.text = it.description;
		detailImage.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
	}

	public void CloseDetail(){
		detailPanel.SetActive (false);
		detailName.text = null;
		detailDescription.text = null;
		detailImage.sprite = null;
	}
	#endregion
}
