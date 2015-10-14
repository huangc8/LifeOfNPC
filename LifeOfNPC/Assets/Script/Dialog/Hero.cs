using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Hero : MonoBehaviour {


        //Hero class
        public string name;
        public int money;
        public float thriftiness;//price range hero expects for the item
        public int qii;//quality of inventory items
        public float willingness;//willingness to sell items to store owner
        public List<Item> H_Inventory;//heros inventory
        public string dialog;
        public int patience;

    //constructor
    public Hero()
    {
        name = "Steve";
        money = UnityEngine.Random.Range(1000, 4000);
        thriftiness = UnityEngine.Random.Range(0, 51);
        qii = UnityEngine.Random.Range(1,4);
        H_Inventory = new List<Item>();
        dialog = "Hi my name is " + name;

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
