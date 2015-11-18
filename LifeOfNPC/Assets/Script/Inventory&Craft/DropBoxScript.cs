using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DropBoxScript : MonoBehaviour, IDropHandler, IPointerClickHandler {

	public InventoryPanelScript _IPS;

	// drop the item
	public void OnDrop(PointerEventData eventData){
		if (this.GetComponentInChildren<Item> () == null) {
			Item droppedItem = eventData.pointerDrag.GetComponent<Item> ();
			if(droppedItem != null){
				droppedItem.transform.SetParent (this.transform);
				droppedItem.transform.position = this.transform.position;
			}
		} else {
			Item droppedItem = eventData.pointerDrag.GetComponent<Item> ();
			Item stackItem = this.GetComponentInChildren<Item> ();

			if(droppedItem != null){
				// stack up item
				if(droppedItem.name == stackItem.name){
					stackItem.amount += droppedItem.amount;
					stackItem.UpdateDisplay();
					Destroy(eventData.pointerDrag);
				}
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData){
		if (transform.childCount <= 0) {
			_IPS.CloseDetail();
		}
	}
}
