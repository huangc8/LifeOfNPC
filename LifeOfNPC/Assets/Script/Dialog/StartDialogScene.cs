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
    public static GameObject Button;
    public static GameObject OfferField;
    public static GameObject canvas;            // the Canvas object

    // Prefabs
    public static GameObject DialogPanelPF;  // prefab for Dialog panel
    public static GameObject ButtonPF;       // prefab for Buy button
    public static GameObject OfferFieldPF;   // prefab for offer field

    public GameObject DialogPanelPf_r;       // non static Dialog panel
    public GameObject ButtonPf_r;            // non static button
    public GameObject OfferFieldPF_r;        // non static field
    public GameObject canvas_r;              // non static canvas reference

    // Use this for initialization
    void Start() {

        CurrentHero = new Hero();
        CurrentHero.FillInventory(CurrentHero.qii);
        Debug.Log(CurrentHero.money);
        HeroDialog = GetComponent("Text") as Text;
        CurrentHero.printInventory();
        HeroDialog.text = CurrentHero.dialog;//prints text to heros text box

        DialogPanelPF = DialogPanelPf_r;
        ButtonPF = ButtonPf_r;
        OfferFieldPF = OfferFieldPF_r;
        canvas = canvas_r;
    }

    void Update()
    {
        HeroDialog.text = CurrentHero.dialog;
    }


    // opens up the inventory panel
    public static void SellHeroPanel()
    {
        DialogPanel = Instantiate(DialogPanelPF) as GameObject;
        DialogPanel.transform.SetParent(canvas.transform, false);

        int i = 0;
        foreach (Item it in Inventory._Items)
        {
            Button = Instantiate(ButtonPF) as GameObject;//creates button on the dialog panel
            Button.transform.SetParent(DialogPanel.transform, false);//sets position
            Button.transform.Translate(new Vector3(0, i*30, 0));//spaces buttons
            Button.GetComponentInChildren<Text>().text = "Buy " + it.name;//sets the text that is inside the button
            i++;
        }
    }

    public void SellToHero()
    {
        int OfferedPrice = int.Parse(OfferField.GetComponent<InputField>().text);//converts text in input to int
        Debug.Log(OfferedPrice);

        if (OfferedPrice < 100)
        {
            CurrentHero.dialog = "Come on you can go higher right";
            CloseDialogPanel();
            BuyHeroPanel();
        }

        else
        {
            CurrentHero.dialog = "I guess i could sell that low";
            CurrentHero.H_Inventory.RemoveAt(0);
            CurrentHero.money += OfferedPrice;
            Debug.Log("Money:" + CurrentHero.money);
            CloseDialogPanel();
            BuyHeroPanel();
        }
    }

    #region Buy From Hero
    public static void BuyHeroPanel()
    {
        DialogPanel = Instantiate(DialogPanelPF) as GameObject;
        DialogPanel.transform.SetParent(canvas.transform, false);

        foreach (Item it in CurrentHero.H_Inventory)
        {
            Button = Instantiate(ButtonPF) as GameObject;//creates button on the dialog panel
            Button.transform.SetParent(DialogPanel.transform, false);//sets position
            Button.GetComponentInChildren<Text>().text = "Buy " + it.name;//sets the text that is inside the button

            OfferField = Instantiate(OfferFieldPF) as GameObject;//creates input field on the dialog panel
            OfferField.transform.SetParent(DialogPanel.transform, false);//sets position

        }
    }

    public void BuyFromHero()
    {
        int OfferedPrice = int.Parse(OfferField.GetComponent<InputField>().text);//converts text in input to int
        Debug.Log(OfferedPrice);

        if (OfferedPrice < 100)
        {
            CurrentHero.dialog = "Come on you can go higher right";
            CloseDialogPanel();
            BuyHeroPanel();
        }

        else
        {
            CurrentHero.dialog = "I guess i could sell that low";
            CurrentHero.H_Inventory.RemoveAt(0);
            CurrentHero.money += OfferedPrice;
            Debug.Log("Money:" + CurrentHero.money);
            CloseDialogPanel();
            BuyHeroPanel();
        }
    }
    #endregion


    // close inventory
    public static void CloseDialogPanel()
    {
        Destroy(DialogPanel);
    }
}
