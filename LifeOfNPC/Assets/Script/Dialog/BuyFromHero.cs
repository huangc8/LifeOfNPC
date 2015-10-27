using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class BuyFromHero : MonoBehaviour {

    public void BuyfromHero()
    {

        int OfferedPrice = int.Parse(transform.GetComponentInChildren<InputField>().text);//converts text in input field to int
        //Debug.Log(OfferedPrice);

        if (OfferedPrice < 100)
        {
            CreateHero.Hero.GetComponentInChildren<Hero>().patience++;
            if (CreateHero.Hero.GetComponentInChildren<Hero>().patience == CreateHero.Hero.GetComponentInChildren<Hero>().lines.Length - 1)
            {
                CreateHero.Hero.GetComponentInChildren<Hero>().patience--;
                StartDialogScene.CloseDialogPanel();
            }
        }

        else
        {
            CreateHero.Hero.GetComponentInChildren<Hero>().patience = CreateHero.Hero.GetComponentInChildren<Hero>().lines.Length - 1;
            CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory.RemoveAt(0);
            CreateHero.Hero.GetComponentInChildren<Hero>().money += OfferedPrice;
            Debug.Log("Money:" + CreateHero.Hero.GetComponentInChildren<Hero>().money);
            StartDialogScene.CloseDialogPanel();
            StartDialogScene.BuyHeroPanel();
        }
    }
}
