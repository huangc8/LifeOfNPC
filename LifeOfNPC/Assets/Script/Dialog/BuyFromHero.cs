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

    void Start()
    {
        item = CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory[Itemindex];
        Debug.Log(item.supplyPrice);
        float itemprice = 100;//will be the price of the item
        InitialThresholdPrice = ((100 + CreateHero.Hero.GetComponentInChildren<Hero>().thriftiness) / 100) * itemprice;//sets the initial price hero will buy at
        Debug.Log("Current Threshold Price:" + InitialThresholdPrice);
        attempt = 5;
        NewThresholdPrice = InitialThresholdPrice;

    }

    public void BuyfromHero()
    {
        int OfferedPrice = int.Parse(transform.GetComponentInChildren<InputField>().text);//converts text in input field to int


        if (OfferedPrice <= NewThresholdPrice * 0.9)
        {
            if (attempt == 5)//on first attempt hero offers their initial price
            {
                CreateHero.Hero.GetComponentInChildren<Hero>().dialog = "How about " + InitialThresholdPrice;//price the hero offers
                attempt--;
            }

            else if (attempt != 0)//increase Price threshold 
            {
                NewThresholdPrice = NewThresholdPrice - ((NewThresholdPrice - OfferedPrice) / 5);
                CreateHero.Hero.GetComponentInChildren<Hero>().dialog = "Ok how about " + NewThresholdPrice;//price the hero offers
                attempt--;
            }

            else//if the number of attempts is reached
            {
                CreateHero.Hero.GetComponentInChildren<Hero>().dialog = "I think I'll sell that elsewhere";
                transform.GetComponent<Button>().interactable = false;

            }


            if (CreateHero.Hero.GetComponentInChildren<Hero>().patience == CreateHero.Hero.GetComponentInChildren<Hero>().lines.Length - 1)
            {
                CreateHero.Hero.GetComponentInChildren<Hero>().patience--;
                StartDialogScene.CloseDialogPanel();
            }
        }

        else
        {
            CreateHero.Hero.GetComponentInChildren<Hero>().dialog = OfferedPrice + " sounds fair enough";
            CreateHero.Hero.GetComponentInChildren<Hero>().patience = CreateHero.Hero.GetComponentInChildren<Hero>().lines.Length - 1;
            Debug.Log(CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory[Itemindex].name);
            Inventory.AddItem(CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory[Itemindex]);//moves item from hero inventory to players inventory

            CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory.RemoveAt(Itemindex);//remove item from hero inventory
            CreateHero.Hero.GetComponentInChildren<Hero>().money += OfferedPrice;//add money to hero
            Debug.Log("Money:" + CreateHero.Hero.GetComponentInChildren<Hero>().money);
            StartDialogScene.CloseDialogPanel();
            StartDialogScene.BuyHeroPanel();
        }
    }
}
