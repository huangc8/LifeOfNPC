using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class SellToHero : MonoBehaviour {

    public float InitialThresholdPrice;
    public float NewThresholdPrice;
    public Item item;
	public AudioSource cash;

    public void OnStart()
    {
		//sets the initial price hero will buy at
        float itemprice = item.supplyPrice;
        InitialThresholdPrice = ((100 - CreateHero.Hero.GetComponentInChildren<Hero>().thriftiness) / 100) * itemprice;
		NewThresholdPrice = InitialThresholdPrice;
    }

    public void SelltoHero(int OfferedPrice, int OfferedQuantity)
    {
		Hero hero = CreateHero.Hero.GetComponent<Hero> ();
		hero.OfferQuantity = OfferedQuantity;
		if (OfferedPrice > NewThresholdPrice * 1.1 * OfferedQuantity) {//if price is outside of price range do this else accept price
			hero.sellAttempt--;
			if (hero.sellAttempt == 2) {//on first attempt hero offers their initial price
				CreateHero.Hero.GetComponent<Hero> ().OfferPriceToQty = (int)NewThresholdPrice * OfferedQuantity;
			} else if (hero.sellAttempt > 0) {//increase Price threshold
				OfferedPrice /= OfferedQuantity;
				NewThresholdPrice = NewThresholdPrice + ((OfferedPrice + NewThresholdPrice) / 4);
				CreateHero.Hero.GetComponent<Hero> ().OfferPriceToQty = (int)NewThresholdPrice * OfferedQuantity;
			} else {//if the nmber of attempts is reached
				StartDialogScene.NoSale.Add (item.name);
				CloseSellButton ();
			}
			hero.SellDialog (false);
		} else {
			hero.SellDialog (true);
            hero.H_Inventory.Add(item);
			hero.money -= OfferedPrice;
			Inventory.RemoveItem(item.name, OfferedQuantity);
            GameMaster.AddGold(OfferedPrice);
			GameMaster.sold++;
			CloseSellButton ();
			cash.Play();
        }
    }

	public void CloseSellButton(){
		foreach (Button button in CreateHero.Hero.GetComponent<Hero>().GetComponentsInChildren<Button>())
		{	
			if (button.name == "SellButton") {
				button.interactable = false;
			}
		}
	}
}
