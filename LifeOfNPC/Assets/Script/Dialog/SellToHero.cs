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
        StartDialogScene.CurrentHero.patience = 1;
        int OfferedPrice = int.Parse(transform.GetComponentInChildren<InputField>().text);//converts text in input to int
        Debug.Log(OfferedPrice);

        if (OfferedPrice > 100)
        {
            StartDialogScene.CurrentHero.patience++;
            if (StartDialogScene.CurrentHero.patience == StartDialogScene.CurrentHero.lines.Length - 1)
            {
                StartDialogScene.CurrentHero.patience--;
                StartDialogScene.CloseDialogPanel();
            }
        }

        else
        {
            StartDialogScene.CurrentHero.dialog = StartDialogScene.CurrentHero.lines[2];
            string item = transform.GetComponentInChildren<Text>().text;
            Inventory.RemoveItem(item, 1);
            StartDialogScene.CurrentHero.money -= OfferedPrice;
            Debug.Log("Money:" + StartDialogScene.CurrentHero.money);
            StartDialogScene.CloseDialogPanel();
            StartDialogScene.SellHeroPanel();
        }
    }
}
