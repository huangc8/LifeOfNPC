using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class CraftPanelScript : MonoBehaviour {

	// overall 
	public Image bg;						// the background
	public GameObject experimentButton;		// 

	// recipe section
	public Recipe recipe;					// the recipe
	public Text recipeLabel;				// the recipe label
	public GameObject RecipePanel;			// the recipe panel
	public GameObject contentPanel;			// the content panel
	public GameObject RecipeButtonPf;		// recipe buttons pf
	public GameObject RecipeLabelPf;

	// craft section
	private bool experimental;				// the experimental flag
	public List<GameObject> materials;		// the material boxes
	public List<Text> materialNums;			// the material number label
	public GameObject product;				// the product
	public Button craftButton;				// the craft button
	public GameObject inventoryItemPF;		// the inventory item object

	// product detail section
	public GameObject detailPanel;
	public Image detailIcon;
	public Text detailNameLabel;
	public Text detailDescription;
	public GameObject detailContentPanel; 	// the content panel for materials
	public GameObject detailListButtonPf;	// the list button prefab	

	// experimental section
	public GameObject ExperimentalPanel;
	public GameObject ExperimentalPanelPf;		// the inventoryPanel

	// open the craft panel
	public void OpenCraftPanel(){
		PopulateRecipeButton ();
		detailPanel.SetActive (false);
	}

	// close the craft panel
	public void CloseCraftPanel(){
		Craft.CloseCraftPanel ();
	}

	public void OpenExperimental(){
		RecipePanel.SetActive (false);
		craftButton.interactable = true;
		CleanUpCraftPanel ();
		ExperimentalPanel = Instantiate (ExperimentalPanelPf) as GameObject;
		ExperimentalPanel.transform.SetParent (this.transform, false);
	}

	public void CloseExperimental(){
		RecipePanel.SetActive (true);
		Destroy (ExperimentalPanel);
	}

	// populate the recipe panel
	public void PopulateRecipeButton(){
		int listIndex = 0;
		int recipeIndex = 0;

		GameObject newLabel = Instantiate (RecipeLabelPf) as GameObject;
		newLabel.GetComponentInChildren<Text> ().text = "Potions";
		newLabel.transform.SetParent (contentPanel.transform, false);
		foreach (Recipe re in Craft._Recipes) {
			if(re.type == 3){
			GameObject newButton = Instantiate(RecipeButtonPf) as GameObject;
			RecipeListButtonScript rlbs = newButton.GetComponent<RecipeListButtonScript>();
			rlbs._CraftPanelScript = this;
			rlbs.NameLabel.text = re.name;
			rlbs.listIndex = listIndex;
			rlbs.recipeIndex = recipeIndex;
			rlbs.contentPanel = contentPanel;
			rlbs.UpdateColor();
			newButton.transform.SetParent(contentPanel.transform, false);
			listIndex++;
			}
			recipeIndex++;
		}
		recipeIndex = 0;

		GameObject newLabel2 = Instantiate (RecipeLabelPf) as GameObject;
		newLabel2.GetComponentInChildren<Text> ().text = "Armor";
		newLabel2.transform.SetParent (contentPanel.transform, false);
		foreach (Recipe re in Craft._Recipes) {
			if(re.type == 1){
				GameObject newButton = Instantiate(RecipeButtonPf) as GameObject;
				RecipeListButtonScript rlbs = newButton.GetComponent<RecipeListButtonScript>();
				rlbs._CraftPanelScript = this;
				rlbs.NameLabel.text = re.name;
				rlbs.listIndex = listIndex;
				rlbs.recipeIndex = recipeIndex;
				rlbs.contentPanel = contentPanel;
				rlbs.UpdateColor();
				newButton.transform.SetParent(contentPanel.transform, false);
				listIndex++;
			}
			recipeIndex++;
		}
		recipeIndex = 0;
	
		GameObject newLabel3 = Instantiate (RecipeLabelPf) as GameObject;
		newLabel3.GetComponentInChildren<Text> ().text = "Weapon";
		newLabel3.transform.SetParent (contentPanel.transform, false);
		foreach (Recipe re in Craft._Recipes) {
			if(re.type == 2){
				GameObject newButton = Instantiate(RecipeButtonPf) as GameObject;
				RecipeListButtonScript rlbs = newButton.GetComponent<RecipeListButtonScript>();
				rlbs._CraftPanelScript = this;
				rlbs.NameLabel.text = re.name;
				rlbs.listIndex = listIndex;
				rlbs.recipeIndex = recipeIndex;
				rlbs.contentPanel = contentPanel;
				rlbs.UpdateColor();
				newButton.transform.SetParent(contentPanel.transform, false);
				listIndex++;
			}
			recipeIndex++;
		}
	}

	public void ResetExperimental(){
		CleanUpCraftPanel ();
		Destroy (ExperimentalPanel);
		ExperimentalPanel = Instantiate (ExperimentalPanelPf) as GameObject;
		ExperimentalPanel.transform.SetParent (this.transform, false);
	}

	public void ExperimentalButtonClick(){
		if (ExperimentalPanel != null) {
			CloseExperimental();
			CleanUpCraftPanel();
			experimental = false;
			bg.sprite = Resources.Load<Sprite>("Sprite/uiCraftingPanel");
			experimentButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/uiButtonExperiment");
		} else {
			CloseAllRecipePanel();
			OpenExperimental();
			experimental = true;
			bg.sprite = Resources.Load<Sprite>("Sprite/uiExperimentationPanel");
			experimentButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprite/uiButtonExperimentActive");
		}
	}

	// put materials into boxes
	public void SetUpCraftPanel(int index){
		recipe = Craft._Recipes [index];
		for (int i = 0; i < materials.Count; i++) {
			if(i < recipe.materials.Count){
				GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
				Item it = new Item(recipe.getName(i), recipe.getAmount(i), recipe.description);
				newItem.GetComponent<Item> ().DisplayItem(it);
				newItem.GetComponent<Item> ().GetComponentInChildren<Text> ().enabled = false;
				newItem.GetComponent<ClickandDrag> ().enabled = false;
				materials[i].GetComponent<MaterialBoxScript>().material = newItem.GetComponent<Item>();
				newItem.transform.SetParent (materials[i].transform, false);
				UpdateText();
			}else{
				materialNums[i].text = "??/??";
			}
		}
		GameObject resultItem = Instantiate (inventoryItemPF) as GameObject;
		resultItem.GetComponent<Item> ().DisplayItem (new Item (recipe.name, 1, recipe.description));
		resultItem.GetComponent<Item> ().GetComponentInChildren<Text> ().enabled = false;
		resultItem.GetComponent<ClickandDrag> ().enabled = false;
		resultItem.transform.SetParent (product.transform, false);
	}

	// put the information into detail panel
	public void SetUpDetailPanel(int index){
		recipe = Craft._Recipes [index];
		detailIcon.sprite = Resources.Load<Sprite>("Sprite/" + recipe.name);
		detailNameLabel.text = recipe.name;
		detailDescription.text = recipe.description;
		detailPanel.SetActive (true);
		for (int i = 0; i < recipe.materials.Count; i++) {
			GameObject newButton = Instantiate(detailListButtonPf) as GameObject;
			string name = recipe.getName(i);
			int amount = recipe.getAmount(i);
			newButton.GetComponentInChildren<Text>().text = name + " (" + amount.ToString() + ")";
			newButton.GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("Sprite/" + name);
			newButton.transform.SetParent(detailContentPanel.transform, false);
			newButton.GetComponent<Button> ().interactable = false;
		}
	}
	
	// close the detail panel
	public void CloseDetailPanel(){
		detailPanel.SetActive (false);
		var children = new List<GameObject>();
		foreach (Transform child in detailContentPanel.transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
	}

	public void CloseAllRecipePanel(){
		foreach (Transform child in contentPanel.transform) {
			if(child.GetComponent<RecipeListButtonScript>() != null){
				child.GetComponent<RecipeListButtonScript>().ClosePanel();
			}
		}
	}

	// update color code
	public void UpdateText(){
		int enough = 0;
		for (int i = 0; i < materials.Count; i++) {
			if(i < recipe.materials.Count){
				int got = Inventory.getItemAmount (recipe.getName (i));
				int required = recipe.getAmount (i);
				materialNums [i].text = got + "/" + required;
				if(got >= required){
					materialNums[i].color = HexToColor("608247");
					enough++;
				}else if (got >= required / 2){
					materialNums[i].color = HexToColor("dcdd6d");
				}else{
					materialNums[i].color = HexToColor("824747");
				}
			}else{
				materialNums[i].text = "??/??";
				materialNums[i].color = HexToColor("362F2DFF");
			}
		}
		if (enough == recipe.materials.Count) {
			craftButton.interactable = true;
		} else {
			craftButton.interactable = false;
		}

		foreach (Transform child in contentPanel.transform) {
			if(child.GetComponent<RecipeListButtonScript>() != null){
				child.GetComponent<RecipeListButtonScript>().UpdateColor();
			}
		}
	}

	// clean the panel
	public void CleanUpCraftPanel(){
		for(int i = 0; i < materials.Count; i++){
			materials[i].GetComponent<MaterialBoxScript>().DestroyMaterial();
			materialNums[i].text = "??/??";
			materialNums[i].color = HexToColor("362F2DFF");
		}
		if (product.transform.childCount > 0) {
			GameObject.Destroy (product.transform.GetChild (0).gameObject);
		}
	}

	// when craft button is clicked
	public void CraftButtonClick(){
		List<Item> items = new List<Item> ();

		for (int i = 0; i < materials.Count; i++) {
			if(materials[i].GetComponent<MaterialBoxScript>().GetMaterial() != null){
				Item it = materials[i].GetComponent<MaterialBoxScript>().GetMaterial();
				if(it != null){
					items.Add(it);
				}
			}
		}

		if (items.Count > 0) {
			if(experimental){
				// merge same material
				for(int i = 0; i < items.Count; i++){
					for(int j = 1; j < items.Count; j++){
						if(items[j] != null && items[i] != null && i != j){
							if(items[i].name == items[j].name){
								items[i].AddMore(items[j].amount);
								items[j].amount = 0;
							}
						}
					}
				}
			}

			while(items.Count < 3){
				items.Add(null);
			}

			Recipe recipe_p = Craft.CraftItem (items[0], items[1], items[2], recipe);

			if (recipe_p != null) {
				if(experimental){
					// create the product
					GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
					newItem.GetComponent<Item> ().DisplayItem (new Item (recipe_p.name, 1, recipe_p.description));
					newItem.transform.SetParent (product.transform, false);
					for(int i = 0; i < materials.Count; i++){
						materials[i].GetComponent<MaterialBoxScript>().DestroyMaterial();
					}
				}else{
					UpdateText();
				}
			} else {
				for (int i = 0; i < materials.Count; i++) {
					materials[i].GetComponent<MaterialBoxScript>().DestroyMaterial();
				}
				ResetExperimental();
				Debug.Log ("Craft fail");
			}
		}
	}

	Color HexToColor(string hex)
	{
		byte r = byte.Parse(hex.Substring(0,2), System.Globalization.NumberStyles.HexNumber);
		byte g = byte.Parse(hex.Substring(2,2), System.Globalization.NumberStyles.HexNumber);
		byte b = byte.Parse(hex.Substring(4,2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r,g,b, 255);
	}
}
