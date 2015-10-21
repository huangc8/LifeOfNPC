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

        StartDialogScene.CurrentHero.patience = 1;
        int OfferedPrice = int.Parse(transform.GetComponentInChildren<InputField>().text);//converts text in input to int
        //Debug.Log(OfferedPrice);

        if (OfferedPrice < 100)
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
            StartDialogScene.CurrentHero.patience = StartDialogScene.CurrentHero.lines.Length - 1;
            StartDialogScene.CurrentHero.H_Inventory.RemoveAt(0);
            StartDialogScene.CurrentHero.money += OfferedPrice;
            Debug.Log("Money:" + StartDialogScene.CurrentHero.money);
            StartDialogScene.CloseDialogPanel();
            StartDialogScene.BuyHeroPanel();
        }
    }
}
