using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class CreateHero : MonoBehaviour {

    public static GameObject Hero;
    public static GameObject canvas;            // the Canvas object
    public static Text HeroDialogBox;

    public static GameObject HeroPF;

    public GameObject HeroPf_r;
    public GameObject canvas_r;              // non static canvas reference

    // Use this for initialization
    public void StartCreateHero () {

        HeroPF = HeroPf_r;
        canvas = canvas_r;

        Hero = Instantiate(HeroPF) as GameObject;
        Hero.transform.SetParent(canvas.transform, false);

        Hero.AddComponent<Hero>();//adds hero component upon creation

        HeroDialogBox = Hero.GetComponentInChildren<Text>() as Text;//sets dialog
        HeroDialogBox.text = Hero.GetComponent<Hero>().dialog;//prints text to heros text box

    }

    public void DismissHero()
    {
        Destroy(Hero);//should remove hero object
    }
}
