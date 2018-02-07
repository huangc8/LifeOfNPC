using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using UnityEngine.UI;

public class StartDialogScene : MonoBehaviour
{

	public static Hero CurrentHero;
	public static bool inMenu;
	public static int timer;
	public static int knockTimer;
	public static int NumHeroesToday;
	public static List<Hero> SpecialHeroes;

	public static GameObject BuyFromPanel;
	public static GameObject SellToPanel;
	public static GameObject ContentPanel;
	public static GameObject BuyButton;
	public static GameObject SellButton;
	public static GameObject IncPriceButton;
	// prefab for Buy button
	public static GameObject DecPriceButton;
	// prefab for Buy button
	public static GameObject OfferField;
	public static GameObject canvas;
	// the Canvas object

	// Prefabs

	public static GameObject BuyFromPanelPF;
	// prefab for Dialog panel
	public static GameObject SellToPanelPF;
	// prefab for Dialog panel
	public static GameObject ContentPanelPF;
	public static GameObject BuyButtonPF;
	// prefab for Buy button
	public static GameObject SellButtonPF;
	// prefab for Buy button
	public static GameObject IncPriceButtonPF;
	// prefab for Buy button
	public static GameObject DecPriceButtonPF;
	// prefab for Buy button
	public static GameObject OfferFieldPF;
	// prefab for offer field


	public GameObject BuyFromPanelPf_r;
	// non static Dialog panel
	public GameObject SellToPanelPf_r;
	// non static Dialog panel
	public GameObject ContentPanelPf_r;
	public GameObject BuyButtonPf_r;
	// non static button
	public GameObject SellButtonPf_r;
	// non static button
	public GameObject IncPriceButtonPF_r;
	// prefab for Buy button
	public GameObject DecPriceButtonPF_r;
	// prefab for Buy button
	public GameObject OfferFieldPF_r;
	// non static field
	public GameObject canvas_r;
	// non static canvas reference

	public bool HaveInventory = false;
	public static List<string> NoSale;
	public bool SpecialHeroServed = false;
	public bool HeroKnocked = false;
	public bool Day = false;
	public bool Tutorial = false;

	public AudioSource knockSound;

	// Use this for initialization
	void Start ()
	{
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
		NoSale = new List<string> ();
		timer = 1;
		knockTimer = 1;
		SpecialHeroes = new List<Hero> ();
	}

	// read dialog
	void Update ()
	{
		if (Day) {
			if (StartDialogScene.NumHeroesToday > 0) {
				if (HeroKnocked == true) {
					if (CreateHero.Hero != null && CreateHero.Hero.GetComponent<Hero> ().CurrentNode != null) {
						// switch between
						Hero hero = CreateHero.Hero.GetComponent<Hero>();
						if (hero.CurrentNode.stop == 0 && timer % 180 == 0) {
							// move to next node
							hero.NextDialog ();
							timer = 1;
						} else if (timer % 180 != 0) {
							timer++;
						} else if (!Tutorial) {
							Tutorial = true;
							HeroKnocked = CreateHero.DismissHero (HeroKnocked);
							this.GetComponent<CreateHero> ().CreateKnock ();
						}
							
						// turn on and off the button interaction
						if (hero.CurrentNode.stop == 1 && !hero.buttonInteractable && hero.name != "Tutorial") {
							hero.ButtonInteraction (true);
							hero.buttonInteractable = true;
						} else if (hero.CurrentNode.stop == 0 && hero.buttonInteractable){
							hero.ButtonInteraction (false);
							hero.buttonInteractable = false;
						}
					}
				} else {
					if (knockTimer % 100 == 0) {
						HeroKnocked = CreateHero.DismissHero (HeroKnocked);
						knockTimer = 1;
						timer = 1;
						this.GetComponent<CreateHero> ().StartCreateHero ();
					} else {
						knockTimer++;
					}
				}
			} else {
				this.GetComponent<GameMaster> ().ChangePhase ();
			}
		}
	}
	

	// start the day phase
	public void StartDayPhase ()
	{
		Day = true;
		StartDialogScene.NumHeroesToday = UnityEngine.Random.Range (2, 6);
		this.GetComponent<CreateHero> ().CreateKnock ();
	}

	// end the day phase
	public void EndDayPhase ()
	{
		Day = false;
		CreateHero.DismissHero (HeroKnocked);
		HeroKnocked = false;
		SpecialHeroServed = false;
	}

	#region Sell to hero

	// opens up the sell inventory
	public static void SellHeroPanel ()
	{
		if (!inMenu) {
			SellToPanel = Instantiate (SellToPanelPF) as GameObject;
			SellToPanel.transform.SetParent (canvas.transform, false);
			inMenu = true;
		}
	}

	#endregion

	#region Buy From Hero

	public static void BuyHeroPanel ()
	{
		if (!inMenu) {
			BuyFromPanel = Instantiate (BuyFromPanelPF) as GameObject;
			BuyFromPanel.transform.SetParent (canvas.transform, false);
			inMenu = true;
		}
	}

	#endregion


	// close inventory
	public static void CloseBuyFromPanel ()
	{
		inMenu = false;
		Destroy (BuyFromPanel);
	}

	public static void CloseSellToPanel ()
	{
		inMenu = false;
		Destroy (SellToPanel);
	}
}
