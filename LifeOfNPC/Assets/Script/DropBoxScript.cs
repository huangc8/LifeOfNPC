﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DropBoxScript : MonoBehaviour, IDropHandler {
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
				droppedItem.amount += stackItem.amount;
				droppedItem.UpdateDisplay();
				droppedItem.transform.SetParent (this.transform);
				droppedItem.transform.position = this.transform.position;
			}
		}
	}
}
