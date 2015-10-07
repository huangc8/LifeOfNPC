using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class ClickandDrag : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
	public Item it;
	public int slotNum;
	public Transform originalParent;

	// On beginning drag
	public void OnPointerDown(PointerEventData eventData){
		if (it != null) {
			originalParent = this.transform.parent;
			this.transform.SetParent(this.transform.parent.parent);
			this.transform.position = eventData.position;
			GetComponent<CanvasGroup>().blocksRaycasts = false;
		}
	}
		
	// During drag
	public void OnDrag(PointerEventData eventData){
		if (it != null) {
			this.transform.position = eventData.position;
		}
	}
	
	// End of Drag
	public void OnEndDrag(PointerEventData eventData){
		if (it != null) {
			if(this.transform.parent.GetComponent<DropBoxScript>() == null){
				this.transform.SetParent(originalParent);
				this.transform.position = originalParent.transform.position;
			}
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
	}
}