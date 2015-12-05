using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SellListButtonScript : MonoBehaviour {
	public SellPanelScript _SPS;
	public Text NameLabel;
	public Text PriceLabel;
	public Text QuantityLabel;
	public Image icon;
	public int index;
	public bool sell = true;

	public int price;
	public int quantity;

	public void updateInfo(int p, int q){
		price = p;
		quantity = q;
	}

	public void ItemSelected(){
		Button bt = this.GetComponent<Button> ();
		bt.image.sprite = bt.spriteState.highlightedSprite;
		if (sell) {
			_SPS.ItemSelected (index, price, quantity);
		}
	}
}
