using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class SellToHero : MonoBehaviour {

    public void SelltoHero()
    {
        //CreateHero.Hero.GetComponentInChildren<Hero>().patience = 1;
        int OfferedPrice = int.Parse(transform.GetComponentInChildren<InputField>().text);//converts text in input to int
        Debug.Log(OfferedPrice);

        if (OfferedPrice > 100)
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
            CreateHero.Hero.GetComponentInChildren<Hero>().dialog = CreateHero.Hero.GetComponentInChildren<Hero>().lines[2];
            string item = transform.GetComponentInChildren<Text>().text;
            Inventory.RemoveItem(item, 1);
            StartDialogScene.CurrentHero.GetComponentInChildren<Hero>().money -= OfferedPrice;
            Debug.Log("Money:" + StartDialogScene.CurrentHero.GetComponentInChildren<Hero>().money);
            StartDialogScene.CloseDialogPanel();
            StartDialogScene.SellHeroPanel();
        }
    }
}
