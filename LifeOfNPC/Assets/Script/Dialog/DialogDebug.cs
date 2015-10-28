﻿using UnityEngine;
using System.Collections;

public class DialogDebug : MonoBehaviour {

    void OnGUI()
    {
       
        if (GUI.Button(new Rect(10, 310, 100, 30), "Sell to Hero"))
        {
            StartDialogScene.SellHeroPanel();
        }

        if (GUI.Button(new Rect(10, 345, 100, 30), "Buy from Hero"))
        {
            StartDialogScene.BuyHeroPanel();
        }

        if (GUI.Button(new Rect(10, 385, 100, 30), "Back"))
        {
            StartDialogScene.CloseDialogPanel();
        }

    }
}
