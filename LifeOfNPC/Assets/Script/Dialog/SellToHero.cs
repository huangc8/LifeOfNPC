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

    void Start()
    {
        float itemprice = 100;//will be the price of the item
        InitialThresholdPrice = ((100 - CreateHero.Hero.GetComponentInChildren<Hero>().thriftiness) / 100) * itemprice;//sets the initial price hero will buy at
        Debug.Log("Current Threshold Price:" + InitialThresholdPrice);
        attempt = 5;
        NewThresholdPrice = InitialThresholdPrice;

    }

    public void SelltoHero()
    {
        //CreateHero.Hero.GetComponentInChildren<Hero>().patience = 1;
        int OfferedPrice = int.Parse(this.GetComponent<SellButtonObjects>().OfferField.text);//converts text in input to int
        Debug.Log(OfferedPrice);

        if (OfferedPrice >= NewThresholdPrice * 1.1 )//if price is outside of price range do this else accept price
        {
            
            if (attempt == 5)//on first attempt hero offers their initial price
            {
                CreateHero.Hero.GetComponentInChildren<Hero>().dialog = "How about " + InitialThresholdPrice;//price the hero offers
                attempt--;
            }

            else if(attempt != 0)//increase Price threshold 
            {
                NewThresholdPrice = NewThresholdPrice + ((OfferedPrice - NewThresholdPrice)/4);
                CreateHero.Hero.GetComponentInChildren<Hero>().dialog = "Ok how about " + NewThresholdPrice;//price the hero offers
                attempt--;
            }

            else//if the nmber of attempts is reached
            {
                CreateHero.Hero.GetComponentInChildren<Hero>().dialog = "I think I'll buy that elsewhere";
                transform.GetComponent<Button>().interactable = false;
                StartDialogScene.NoSale.Add(this.GetComponent<SellButtonObjects>().namelabel.text);
            }
        }

        else
        {
            CreateHero.Hero.GetComponentInChildren<Hero>().dialog = OfferedPrice + " sounds fair enough";
            string item = transform.GetComponentInChildren<Text>().text;//the text in the button
            
            string itemName = item.Substring(item.IndexOf(" ")+1);//should get the item name from the button
            Debug.Log(itemName);
            Item it = new Item(itemName, 1, "");
            CreateHero.Hero.GetComponent<Hero>().H_Inventory.Add(it);
            Inventory.RemoveItem(itemName, 1);
            CreateHero.Hero.GetComponentInChildren<Hero>().money -= OfferedPrice;
            Debug.Log("Money:" + CreateHero.Hero.GetComponentInChildren<Hero>().money);
            StartDialogScene.CloseSellToPanel();
            StartDialogScene.SellHeroPanel();
        }
    }

}
