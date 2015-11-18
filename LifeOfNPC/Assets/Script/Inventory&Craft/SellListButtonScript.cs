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

	public void ItemSelected(){
		_SPS.ItemSelected (index);
	}
}
