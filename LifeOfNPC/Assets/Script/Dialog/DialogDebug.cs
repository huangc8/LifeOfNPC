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
            StartDialogScene.NumHeroesToday = UnityEngine.Random.Range(2, 6);
        }



         }
        }
