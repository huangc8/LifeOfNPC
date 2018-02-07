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
    public int Itemindex;
    public Item item;

    public void Awake()
    {
        item = CreateHero.Hero.GetComponent<Hero>().H_Inventory[Itemindex];
        float itemprice = item.supplyPrice;//will be the price of the item
        InitialThresholdPrice = ((100 + CreateHero.Hero.GetComponent<Hero>().thriftiness) / 100) * itemprice;//sets the initial price hero will buy at
        CreateHero.Hero.GetComponent<Hero>().OfferPrice = (int)InitialThresholdPrice;
        NewThresholdPrice = InitialThresholdPrice;

    }

	public void BuyfromHero(int OfferedPrice, int OfferedQuantity)
    {
		Hero hero = CreateHero.Hero.GetComponent<Hero> ();
		hero.OfferQuantity = OfferedQuantity;
		if (OfferedPrice > GameMaster.gold) {
			hero.updateDialog ("Oops, I don't have enough money");
			// change icon image
		}else if (OfferedPrice <= NewThresholdPrice * 0.9 * OfferedQuantity) {//if price is outside of price range do this else accept price
			hero.buyAttempt--;
			if (hero.buyAttempt == 2) {//on first attempt hero offers their initial price
				hero.OfferPriceToQty = (int)NewThresholdPrice * OfferedQuantity;
			} else if (hero.buyAttempt > 0) {//increase Price threshold
				OfferedPrice /= OfferedQuantity;
				NewThresholdPrice = NewThresholdPrice + ((OfferedPrice - NewThresholdPrice) / 4);
				hero.OfferPriceToQty = (int)NewThresholdPrice * OfferedQuantity;
			} else {//if the nmber of attempts is reached
				StartDialogScene.NoSale.Add (item.name);
				CloseBuyButton ();
			}
			hero.BuyDialog (false);
		} else {
			Inventory.AddItem(hero.H_Inventory[Itemindex]);//moves item from hero inventory to players inventory
            GameMaster.ReduceGold(OfferedPrice); //reduce player gold
			hero.H_Inventory.RemoveAt(Itemindex);//remove item from hero inventory
			hero.money += OfferedPrice;//add money to hero
			hero.BuyDialog (true);
			CloseBuyButton ();
        }
    }

	public void CloseBuyButton(){
		foreach (Button button in CreateHero.Hero.GetComponent<Hero>().GetComponentsInChildren<Button>())
		{	
			if (button.name == "BuyButton") {
				button.interactable = false;
			}
		}
	}
}
