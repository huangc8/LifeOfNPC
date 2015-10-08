using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class MaterialBoxScript : MonoBehaviour, IDropHandler, IPointerExitHandler {

	// drop the object in box
	public void OnDrop(PointerEventData eventData){
		if (this.GetComponentInChildren<Item> () == null) {
			Item droppedItem = eventData.pointerDrag.GetComponent<Item> ();
			droppedItem.transform.SetParent (this.transform);
			droppedItem.transform.position = this.transform.position;
		} else {
			Item droppedItem = eventData.pointerDrag.GetComponent<Item> ();
			Item stackItem = this.GetComponentInChildren<Item> ();
			
			// stack up item
			if(droppedItem.name == stackItem.name){
				stackItem.amount += droppedItem.amount;
				stackItem.UpdateDisplay();
				Destroy(eventData.pointerDrag);
			}
		}
	}

	// when object leave the box
	public void OnPointerExit (PointerEventData eventData){
		if (this.transform.parent.parent != null && eventData.pointerDrag != null) {
			eventData.pointerDrag.transform.SetParent (this.transform.parent.parent);
		}
	}
}
