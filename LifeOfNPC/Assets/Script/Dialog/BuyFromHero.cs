using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class BuyFromHero : MonoBehaviour {

    public float InitialThresholdPrice;
    public float NewThresholdPrice;
    public int attempt;
    public int Itemindex;
    public Item item;

    public void OnStart()
    {
        item = CreateHero.Hero.GetComponent<Hero>().H_Inventory[Itemindex];
        Debug.Log(item.supplyPrice);
        float itemprice = item.supplyPrice;//will be the price of the item
        InitialThresholdPrice = ((100 + CreateHero.Hero.GetComponent<Hero>().thriftiness) / 100) * itemprice;//sets the initial price hero will buy at
        Debug.Log("Current Threshold Price:" + InitialThresholdPrice);
        CreateHero.Hero.GetComponent<Hero>().OfferPrice = (int)InitialThresholdPrice;
        attempt = 5;
        NewThresholdPrice = InitialThresholdPrice;

    }

	public void BuyfromHero(int OfferedPrice, int OfferedQuantity)
    {
     
		if (OfferedPrice > CreateHero.Hero.GetComponent<Hero> ().money) {
			// show dialogue "not enough money for that"
			
		}else if (OfferedPrice <= NewThresholdPrice * 0.9 * OfferedQuantity) {//if price is outside of price range do this else accept price
			
			if (attempt == 5) {//on first attempt hero offers their initial price
				//CreateHero.Hero.GetComponent<Hero>().OfferPrice = (int)(CreateHero.Hero.GetComponent<Hero>().OfferPrice + ((CreateHero.Hero.GetComponent<Hero>().OfferPrice + OfferedPrice) / 4));
				CreateHero.Hero.GetComponent<Hero> ().OfferPriceToQty = (int)NewThresholdPrice * OfferedQuantity;
				CreateHero.Hero.GetComponent<Hero> ().CurrentNode = CreateHero.Hero.GetComponent<Hero> ().lines [DialogTree.Traverse (CreateHero.Hero.GetComponent<Hero> ().CurrentNode, false)];
				attempt--;
			} else if (attempt != 0) {//increase Price threshold
				OfferedPrice /= OfferedQuantity;
				NewThresholdPrice = NewThresholdPrice + ((OfferedPrice - NewThresholdPrice) / 4);
				CreateHero.Hero.GetComponent<Hero> ().OfferPriceToQty = (int)NewThresholdPrice * OfferedQuantity;
				CreateHero.Hero.GetComponent<Hero> ().CurrentNode = CreateHero.Hero.GetComponent<Hero> ().lines [DialogTree.Traverse (CreateHero.Hero.GetComponent<Hero> ().CurrentNode, false)];
				attempt--;
			} else {//if the nmber of attempts is reached
				transform.GetComponent<Button> ().interactable = false;
				StartDialogScene.NoSale.Add (item.name);
			}
		} else
        {
            CreateHero.Hero.GetComponent<Hero>().CurrentNode = CreateHero.Hero.GetComponent<Hero>().lines[DialogTree.Traverse(CreateHero.Hero.GetComponent<Hero>().CurrentNode, true)];
            Debug.Log(CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory[Itemindex].name);
            Inventory.AddItem(CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory[Itemindex]);//moves item from hero inventory to players inventory
            GameMaster.ReduceGold(OfferedPrice);

            CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory.RemoveAt(Itemindex);//remove item from hero inventory
            CreateHero.Hero.GetComponentInChildren<Hero>().money += OfferedPrice;//add money to hero
            Debug.Log("Money:" + CreateHero.Hero.GetComponentInChildren<Hero>().money);
            StartDialogScene.CloseBuyFromPanel();
            StartDialogScene.BuyHeroPanel();
        }
    }
}
