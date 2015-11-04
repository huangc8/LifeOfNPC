using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CraftPanelScript : MonoBehaviour {

	public Text nameLabel;					// name of product
	public Text materialLabel_1;			// name of material_1
	public Text materialLabel_2;			// name of material_2
	public Text materialLabel_3;			// name of material_3
	public Recipe recipe;					// the recipe
	public GameObject material_1;			// material 1
	public GameObject material_2;			// materail 2
	public GameObject material_3;			// material 3
	public GameObject product;				// the product
	public GameObject inventoryItemPF;		// the inventory item object

	void Start(){
		if (recipe != null) {
			nameLabel.text = recipe.name;
			if(recipe.materials.Count > 2){
				materialLabel_1.text = recipe.materials[0];
				materialLabel_2.text = recipe.materials[1];
				materialLabel_3.text = recipe.materials[2];
			}else{
				materialLabel_1.text = recipe.materials[0];
				materialLabel_2.text = recipe.materials[1];
			}
		}
	}

	// when craft button is clicked
	public void CraftButtonClick(){
		Item item_1 = material_1.GetComponent<MaterialBoxScript> ().GetMaterial();
		Item item_2 = material_2.GetComponent<MaterialBoxScript> ().GetMaterial();
		Item item_3 = material_3.GetComponent<MaterialBoxScript> ().GetMaterial();

		Recipe recipe_p = Craft.CraftItem (item_1, item_2, item_3);

		if (recipe_p != null) {
			// create the product
			GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
			newItem.GetComponent<Item> ().DisplayItem (new Item(recipe_p.name, 1, recipe_p.description));
			newItem.transform.SetParent (product.transform, false);

			// remove the materials
			material_1.GetComponent<MaterialBoxScript> ().DestroyMaterial();
			material_2.GetComponent<MaterialBoxScript> ().DestroyMaterial();
			material_3.GetComponent<MaterialBoxScript> ().DestroyMaterial();
		} else {
			Debug.Log ("don't exist");
		}
	}
}
