using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeroComponent : MonoBehaviour {

    public Image HeroPortrait;
    public Text DialogBox;
    public CreateHero _createhero;
    
    public void DismissClick()
    {
        Debug.Log(StartDialogScene.NumHeroesToday);
        CreateHero.DismissHero();
        StartDialogScene.NumHeroesToday--;//decrease number of heroes in line
        _createhero.StartCreateHero();
    }

    public void SellClick()
    {
        StartDialogScene.SellHeroPanel();
    }

    public void BuyClick()
    {
        StartDialogScene.BuyHeroPanel();
    }
}
