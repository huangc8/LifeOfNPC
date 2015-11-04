using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RecipeListButtonScript : MonoBehaviour {
	
	public Text NameLabel;
	public Image icon;
	public Text MaterialLabel_1;
	public Text MaterialLabel_2;
	public Text MaterialLabel_3;
	public Button CraftButton;

	// craft button clicked
	public void CraftClick(){
		Craft.CloseRecipePanel ();
		Craft.OpenCraftPanel (NameLabel.text);
	}
}
