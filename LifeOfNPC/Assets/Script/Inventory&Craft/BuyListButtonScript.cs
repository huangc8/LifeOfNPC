using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyListButtonScript : MonoBehaviour {
	public BuyPanelScript _BPS;
	public Text NameLabel;
	public Text PriceLabel;
	public Text QuantityLabel;
	public Image icon;
	public int index;
	public bool buy = true;
	
	public int price;
	public int quantity;
	
	public void updateInfo(int p, int q){
		price = p;
		quantity = q;
	}
	
	public void ItemSelected(){
		if (buy) {
			_BPS.ItemSelected (index, price, quantity);
		}
	}
}
