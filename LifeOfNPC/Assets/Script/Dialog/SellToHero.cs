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
    public int attempt;
    public Item item;
	public int sellQuantity;

    public void OnStart()
    {
		//sets the initial price hero will buy at
        float itemprice = item.supplyPrice;
        InitialThresholdPrice = ((100 - CreateHero.Hero.GetComponentInChildren<Hero>().thriftiness) / 100) * itemprice;
		NewThresholdPrice = InitialThresholdPrice;
		attempt = 5;
    }

    public void SelltoHero(int OfferedPrice, int OfferedQuantity)
    {
		sellQuantity = OfferedQuantity;

		if (OfferedPrice > CreateHero.Hero.GetComponent<Hero> ().money) {
		// show dialogue "not enough money for that"
			
		}else if (OfferedPrice >= NewThresholdPrice * 1.1 * OfferedQuantity) {//if price is outside of price range do this else accept price
            
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
            CreateHero.Hero.GetComponent<Hero>().H_Inventory.Add(item);
            Inventory.RemoveItem(item.name, sellQuantity);
            CreateHero.Hero.GetComponentInChildren<Hero>().money -= OfferedPrice;
            StartDialogScene.CloseSellToPanel();
            StartDialogScene.SellHeroPanel();
        }
    }

}
