using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hero : MonoBehaviour {


    //Hero class

    public string name;
    public int money;
    public float thriftiness;//price range hero expects for the item
    public int qii;//quality of inventory items
    public float willingness;//willingness to sell items to store owner
    public List<Item> H_Inventory;//heros inventory
    public List<DialogTree.DialogTreeNode> lines;
    public DialogTree.DialogTreeNode CurrentNode;
	public int BuyNode;
	public int SellNode;
    public string dialog;
    public int patience;
    public int OfferPrice;
	public int OfferQuantity;
	public int OfferPriceToQty;
	public int sellAttempt;
	public int buyAttempt;
    public Item ItemBeingSold;
    public string RequiredItem;
    public int NumberOfEncounters;
    public int EncounterNumber;
    public bool Encounter1Success;
    public bool Encounter2Success;
    public bool Encounter3Success;
    public DataBase _database;
	public bool buttonInteractable;

    //for determining dialog
    public int HeroClass;//whether hero is a wizard, warrior, or ranger
    public int purpose;

	void Awake(){
		HeroClass = UnityEngine.Random.Range(1, 3);
		buttonInteractable = false;
		sellAttempt = 3;
		buyAttempt = 3;
	}

    //constructor
    public Hero()
    {
        name = null;
        List<string> RequiredItemList = new List<string>();
        EncounterNumber = 0;
    }//ends hero constructor

    public void printInventory()
    {
        foreach(Item it in H_Inventory)
        {
            Debug.Log(it.name);
        }
    }

    public void FillInventory(int qii)
    {
        //fill inventory
        switch (qii)
        {
            case 1:
                int lowItems = UnityEngine.Random.Range(2, 5);
                for (int i = 0; i < lowItems; i++)
                {
                    //add random low quality items to hero inventory
                    H_Inventory.Add(_database.getRandomItem(1));
                }
                break;

            case 2:
                int mediItems = UnityEngine.Random.Range(2, 5);
                for (int i = 0; i < mediItems; i++)
                {
                    //add random medium quality items to hero inventory
                    H_Inventory.Add(_database.getRandomItem(2));
                }
                break;

            case 3:
                int highItems = UnityEngine.Random.Range(2, 5);
                for (int i = 0; i < highItems; i++)
                {
                    //add random high quality items to hero inventory
                    H_Inventory.Add(_database.getRandomItem(3));
                }
                break;

            default:
                Debug.Log("no items in inventory");
                break;
        }//ends switch
    }
		
	// move to the next dialog
	public void NextDialog(){
		CurrentNode = lines [CurrentNode.id + 1];
		updateDialog(CurrentNode.line);
	}

	public void MoveToBuy(){
		if (CurrentNode.dialogType != 1) {
			CurrentNode = lines [BuyNode];
			updateDialog (CurrentNode.line);
		}
	}

	public void MoveToSell(){
		if (CurrentNode.dialogType != 2) {
			CurrentNode = lines [SellNode];
			updateDialog (CurrentNode.line);
		}
	}

	public void BuyDialog(bool success){
		if (success) {
			CurrentNode = lines [CurrentNode.success];
			updateDialog(CurrentNode.line);
		} else {
			CurrentNode = lines [CurrentNode.fail];
			String hline = CurrentNode.line;
			if(hline.Contains("$")){
				hline = hline.Substring(0, hline.IndexOf("$")) + OfferPriceToQty + hline.Substring(hline.IndexOf("$") + 1);
			}
			if (hline.Contains ("#")) {
				hline = hline.Substring(0, hline.IndexOf("#")) + OfferQuantity + hline.Substring(hline.IndexOf("#") + 1);
				CurrentNode.line = hline;
			}
			updateDialog(hline);
		}
	}

	public void SellDialog(bool success){
		if (success) {
			CurrentNode = lines [CurrentNode.success];
			updateDialog(CurrentNode.line);
		} else {
			CurrentNode = lines [CurrentNode.fail];
			String hline = CurrentNode.line;
			if(hline.Contains("$")){
				hline = hline.Substring(0, hline.IndexOf("$")) + OfferPriceToQty + hline.Substring(hline.IndexOf("$") + 1);
			}
			if (hline.Contains ("#")) {
				hline = hline.Substring(0, hline.IndexOf("#")) + OfferQuantity + hline.Substring(hline.IndexOf("#") + 1);
				CurrentNode.line = hline;
			}
			updateDialog(hline);
		}
	}

	public void updateDialog(string line){
		dialog = line;
		CreateHero.HeroDialogBox.text = dialog;
		if (CurrentNode.who == 0) {
			this.GetComponent<HeroComponent> ()._createhero.LoadHeroSprite ("Shopkeeper");
		} else {
			this.GetComponent<HeroComponent> ()._createhero.LoadHeroSprite (name);
		}

	}

	// turn on and off the buttons
	public void ButtonInteraction(bool on){
		foreach (Button button in this.GetComponentsInChildren<Button>())
		{	
			button.interactable = on;
		}
	}
}//ends class
