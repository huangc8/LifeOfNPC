using UnityEngine;
using System.Collections;

public class SetPricePanelScript : MonoBehaviour {

	public Inventory _Inventory;
	public GameObject contentPanel;
	public GameObject SetPriceButtonPf;

	// complete button clicked
	public void CompleteClick(){
		_Inventory.CloseSetPricePanel ();
	}

	// Populate the set price buttons
	public void PopulateSetPriceButton(){
		foreach (Item it in Inventory._Items) {
			GameObject newButton = Instantiate(SetPriceButtonPf) as GameObject;
			PriceListButtonScript slb = newButton.GetComponent<PriceListButtonScript>();
			slb.NameLabel.text = it.name;
			if(it.sellPrice == 0){
				slb.price = it.supplyPrice;
				slb.PriceLabel.text = "$ " + it.supplyPrice.ToString();
			}else{
				slb.price = it.sellPrice;
				slb.PriceLabel.text = "$ " + it.sellPrice.ToString();
			}
			slb.icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
			newButton.transform.SetParent(contentPanel.transform, false);
		}
	}
}
