using UnityEngine;
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
    public List<DialogTree.DialogTreeNode> lines;
    public DialogTree.DialogTreeNode CurrentNode;
    public string dialog;
    public int patience;
    public int OfferPrice;
	public int OfferPriceToQty;
    public Item ItemBeingSold;
    public string RequiredItem;
    public int NumberOfEncounters;
    public int EncounterNumber;
    public bool Encounter1Success;
    public bool Encounter2Success;
    public bool Encounter3Success;

    //for determining dialog
    public int HeroClass;//whether hero is a wizard, warrior, or ranger
    public int purpose;

    //constructor
    public Hero()
    {
        name = null;
        HeroClass = UnityEngine.Random.Range(1, 3);
        List<string> RequiredItemList = new List<string>();
        EncounterNumber = 0;

    }//ends hero constructor

    void Update()
    {
        if (CreateHero.Hero.GetComponent<Hero>().CurrentNode != null)
        {
            //CreateHero.Hero.GetComponent<Hero>().CurrentNode.price = 
            if (CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Contains("$"))//check for insert money
            {
                CreateHero.Hero.GetComponent<Hero>().CurrentNode.line = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Substring(0, CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.IndexOf("$")) + OfferPriceToQty + CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Substring(CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.IndexOf("$") + 1);
            }

            if (CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Contains("*"))//check for insert specific item
            {
                CreateHero.Hero.GetComponent<Hero>().CurrentNode.line = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Substring(0, CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.IndexOf("*")) + OfferPriceToQty + CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Substring(CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.IndexOf("*") + 1);
            }

            if (CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Contains("#"))//check for insert item being sold
            {
                CreateHero.Hero.GetComponent<Hero>().CurrentNode.line = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Substring(0, CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.IndexOf("#")) + ItemBeingSold.name + CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.Substring(CreateHero.Hero.GetComponent<Hero>().CurrentNode.line.IndexOf("#") + 1);
            }

            CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
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
