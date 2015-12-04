using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SellPanelScript : MonoBehaviour {

	public GameObject contentPanel;
	public GameObject SellListButtonPf;
	public Image icon;
	public Text PriceLabel;
	public Text QuantityLabel;
	public int dealPrice;
	public int dealQuantity;
	public List<GameObject> itemList;
	public int currentIndex;

	void Start(){
		itemList = new List<GameObject> ();
		PopulateSellList ();
		currentIndex = 0;
		dealPrice = 0;
		dealQuantity = 1;
	}

	public void ClosePanel(){
		GameObject.Destroy (gameObject);
	}

	public void PopulateSellList(){
		int index = 0;
		foreach (Item it in Inventory._Items) {
			if(it.type != 0){
				GameObject newButton = Instantiate(SellListButtonPf) as GameObject;
				SellListButtonScript slbs = newButton.GetComponent<SellListButtonScript>();
				slbs._SPS = this;
				slbs.NameLabel.text = it.name;
				slbs.PriceLabel.text = "$" + it.sellPrice.ToString();
				slbs.QuantityLabel.text = it.amount.ToString();
				slbs.icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
				slbs.index = index;
				slbs.updateInfo(it.sellPrice, 1);
				newButton.GetComponent<SellToHero>().item = it;
				newButton.GetComponent<SellToHero>().OnStart();
				newButton.transform.SetParent(contentPanel.transform, false);
				itemList.Add(newButton);
				index++;
			}
		}
	}

	public void ItemSelected(int index, int price, int quantity){
		itemList [currentIndex].GetComponent<SellListButtonScript> ().updateInfo (dealPrice, dealQuantity);
		Item it = Inventory._Items [index];
		icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
		dealPrice = price;
		PriceLabel.text = "$" + dealPrice.ToString();
		dealQuantity = quantity;
		QuantityLabel.text = dealQuantity.ToString();
		currentIndex = index;
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
		if (dealQuantity + 1 <= Inventory._Items [currentIndex].amount) {
			dealQuantity += 1;
			QuantityLabel.text = dealQuantity.ToString ();
		}
	}

	public void DecreaseQuantity(){
		if (dealQuantity > 1) {
			dealQuantity -= 1;
			QuantityLabel.text = dealQuantity.ToString ();
		}
	}
    
	public void Confirm()
    {
		DialogTree.DialogTreeNode node = CreateHero.Hero.GetComponent<Hero>().CurrentNode;
		if (node.numbranches > 1) {
            CreateHero.Hero.GetComponent<Hero>().ItemBeingSold = Inventory._Items[currentIndex];
            StartDialogScene.timer = 1;
			itemList [currentIndex].GetComponent<SellToHero> ().SelltoHero (dealPrice, dealQuantity);
		} else {
            StartDialogScene.timer = 1;
            CreateHero.Hero.GetComponent<Hero>().CurrentNode = 
			CreateHero.Hero.GetComponent<Hero>().lines[DialogTree.Traverse(node, false)];
		}
    }
}
