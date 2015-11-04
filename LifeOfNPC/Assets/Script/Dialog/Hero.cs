﻿using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hero : MonoBehaviour {


    //Hero class

    public string name;
    public int money;
    public float thriftiness;//price range hero expects for the item
    public int qii;//quality of inventory items
    public float willingness;//willingness to sell items to store owner
    public List<Item> H_Inventory;//heros inventory
    public string[] lines;
    public string dialog;
    public int patience;

    //for determining dialog
    public int HeroClass;//whether hero is a wizard, warrior, or ranger
    public int purpose;
    public int dialogIndex;
    public string[] dialogScript;


    public TextAsset BuyingDialog;//text file asset that contains dialog

    //constructor
    public Hero()
    {
        name = "Steve";
        money = UnityEngine.Random.Range(1000, 4000);
        thriftiness = UnityEngine.Random.Range(0, 51);
        qii = UnityEngine.Random.Range(1, 3);
        H_Inventory = new List<Item>();
        patience = 0;
        dialogIndex = 0;
        

        HeroClass = UnityEngine.Random.Range(1, 3);
        purpose = UnityEngine.Random.Range(0,1);

        switch (HeroClass)
        {
            case 1:
                //wizard
                BuyingDialog = Resources.Load("StockWizardDialog") as TextAsset;//text file that is loaded from resourses
                break;

            case 2:
                //warrior
                BuyingDialog = Resources.Load("StockWarriorDialog") as TextAsset;//text file that is loaded from resourses
                break;

            case 3:
                //ranger
                BuyingDialog = Resources.Load("StockRangerDialog") as TextAsset;//text file that is loaded from resourses
                break;

            default:
                break;

        }

        
        char delimiters = '#';
        dialogScript = BuyingDialog.text.Split(delimiters);//separates dialog into individual scripts
        delimiters = '|';
        lines = dialogScript[1].Split(delimiters);
        dialog = "";
        


        FillInventory(qii);//fill hero inventory based on quality of inventory variable

    }//ends hero constructor

    void Update()
    {
        if (dialogIndex <= 3)
        {
            CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponentInChildren<Hero>().lines[dialogIndex];//changes heros dialog
        }
        else
        {
            CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponentInChildren<Hero>().dialog;
        }
    }



    public void printInventory()
    {
        foreach(Item it in H_Inventory)
        {
            Debug.Log(it.name);
        }
    }

    public void FillInventory(int qii)
    {
        //fill inventory
        switch (qii)
        {
            case 1:
                int lowItems = 2;
                for (int i = 0; i < lowItems; i++)
                {
                    Debug.Log("low quality");
                    //add random low quality items to hero inventory
                    H_Inventory.Add(new Item("Apple", 1, "An Apple"));
                }
                break;

            case 2:
                int mediItems = 2;
                for (int i = 0; i < mediItems; i++)
                {
                    Debug.Log("medium quality");
                    //add random medium quality items to hero inventory
                    H_Inventory.Add(new Item("Orange", 1, "An Orange"));
                }
                break;

            case 3:
                int highItems = 2;
                for (int i = 0; i < highItems; i++)
                {
                    Debug.Log("high quality");
                    //add random high quality items to hero inventory
                    H_Inventory.Add(new Item("Banana", 1, "A Banana"));
                }
                break;

            default:
                Debug.Log("no items in inventory");
                break;
        }//ends switch
    }

 

}//ends class
