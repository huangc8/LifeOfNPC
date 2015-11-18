using UnityEngine;
using System.Collections;

public class DialogDebug : MonoBehaviour {
	
	public GameObject sellPanel;
	public GameObject sellPanelPf;
	public bool day = false;

    void OnGUI()
    {
<<<<<<< HEAD
		if (GUI.Button (new Rect (10, 190, 100, 30), "Sell Panel")) {
			sellPanel = Instantiate(sellPanelPf) as GameObject;
			sellPanel.transform.SetParent(this.GetComponent<GameMaster>().canvas.transform, false);
		}

		if (GUI.Button (new Rect (10, 230, 100, 30), "Next Phase")) {
=======
		if (GUI.Button (new Rect (10, 180, 100, 30), "Next Phase")) {
>>>>>>> c47c7a33b6465394d4f2a864644a5b30b06f83ed
			this.GetComponent<GameMaster>().ChangePhase();
		}

		if (day) {
            if (GUI.Button(new Rect(10, 200, 100, 30), "Next Hero"))
            {
                this.GetComponent<CreateHero>().StartCreateHero();
            }

            if (GUI.Button(new Rect(10, 230, 100, 30), "Dismiss Hero"))
            {
                this.GetComponent<CreateHero>().DismissHero();
            }
            if (GUI.Button (new Rect (10, 270, 100, 30), "Next Dialog")) {
                CreateHero.Hero.GetComponent<Hero>().CurrentNode = CreateHero.Hero.GetComponent<Hero>().lines[DialogTree.Traverse(CreateHero.Hero.GetComponent<Hero>().CurrentNode, false)];
            }
			if (CreateHero.Hero.GetComponent<Hero>().CurrentNode.next >= 4) { 
				if (GUI.Button (new Rect (10, 310, 100, 30), "Sell to Hero")) {
					StartDialogScene.SellHeroPanel ();
				}

				if (GUI.Button (new Rect (10, 345, 100, 30), "Buy from Hero")) {
					StartDialogScene.BuyHeroPanel ();
				}

				if (GUI.Button (new Rect (10, 385, 100, 30), "Back")) {
					StartDialogScene.CloseBuyFromPanel ();
					StartDialogScene.CloseSellToPanel ();
				}
			}
		}
    }
}

