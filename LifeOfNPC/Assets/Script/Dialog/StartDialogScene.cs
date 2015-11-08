using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartDialogScene : MonoBehaviour {

    public static Hero CurrentHero;
    public static bool inMenu;

    public static GameObject BuyFromPanel;
    public static GameObject SellToPanel;
    public static GameObject ContentPanel;
    public static GameObject BuyButton;
    public static GameObject SellButton;
    public static GameObject IncPriceButton;       // prefab for Buy button
    public static GameObject DecPriceButton;       // prefab for Buy button
    public static GameObject OfferField;
    public static GameObject canvas;            // the Canvas object

    // Prefabs

    public static GameObject BuyFromPanelPF;  // prefab for Dialog panel
    public static GameObject SellToPanelPF;  // prefab for Dialog panel
    public static GameObject ContentPanelPF;
    public static GameObject BuyButtonPF;       // prefab for Buy button
    public static GameObject SellButtonPF;       // prefab for Buy button
    public static GameObject IncPriceButtonPF;       // prefab for Buy button
    public static GameObject DecPriceButtonPF;       // prefab for Buy button
    public static GameObject OfferFieldPF;   // prefab for offer field


    public GameObject BuyFromPanelPf_r;       // non static Dialog panel
    public GameObject SellToPanelPf_r;       // non static Dialog panel
    public GameObject ContentPanelPf_r;
    public GameObject BuyButtonPf_r;            // non static button
    public GameObject SellButtonPf_r;            // non static button
    public GameObject IncPriceButtonPF_r;       // prefab for Buy button
    public GameObject DecPriceButtonPF_r;       // prefab for Buy button
    public GameObject OfferFieldPF_r;        // non static field
    public GameObject canvas_r;              // non static canvas reference

    public bool HaveInventory = false;

    // Use this for initialization
    void Start() {
        BuyFromPanelPF = BuyFromPanelPf_r;
        SellToPanelPF = SellToPanelPf_r;
        ContentPanelPF = ContentPanelPf_r;
        BuyButtonPF = BuyButtonPf_r;
        SellButtonPF = SellButtonPf_r;
        IncPriceButtonPF = IncPriceButtonPF_r;  
        DecPriceButtonPF = DecPriceButtonPF_r;       // prefab for Buy button
        OfferFieldPF = OfferFieldPF_r;
        canvas = canvas_r;
        inMenu = false;
    }

    void Update()
    {
        if (!HaveInventory)
        {
            HaveInventory = true;
            Inventory.AddItem("Orange", 1, "An Orange");
            Inventory.AddItem("Banana", 1, "A Banana");
        }

        //CreateHero.Hero.GetComponent<Text>().text = CreateHero.Hero.GetComponentInChildren<Hero>().lines[CreateHero.Hero.GetComponentInChildren<Hero>().dialogIndex];//changes heros dialog
    }

	// start the day phase
	public void StartDayPhase(){
		this.GetComponent<DialogDebug> ().day = true;
	}

	// end the day phase
	public void EndDayPhase(){
		this.GetComponent<DialogDebug> ().day = false;
		ClearCanvas ();
	}

    #region Sell to hero
    // opens up the sell inventory
    public static void SellHeroPanel()
    {
        if (!inMenu)
        {
            SellToPanel = Instantiate(SellToPanelPF) as GameObject;
            SellToPanel.transform.SetParent(canvas.transform, false);
            inMenu = true;

            ContentPanel = SellToPanel.GetComponent<PopulateContent>().ObjectPanel;


            int i = 0;
            foreach (Item it in Inventory._Items)
            {
                SellButton = Instantiate(SellButtonPF) as GameObject;//creates button on the dialog panel
                SellButton.transform.SetParent(ContentPanel.transform, false);//sets position

                SellButton.GetComponent<SellButtonObjects>().namelabel.text = it.name;
                SellButton.GetComponent<SellButtonObjects>().quantity.text = it.amount.ToString();
                SellButton.GetComponent<SellButtonObjects>().OfferField.text = it.supplyPrice.ToString();


                i++;
            }
        }
    }

    #endregion



    #region Buy From Hero
    public static void BuyHeroPanel()
    {
        if (!inMenu)
        {
            BuyFromPanel = Instantiate(BuyFromPanelPF) as GameObject;
            BuyFromPanel.transform.SetParent(canvas.transform, false);
            inMenu = true;

            int i = 0;
            foreach (Item it in CreateHero.Hero.GetComponentInChildren<Hero>().H_Inventory)
            {
                BuyButton = Instantiate(BuyButtonPF) as GameObject;//creates button on the dialog panel
                BuyButton.transform.SetParent(BuyFromPanel.transform, false);//parents sets position
                BuyButton.transform.Translate(new Vector3(0, i * -60, 0));//spaces buttons
                BuyButton.GetComponentInChildren<Text>().text = "Buy " + it.name;//sets the text that is inside the button
                BuyButton.GetComponentInChildren<BuyFromHero>().Itemindex = i;

                OfferField = Instantiate(OfferFieldPF) as GameObject;//creates input field on the dialog panel
                OfferField.transform.SetParent(BuyButton.transform, false);//parents and sets position

                IncPriceButton = Instantiate(IncPriceButtonPF) as GameObject;//creates button on the dialog panel
                IncPriceButton.transform.SetParent(OfferField.transform, false);//parents sets position

                DecPriceButton = Instantiate(DecPriceButtonPF) as GameObject;//creates button on the dialog panel
                DecPriceButton.transform.SetParent(OfferField.transform, false);//parents sets position

                i++;

            }
        }
    }

    #endregion


    // close inventory
    public static void CloseBuyFromPanel()
    {
        inMenu = false;
        Destroy(BuyFromPanel);
    }
    public static void CloseSellToPanel()
    {
        inMenu = false;
        Destroy(SellToPanel);
    }

	// clear the canvas
	public void ClearCanvas(){
		foreach (Transform child in canvas.transform) {
			if(child.name != "Background" || child.name != "EventSystem"){
				GameObject.Destroy(child.gameObject);
			}
		}
	}
}
