using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PriceListButtonScript : MonoBehaviour {
	public SetPricePanelScript _SPPS;
	public int price;
	public Text NameLabel;
	public Text PriceLabel;
	public int index;

	// increase the selling price
	public void IncreasePrice(){
		price += 10;
		PriceLabel.text = price.ToString ();
	}

	// decrease the selling price
	public void DecreasePrice(){
		if (price > 0) {
			price -= 10;
			PriceLabel.text = price.ToString ();
		}
	}

	public void OpenDetail(){
		_SPPS.CleanUpDetailPanel ();
		_SPPS.SetUpDetailPanel(NameLabel.text);
	}

}
