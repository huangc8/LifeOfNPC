using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BuyPanelScript : MonoBehaviour {
	
	public GameObject contentPanel;
	public GameObject BuyListButtonPf;
	public Image icon;
	public Text PriceLabel;
	public Text QuantityLabel;
	public int dealPrice;
	public int dealQuantity;
	public List<GameObject> itemList;
	public int currentIndex;
	
	void Start(){
		itemList = new List<GameObject> ();
		PopulateBuyList ();
		currentIndex = 0;
		dealPrice = 0;
		dealQuantity = 1;
	}
	
	public void ClosePanel(){
		GameObject.Destroy (gameObject);
	}
	
	public void PopulateBuyList(){
		int index = 0;

		foreach (Item it in CreateHero.Hero.GetComponent<Hero>().H_Inventory) {
			GameObject newButton = Instantiate(BuyListButtonPf) as GameObject;
			BuyListButtonScript slbs = newButton.GetComponent<BuyListButtonScript>();
			slbs._BPS = this;
			slbs.NameLabel.text = it.name;
			slbs.PriceLabel.text = "$" + it.supplyPrice.ToString();
			slbs.QuantityLabel.text = it.amount.ToString();
			slbs.icon.sprite = Resources.Load<Sprite>("Sprite/" + it.name);
			slbs.index = index;
			slbs.updateInfo(it.supplyPrice, 1);
			newButton.transform.SetParent(contentPanel.transform, false);
			newButton.GetComponent<BuyFromHero>().Itemindex = index;
			newButton.GetComponent<BuyFromHero>().item = it;
			itemList.Add(newButton);
			index++;
		}
	}
	
	public void ItemSelected(int index, int price, int quantity){
		itemList [currentIndex].GetComponent<BuyListButtonScript> ().updateInfo (dealPrice, dealQuantity);
		Item it = CreateHero.Hero.GetComponent<Hero>().H_Inventory [index];
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
			itemList [currentIndex].GetComponent<BuyFromHero> ().BuyfromHero (dealPrice, dealQuantity);
		} else {
			CreateHero.Hero.GetComponent<Hero>().CurrentNode = 
				CreateHero.Hero.GetComponent<Hero>().lines[DialogTree.Traverse(node, false)];
		}
	}
}
