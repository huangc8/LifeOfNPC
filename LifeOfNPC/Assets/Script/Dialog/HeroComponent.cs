using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeroComponent : MonoBehaviour {

    public Image HeroPortrait;
    public CreateHero _createhero;
	public StartDialogScene _startDialogScene;
    
    public void DismissClick()
    {
		_startDialogScene.HeroKnocked = CreateHero.DismissHero(_startDialogScene.HeroKnocked);
		if (StartDialogScene.NumHeroesToday > 0) {
			_createhero.CreateKnock ();
		}
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
