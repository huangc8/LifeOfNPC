using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetPricePanelScript : MonoBehaviour {

	public Inventory _Inventory;
	public GameObject contentPanel;
	public GameObject SetPriceButtonPf;
	public Image detailIconImage;
	public Text detailName;
	public Text detailDescription;
	public Text detailRecommandPrice;
	public DataBase _dataBase;

	// complete button clicked
	public void CompleteClick(){
		_Inventory.CloseSetPricePanel ();
	}

	// Populate the set price buttons
	public void PopulateSetPriceButton(){
		int index = 0;
		foreach (Item it in Inventory._Items) {
			if(it.type != 0){
				GameObject newButton = Instantiate(SetPriceButtonPf) as GameObject;
				PriceListButtonScript slb = newButton.GetComponent<PriceListButtonScript>();
				slb.NameLabel.text = it.name;
				if(it.sellPrice == 0){
					slb.price = it.supplyPrice;
					slb.PriceLabel.text = it.supplyPrice.ToString();
				}else{
					slb.price = it.sellPrice;
					slb.PriceLabel.text = it.sellPrice.ToString();
				}
				slb._SPPS = this;
				slb.index = index;
				newButton.transform.SetParent(contentPanel.transform, false);
			}
			index++;
		}
	}

	public void SetUpDetailPanel(string name){
		detailIconImage.sprite = Resources.Load<Sprite>("Sprite/" + name);
		detailName.text = name;
		detailDescription.text = _dataBase.getDescription(name);
		detailRecommandPrice.text = "Recommanded Price: " + _dataBase.getOfficalPrice (name).ToString();
	}

	public void CleanUpDetailPanel(){
		detailIconImage.sprite = null;
		detailName.text = "";
		detailDescription.text = "";
		detailRecommandPrice.text = "";
	}
}
