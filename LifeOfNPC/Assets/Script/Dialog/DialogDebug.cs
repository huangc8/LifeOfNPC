using UnityEngine;
using System.Collections;

public class DialogDebug : MonoBehaviour {
	
	public GameObject sellPanel;
	public GameObject sellPanelPf;
	public bool day = false;
    public GameObject hero;

    void OnGUI()
    {
        hero = CreateHero.Hero;

        if(StartDialogScene.NumHeroesToday == 0)
        {
            this.GetComponent<GameMaster>().ChangePhase();
            StartDialogScene.NumHeroesToday = UnityEngine.Random.Range(1, 6);
        }

        if (day)
        {
            /*if (GUI.Button(new Rect(10, 190, 100, 30), "Next Hero") && CreateHero.Hero == null)
            {
                this.GetComponent<CreateHero>().StartCreateHero();
            }*/

                       
                    if (GUI.Button(new Rect(10, 230, 100, 30), "Dismiss Hero"))//dismiss only if there is a hero
                    {
                        this.GetComponent<CreateHero>().DismissHero();
                        StartDialogScene.NumHeroesToday--;//decrease number of heroes in line
                        Debug.Log(StartDialogScene.NumHeroesToday);
                        this.GetComponent<CreateHero>().StartCreateHero();
                    }

                    if (CreateHero.Hero.GetComponent<Hero>().CurrentNode.lvl >= 4)
                    {
                            if (GUI.Button(new Rect(10, 310, 100, 30), "Sell to Hero"))
                            {
                                StartDialogScene.SellHeroPanel();
                            }

                            if (GUI.Button(new Rect(10, 345, 100, 30), "Buy from Hero"))
                            {
                                StartDialogScene.BuyHeroPanel();
                            }

                            if (GUI.Button(new Rect(10, 385, 100, 30), "Back"))
                            {
                                StartDialogScene.CloseBuyFromPanel();
                                StartDialogScene.CloseSellToPanel();
                            }
                        }
                    }
                }
            }
