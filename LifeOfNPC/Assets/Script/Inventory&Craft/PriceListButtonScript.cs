using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PriceListButtonScript : MonoBehaviour {
	public int price;
	public Text NameLabel;
	public Text PriceLabel;
	public Image icon;

	// increase the selling price
	public void IncreasePrice(){
		price += 10;
		PriceLabel.text = "$ " + price.ToString ();
	}

	// decrease the selling price
	public void DecreasePrice(){
		if (price > 0) {
			price -= 10;
			PriceLabel.text = "$ " + price.ToString ();
		}
	}
}
