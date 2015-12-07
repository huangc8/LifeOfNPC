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

    public string SpecialHeroName;

    // Use this for initialization
    public void StartCreateHero () {

        HeroPF = HeroPf_r;
        canvas = canvas_r;

        Hero = Instantiate(HeroPF) as GameObject;
        Hero.transform.SetParent(canvas.transform, false);

        int SpecialHeroAppeared = 6;//UnityEngine.Random.Range(0, 6);

        if (SpecialHeroAppeared != 7)// change to gamemaster.currentday
        {
            Hero.AddComponent<Hero>();//adds hero component upon creation

            CreateGenericHero();//only this is new

            HeroDialogBox = Hero.GetComponentInChildren<Text>() as Text;//sets dialog
            HeroDialogBox.text = Hero.GetComponent<Hero>().dialog;//prints text to heros text box
        }

        else
        {
            Hero.AddComponent<Hero>();//adds hero component upon creation

            LoadSpecialHero();

            HeroDialogBox = Hero.GetComponentInChildren<Text>() as Text;//sets dialog
            HeroDialogBox.text = Hero.GetComponent<Hero>().dialog;//prints text to heros text box
        }

    }

    public void DismissHero()
    {
        if (Hero.GetComponent<Hero>().name == null)
        {
            Destroy(Hero);//should remove hero object
        }

        else {
            if(Hero.GetComponent<Hero>().name == "Quartz" && Hero.GetComponent<Hero>().NumberOfEncounters == 1)
            {
                bool potion1 = false, potion2 = false, potion3 = false;
                foreach(Item it in Hero.GetComponent<Hero>().H_Inventory)
                {
                    if(it.name == "Elixirs of Minor Rejuvenation") { potion1 = true; }
                    if (it.name == "Unguents of Minor Invigoration") { potion2 = true; }
                    if (it.name == "tonics of Minor Restoration") { potion3 = true; }
                }
                if(potion1 && potion2 && potion3) { Hero.GetComponent<Hero>().Encounter2Success = true; }
            }
            Hero.GetComponent<Hero>().NumberOfEncounters++;//increases the number of times encountered

            if (StartDialogScene.SpecialHeroes.Count == 0)//if first hero encountered
            {
                Hero.GetComponent<Hero>().EncounterNumber++;
                StartDialogScene.SpecialHeroes.Add(Hero.GetComponent<Hero>());//add the hero component to the list
            }

            else
            {
                bool InList = false;
                int SHeroIndex = 0;
                int index = 0;
                foreach (Hero SHero in StartDialogScene.SpecialHeroes)
                {
                    if (SHero.name == Hero.GetComponent<Hero>().name)
                    {
                        InList = true;
                        SHeroIndex = index;
                    }
                    index++;
                }

                Hero.GetComponent<Hero>().EncounterNumber++;//increases number of times hero has been encountered

                if (InList)//if hero is in list
                {
                    StartDialogScene.SpecialHeroes.RemoveAt(SHeroIndex);//remove old hero component
                    StartDialogScene.SpecialHeroes.Add(Hero.GetComponent<Hero>());//add new hero component to the list
                }

                else//if hero is not in the list already
                {
                    StartDialogScene.SpecialHeroes.Add(Hero.GetComponent<Hero>());//adds the hero component to the list
                }

            }
        }
        Destroy(Hero);//should remove hero object after it has been saved

    }

    public void CreateGenericHero()
    {
        Hero.GetComponent<Hero>().money = UnityEngine.Random.Range(1000, 4000);
        Hero.GetComponent<Hero>().thriftiness = UnityEngine.Random.Range(0, 51);
        Hero.GetComponent<Hero>().qii = UnityEngine.Random.Range(1, 3);
        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
        Hero.GetComponent<Hero>().patience = 0;
        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
        Hero.GetComponent<Hero>().purpose = UnityEngine.Random.Range(0, 1);
        StreamReader Dialog;//text file asset that contains dialog

        int HeroClass = Hero.GetComponent<Hero>().HeroClass;
        switch (HeroClass)
        {
            case 1:
                //wizard
                Dialog = new StreamReader("Assets/Resources/StockWizardDialog.txt");//text file that is loaded from resourses
                DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                Dialog.Close();//closes streamreader
                Debug.Log("Your a wizard Harry");
                break;

            case 2:
                //warrior
                Dialog = new StreamReader("Assets/Resources/StockWarriorDialog.txt"); ;//text file that is loaded from resourses
                DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                Dialog.Close();//closes stream reader
                Debug.Log("I am a warrior");
                break;

            case 3:
                //ranger
                Dialog = new StreamReader("Assets/Resources/StockRangerDialog.txt"); ;//text file that is loaded from resourses
                DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                Dialog.Close();//closes stream reader
                Debug.Log("I am a ranger");
                break;

            default:
                break;

        }

        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;


        Hero.GetComponent<Hero>().FillInventory(Hero.GetComponent<Hero>().qii);//fill hero inventory based on quality of inventory variable
    }


    public void LoadSpecialHero()
    {
        //randomly choose hero
        int WhichHero = 0;// UnityEngine.Random.Range(0, 2);

        switch (WhichHero)
        {
            case 0:
                SpecialHeroName = "Quartz";
                break;

            case 1:
                SpecialHeroName = "Felix";
                break;

            case 2:
                SpecialHeroName = "Riella";
                break;
        }
        //if hero exists in list and is not done then load hero from list, else if hero not in list then create hero with special stats
        bool InList = false;
        int SHeroIndex = 0;
        int i = 0;
       
            if (StartDialogScene.SpecialHeroes == null)//if no heroes in list
            {

            }
            else
            {
                foreach (Hero SHero in StartDialogScene.SpecialHeroes)
                {
                    if (SHero.name == SpecialHeroName)
                    {
                        InList = true;
                        SHeroIndex = i;
                    }
                    i++;
                }
            //Debug.Log("encounter number" + StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber);
            //Debug.Log("total number encounters" + StartDialogScene.SpecialHeroes[SHeroIndex].NumberOfEncounters);
        }
        Debug.Log(InList);
        
            if (!InList)//meeting for the first time
            {
                //Hero.AddComponent<Hero>();//adds hero component upon creation
                StreamReader Dialog;//text file asset that contains dialog
                                    //fill in hero stats
                switch (SpecialHeroName)
                {
                    case "Quartz":
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = 0;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 3;
                        Hero.GetComponent<Hero>().money = 3000;
                        Hero.GetComponent<Hero>().thriftiness = 0;
                        Hero.GetComponent<Hero>().RequiredItem = "Trusty Sword";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/QuartzDialog.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                        break;

                    case "Felix":
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                    Hero.GetComponent<Hero>().EncounterNumber = 0;
                    Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 5280;
                        Hero.GetComponent<Hero>().thriftiness = 40;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/FelixDialog.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        break;

                    case "Riella":
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = 0;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 18060;
                        Hero.GetComponent<Hero>().thriftiness = 10;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/RiellaDialog.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        break;
                }
            }

            if (InList && StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber != StartDialogScene.SpecialHeroes[SHeroIndex].NumberOfEncounters)//if hero has returned after first encounter
            {
                StreamReader Dialog;//text file asset that contains dialog
                                    //alter stats as needed
                switch (StartDialogScene.SpecialHeroes[SHeroIndex].name)
                {
                    case "Quartz":
                        //Hero.AddComponent<Hero>();//adds hero component upon creation
                        if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 1)
                        {
                            Hero.GetComponent<Hero>().name = SpecialHeroName;
                            Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                            Hero.GetComponent<Hero>().NumberOfEncounters = 3;
                            Hero.GetComponent<Hero>().money = 4725;
                            Hero.GetComponent<Hero>().thriftiness = 15;
                            Hero.GetComponent<Hero>().RequiredItem = "none";
                            Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                            Hero.GetComponent<Hero>().patience = 0;
                            Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                            Dialog = new StreamReader("Assets/Resources/QuartzDialog2.txt");//text file that is loaded from resourses
                            DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                            Dialog.Close();//closes streamreader
                            Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                            CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                        }
                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 2 && StartDialogScene.SpecialHeroes[SHeroIndex].Encounter2Success)//if Quartz was sold all the potions
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 3;
                        Hero.GetComponent<Hero>().money = 22000;
                        Hero.GetComponent<Hero>().thriftiness = 25;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/QuartzDialog3a.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }

                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 2 && !StartDialogScene.SpecialHeroes[SHeroIndex].Encounter2Success)//if Quartz was not sold all the potions
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 3;
                        Hero.GetComponent<Hero>().money = 22500;
                        Hero.GetComponent<Hero>().thriftiness = 0;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/QuartzDialog3b.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }

                    break;

                    case "Felix":
                    //Hero.AddComponent<Hero>();//adds hero component upon creation
                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 1)
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 14805;
                        Hero.GetComponent<Hero>().thriftiness = 45;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/FelixDialog2.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }
                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 2)
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 19200;
                        Hero.GetComponent<Hero>().thriftiness = 50;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/FelixDialog3.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }
                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 3)
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 66000;
                        Hero.GetComponent<Hero>().thriftiness = 30;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/FelixDialog4.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }

                    break;

                    case "Riella":
                    //Hero.AddComponent<Hero>();//adds hero component upon creation
                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 1)
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 26910;
                        Hero.GetComponent<Hero>().thriftiness = 20;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/RiellaDialog2.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }
                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 2)
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 25000;
                        Hero.GetComponent<Hero>().thriftiness = 20;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/RiellaDialog3.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }
                    if (StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == 3)
                    {
                        Hero.GetComponent<Hero>().name = SpecialHeroName;
                        Hero.GetComponent<Hero>().EncounterNumber = StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber;
                        Hero.GetComponent<Hero>().NumberOfEncounters = 4;
                        Hero.GetComponent<Hero>().money = 85675;
                        Hero.GetComponent<Hero>().thriftiness = 35;
                        Hero.GetComponent<Hero>().RequiredItem = "none";
                        Hero.GetComponent<Hero>().H_Inventory = new List<Item>();
                        Hero.GetComponent<Hero>().patience = 0;
                        Hero.GetComponent<Hero>().lines = new List<DialogTree.DialogTreeNode>();
                        Dialog = new StreamReader("Assets/Resources/RiellaDialog4.txt");//text file that is loaded from resourses
                        DialogTree.CreateTree(Dialog, Hero.GetComponent<Hero>().lines);//fills dialog tree
                        Dialog.Close();//closes streamreader
                        Hero.GetComponent<Hero>().CurrentNode = Hero.GetComponent<Hero>().lines[0];
                        CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponent<Hero>().CurrentNode.line;
                    }

                    break;
                }
            }

            if (InList && StartDialogScene.SpecialHeroes[SHeroIndex].EncounterNumber == StartDialogScene.SpecialHeroes[SHeroIndex].NumberOfEncounters)//if hero arch is done
            {
                //generate generic hero
                CreateGenericHero();
            }
        }
    }
