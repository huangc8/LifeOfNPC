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

	// populate the recipe button
	public void PopulateRecipeButton(){
		foreach (Recipe re in Craft._Recipes) {
			GameObject newButton = Instantiate(RecipeListButtonPf) as GameObject;
			RecipeListButtonScript rlb = newButton.GetComponent<RecipeListButtonScript>();
			rlb.NameLabel.text = re.name;
			if(re.materials.Count == 1){
				rlb.MaterialLabel_1.text = re.materials[0];
				rlb.MaterialLabel_2.text = "";
				rlb.MaterialLabel_3.text = "";
			} else if(re.materials.Count == 2){
				rlb.MaterialLabel_1.text = re.materials[0];
				rlb.MaterialLabel_2.text = re.materials[1];
				rlb.MaterialLabel_3.text = "";
			} else if(re.materials.Count == 3){
				rlb.MaterialLabel_1.text = re.materials[0];
				rlb.MaterialLabel_2.text = re.materials[1];
				rlb.MaterialLabel_3.text = re.materials[2];
			}
			rlb.icon.sprite = Resources.Load<Sprite>("Sprite/" + re.name);
			newButton.transform.SetParent(contentPanel.transform, false);
		}
	}
}
