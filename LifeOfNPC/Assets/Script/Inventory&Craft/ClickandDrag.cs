using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class ClickandDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public Item it;
	public Transform originalParent;
	public GameObject replacement;
	
	// On beginning drag
	public void OnBeginDrag(PointerEventData eventData){
		if (it != null) {

			// create a replacement placeholder
			if(this.transform.GetComponent<Item>().amount > 1){
				replacement = Instantiate(gameObject);
				Item ri = replacement.GetComponent<Item>();
				ri.amount--;
				ri.UpdateDisplay();
				replacement.transform.SetParent(this.transform.parent, false);
			}

			originalParent = this.transform.parent;
			Item ti = this.GetComponent<Item>();
			ti.amount = 1;
			ti.UpdateDisplay();
			this.transform.SetParent(Inventory.getCanvas().transform, false);
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
				if(this.transform.parent.GetComponent<MaterialBoxScript>() != null){
					replacement = null;
				}else{
					if(replacement != null){
						Item ti = this.GetComponent<Item>();
						ti.amount += replacement.GetComponent<Item>().amount;
						ti.UpdateDisplay();
						Destroy(replacement);
					}
					this.transform.SetParent(originalParent);
					this.transform.position = originalParent.transform.position;
				}
			}else{
				replacement = null;
			}
			GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
	}
}