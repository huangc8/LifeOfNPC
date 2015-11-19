using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SellPanelScript : MonoBehaviour {

	public GameObject contentPanel;
	public GameObject SellListButtonPf;
	public Image icon;
	public Text PriceLabel;
	public Text QuantityLabel;
	public int dealPrice;
	public int dealQuantity;

	void Start(){
		PopulateSellList ();
		dealPrice = 0;
		dealQuantity = 0;
	}

	public void ClosePanel(){
		GameObject.Destroy (gameObject);
	}

	public void PopulateSellList(){
		int index = 0;
		foreach (Item it in Inventory._Items) {
			GameObject newButton = Instantiate(SellListButtonPf) as GameObject;
			SellListButtonScript slbs = newButton.GetComponent<SellListButtonScript>();
			slbs._SPS = this;
			slbs.NameLabel.text = it.name;
			slbs.PriceLabel.text = "$" + it.sellPrice.ToString();
			slbs.QuantityLabel.text = it.amount.ToString();
			slbs.icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
			slbs.index = index;
            newButton.GetComponent<SellToHero>().OnStart();
			newButton.transform.SetParent(contentPanel.transform, false);
			index++;
		}
	}

	public void ItemSelected(int index){
		Item it = Inventory._Items [index];
		icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
		dealPrice = it.sellPrice;
		PriceLabel.text = "$" + dealPrice.ToString();
		dealQuantity = it.amount;
		QuantityLabel.text = dealQuantity.ToString();
	}

	public void IncreasePrice(){
		dealPrice += 10;
		PriceLabel.text = "$" + dealPrice.ToString();
	}

	public void DecreasePrice(){
		if (dealPrice > 0) {
			dealPrice -= 10;
			PriceLabel.text = "$" + dealPrice.ToString ();
		}
	}

	public void IncreaseQuantity(){
		dealQuantity += 1;
		QuantityLabel.text = dealQuantity.ToString();
	}

	public void DecreaseQuantity(){
		if (dealQuantity > 0) {
			dealQuantity -= 1;
			QuantityLabel.text = dealQuantity.ToString ();
		}
	}
    public void confirm()
    {
        this.GetComponent<SellToHero>().SelltoHero();
    }
}
