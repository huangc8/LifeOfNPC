using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartDialogScene : MonoBehaviour {

    public static Hero CurrentHero;
    public static Text HeroDialog;
    public static GameObject DialogPanel;
    public static GameObject BuyButton;
    public static GameObject SellButton;
    public static GameObject IncPriceButton;       // prefab for Buy button
    public static GameObject DecPriceButton;       // prefab for Buy button
    public static GameObject OfferField;
    public static GameObject canvas;            // the Canvas object

    // Prefabs
    public static GameObject DialogPanelPF;  // prefab for Dialog panel
    public static GameObject BuyButtonPF;       // prefab for Buy button
    public static GameObject SellButtonPF;       // prefab for Buy button
    public static GameObject IncPriceButtonPF;       // prefab for Buy button
    public static GameObject DecPriceButtonPF;       // prefab for Buy button
    public static GameObject OfferFieldPF;   // prefab for offer field

    public GameObject DialogPanelPf_r;       // non static Dialog panel
    public GameObject BuyButtonPf_r;            // non static button
    public GameObject SellButtonPf_r;            // non static button
    public GameObject IncPriceButtonPF_r;       // prefab for Buy button
    public GameObject DecPriceButtonPF_r;       // prefab for Buy button
    public GameObject OfferFieldPF_r;        // non static field
    public GameObject canvas_r;              // non static canvas reference

    // Use this for initialization
    void Start() {

        CurrentHero = new Hero();//create hero
        CurrentHero.FillInventory(CurrentHero.qii);//fill hero inventory based on quality of inventory variable
        HeroDialog = GetComponent("Text") as Text;//sets dialog
        HeroDialog.text = CurrentHero.text.text;//prints text to heros text box

        DialogPanelPF = DialogPanelPf_r;
        BuyButtonPF = BuyButtonPf_r;
        SellButtonPF = SellButtonPf_r;
        IncPriceButtonPF = IncPriceButtonPF_r;  
        DecPriceButtonPF = DecPriceButtonPF_r;       // prefab for Buy button
        OfferFieldPF = OfferFieldPF_r;
        canvas = canvas_r;

        Inventory.AddItem("Apple", 1, "An Apple");
        Inventory.AddItem("Orange", 1, "An Orange");
        Inventory.AddItem("Banana", 1, "A Banana");

    }

    void Update()
    {
        HeroDialog.text = CurrentHero.lines[CurrentHero.patience];//changes heros dialog
    }



    #region Sell to hero
    // opens up the sell inventory
    public static void SellHeroPanel()
    {
        DialogPanel = Instantiate(DialogPanelPF) as GameObject;
        DialogPanel.transform.SetParent(canvas.transform, false);



        int i = 0;
        foreach (Item it in Inventory._Items)
        {
            SellButton = Instantiate(SellButtonPF) as GameObject;//creates button on the dialog panel
            SellButton.transform.SetParent(DialogPanel.transform, false);//sets position
            SellButton.transform.Translate(new Vector3(0, i*-60, 0));//spaces buttons
            SellButton.GetComponentInChildren<Text>().text = "Sell " + it.name;//sets the text that is inside the button

            OfferField = Instantiate(OfferFieldPF) as GameObject;//creates input field on the dialog panel
            OfferField.transform.SetParent(SellButton.transform, false);//parents and sets position

            IncPriceButton = Instantiate(IncPriceButtonPF) as GameObject;//creates button on the dialog panel
            IncPriceButton.transform.SetParent(OfferField.transform, false);//parents sets position

            DecPriceButton = Instantiate(DecPriceButtonPF) as GameObject;//creates button on the dialog panel
            DecPriceButton.transform.SetParent(OfferField.transform, false);//parents sets position
            i++;
        }
    }

    #endregion



    #region Buy From Hero
    public static void BuyHeroPanel()
    {
        DialogPanel = Instantiate(DialogPanelPF) as GameObject;
        DialogPanel.transform.SetParent(canvas.transform, false);

        foreach (Item it in CurrentHero.H_Inventory)
        {
            BuyButton = Instantiate(BuyButtonPF) as GameObject;//creates button on the dialog panel
            BuyButton.transform.SetParent(DialogPanel.transform, false);//parents sets position
            BuyButton.GetComponentInChildren<Text>().text = "Buy " + it.name;//sets the text that is inside the button

            OfferField = Instantiate(OfferFieldPF) as GameObject;//creates input field on the dialog panel
            OfferField.transform.SetParent(BuyButton.transform, false);//parents and sets position

            IncPriceButton = Instantiate(IncPriceButtonPF) as GameObject;//creates button on the dialog panel
            IncPriceButton.transform.SetParent(OfferField.transform, false);//parents sets position

            DecPriceButton = Instantiate(DecPriceButtonPF) as GameObject;//creates button on the dialog panel
            DecPriceButton.transform.SetParent(OfferField.transform, false);//parents sets position

        }
    }

    #endregion


    // close inventory
    public static void CloseDialogPanel()
    {
        Destroy(DialogPanel);
    }
}
