using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class Hero : MonoBehaviour {


    //Hero class

    //public static GameObject hero;
    //public static GameObject canvas;            // the Canvas object
    //public static Text HeroDialogBox;

    //public static GameObject HeroPF;

    //public GameObject HeroPf_r;
    //public GameObject canvas_r;              // non static canvas reference




    public string name;
    public int money;
    public float thriftiness;//price range hero expects for the item
    public int qii;//quality of inventory items
    public float willingness;//willingness to sell items to store owner
    public List<Item> H_Inventory;//heros inventory
    public string[] lines;
    public string dialog;
    public int patience;

    public TextAsset BuyingDialog;//text file asset that contains dialog

    //constructor
    public Hero()
    {
        name = "Steve";
        money = UnityEngine.Random.Range(1000, 4000);
        thriftiness = UnityEngine.Random.Range(0, 51);
        qii = UnityEngine.Random.Range(1, 3); ;
        H_Inventory = new List<Item>();
        patience = 0;
        
        BuyingDialog = Resources.Load("HeroDialog") as TextAsset;//text file that is loaded from resourses
        char delimiters = ',';
        
        lines = BuyingDialog.text.Split(delimiters);//separates dialog into individual lines
        dialog = lines[patience];

        //H_Inventory.Add(new Item("Apple", 1, "An Apple"));

        //hero = Instantiate(HeroPF) as GameObject;
        //hero.transform.SetParent(canvas.transform, false);

        FillInventory(qii);//fill hero inventory based on quality of inventory variable
        //HeroDialogBox = GetComponent("Text") as Text;//sets dialog
        //HeroDialogBox.text = hero.GetComponentInChildren<Hero>().text.text;//prints text to heros text box

    }//ends hero constructor



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
                int lowItems = 1;
                for (int i = 0; i < lowItems; i++)
                {
                    Debug.Log("low quality");
                    //add random low quality items to hero inventory
                    H_Inventory.Add(new Item("Apple", 1, "An Apple"));
                }
                break;

            case 2:
                int mediItems = 1;
                for (int i = 0; i < mediItems; i++)
                {
                    Debug.Log("medium quality");
                    //add random medium quality items to hero inventory
                    H_Inventory.Add(new Item("Orange", 1, "An Orange"));
                }
                break;

            case 3:
                int highItems = 1;
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
