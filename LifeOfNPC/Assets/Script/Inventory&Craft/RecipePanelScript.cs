using UnityEngine;
using System.Collections;

public class RecipePanelScript : MonoBehaviour {
	public Inventory _Inventory;
	public GameObject contentPanel;
	public GameObject RecipeListButtonPf;

	// start the recipe button
	void Start(){
		PopulateRecipeButton ();
	}

	public void ExperimentButtonClick(){
		Craft.OpenCraftPanel ();
	}

	public void CloseButtonClick(){

	}

	// populate the recipe button
	public void PopulateRecipeButton(){
		foreach (Recipe re in Craft._Recipes) {
			GameObject newButton = Instantiate(RecipeListButtonPf) as GameObject;
			RecipeListButtonScript rlb = newButton.GetComponent<RecipeListButtonScript>();
			rlb.NameLabel.text = re.name;
		}
	}
}
