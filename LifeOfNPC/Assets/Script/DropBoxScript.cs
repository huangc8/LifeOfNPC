using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System;

public class DropBoxScript : MonoBehaviour, IDropHandler {
	public void OnDrop(PointerEventData eventData){
		Item droppedItem = eventData.pointerDrag.GetComponent<Item> ();
		droppedItem.transform.SetParent (this.transform);
		droppedItem.transform.position = this.transform.position;
	}
}
