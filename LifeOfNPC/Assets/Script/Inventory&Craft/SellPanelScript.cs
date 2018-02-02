using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SellPanelScript : MonoBehaviour {

	public GameObject contentPanel;
	public GameObject SellListButtonPf;
	public GameObject SellListLabelPf;
	public Image icon;
	public Text PriceLabel;
	public Text QuantityLabel;
	public int dealPrice;
	public int dealQuantity;
	public List<GameObject> itemList;
	public int currentIndex;
	public int currentItemIndex;

	void Start(){
		itemList = new List<GameObject> ();
		PopulateSellList ();
		currentIndex = 0;
		currentItemIndex = 0;
		dealPrice = 0;
		dealQuantity = 1;
	}

	public void ClosePanel(){
		StartDialogScene.inMenu = false;
		GameObject.Destroy (gameObject);
	}

	public void PopulateSellList(){
		int listIndex = 0;
		int itemIndex = 0;

		// potions
		GameObject newLabel = Instantiate (SellListLabelPf) as GameObject;
		newLabel.GetComponentInChildren<Text> ().text = "Potions";
		newLabel.transform.SetParent (contentPanel.transform, false);
		foreach (Item it in Inventory._Items) {
			if(it.type == 3){
				GameObject newButton = Instantiate(SellListButtonPf) as GameObject;
				SellListButtonScript slbs = newButton.GetComponent<SellListButtonScript>();
				slbs._SPS = this;
				slbs.NameLabel.text = it.name;
				slbs.PriceLabel.text = it.sellPrice.ToString();
				slbs.QuantityLabel.text = it.amount.ToString();
				slbs.icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
				slbs.listIndex = listIndex;
				slbs.itemIndex = itemIndex;
				slbs.updateInfo(it.sellPrice, 1);
				newButton.GetComponent<SellToHero>().item = it;
				newButton.GetComponent<SellToHero>().OnStart();
				newButton.transform.SetParent(contentPanel.transform, false);

				itemList.Add(newButton);
				listIndex++;
			}
			itemIndex++;
		}

		itemIndex = 0;

		// armor
		GameObject newLabel2 = Instantiate (SellListLabelPf) as GameObject;
		newLabel2.GetComponentInChildren<Text> ().text = "Armor";
		newLabel2.transform.SetParent (contentPanel.transform, false);
		foreach (Item it in Inventory._Items) {
			if(it.type == 1){
				GameObject newButton = Instantiate(SellListButtonPf) as GameObject;
				SellListButtonScript slbs = newButton.GetComponent<SellListButtonScript>();
				slbs._SPS = this;
				slbs.NameLabel.text = it.name;
				slbs.PriceLabel.text = it.sellPrice.ToString();
				slbs.QuantityLabel.text = it.amount.ToString();
				slbs.icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
				slbs.listIndex = listIndex;
				slbs.itemIndex = itemIndex;
				slbs.updateInfo(it.sellPrice, 1);
				newButton.GetComponent<SellToHero>().item = it;
				newButton.GetComponent<SellToHero>().OnStart();
				newButton.transform.SetParent(contentPanel.transform, false);
				
				itemList.Add(newButton);
				listIndex++;
			}
			itemIndex++;
		}

		itemIndex = 0;

		// weapon
		GameObject newLabel3 = Instantiate (SellListLabelPf) as GameObject;
		newLabel3.GetComponentInChildren<Text> ().text = "Weapon";
		newLabel3.transform.SetParent (contentPanel.transform, false);
		foreach (Item it in Inventory._Items) {
			if(it.type == 2){
				GameObject newButton = Instantiate(SellListButtonPf) as GameObject;
				SellListButtonScript slbs = newButton.GetComponent<SellListButtonScript>();
				slbs._SPS = this;
				slbs.NameLabel.text = it.name;
				slbs.PriceLabel.text = it.sellPrice.ToString();
				slbs.QuantityLabel.text = it.amount.ToString();
				slbs.icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
				slbs.listIndex = listIndex;
				slbs.itemIndex = itemIndex;
				slbs.updateInfo(it.sellPrice, 1);
				newButton.GetComponent<SellToHero>().item = it;
				newButton.GetComponent<SellToHero>().OnStart();
				newButton.transform.SetParent(contentPanel.transform, false);
				
				itemList.Add(newButton);
				listIndex++;
			}
			itemIndex++;
		}
	}

	public void ItemSelected(int itemIndex, int listIndex, int price, int quantity){
		itemList [currentIndex].GetComponent<SellListButtonScript> ().updateInfo (dealPrice, dealQuantity);
		Item it = Inventory._Items [itemIndex];
		icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
		dealPrice = price;
		PriceLabel.text = dealPrice.ToString();
		dealQuantity = quantity;
		QuantityLabel.text = dealQuantity.ToString();
		currentIndex = listIndex;
		currentItemIndex = itemIndex;
	}

	public void IncreasePrice(){
		dealPrice += 10;
		PriceLabel.text = dealPrice.ToString();
	}

	public void DecreasePrice(){
		if (dealPrice > 0) {
			dealPrice -= 10;
			PriceLabel.text = dealPrice.ToString ();
		}
	}

	public void IncreaseQuantity(){
		if (dealQuantity + 1 <= Inventory._Items [currentItemIndex].amount) {
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
		if (node.stop == 0) {
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
