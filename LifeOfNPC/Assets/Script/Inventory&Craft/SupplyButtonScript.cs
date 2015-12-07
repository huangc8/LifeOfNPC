using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SupplyButtonScript : MonoBehaviour {

	#region Data
	public Supply _Supply;

	public int quantity;
	public int index;
	public int cost;

	public Text nameLabel;
	public Text quantityLabel;
	public Text costLabel;
	
	public Button upButton;
	public Button downButton;
	#endregion

	#region function
	// increase the buying quantity
	public void IncreaseQuantity(){
		quantity++;
		quantityLabel.text = quantity.ToString ();
		_Supply.IncreaseSum (cost);
		_Supply.supplyList [index].amount++;
		_Supply.UpdateRecipeButtons ();
	}

	// decrease the buying quantity
	public void DecreaseQuantity(){
		if (quantity > 0) {
			quantity--;
			quantityLabel.text = quantity.ToString ();
			_Supply.DecreaseSum(cost);
			_Supply.supplyList [index].amount--;
			_Supply.UpdateRecipeButtons ();
		}
	}
	#endregion
}
