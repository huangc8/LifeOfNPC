using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
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
			if(recipe.materials.Count == 1){
				materialLabel_1.text = recipe.materials[0];
				materialLabel_2.text = "";
				materialLabel_3.text = "";
			}else if(recipe.materials.Count == 2){
				materialLabel_1.text = recipe.materials[0];
				materialLabel_2.text = recipe.materials[1];
				materialLabel_3.text = "";
			}else if (recipe.materials.Count == 3){
				materialLabel_1.text = recipe.materials[0];
				materialLabel_2.text = recipe.materials[1];
				materialLabel_3.text = recipe.materials[2];
			}
		}
	}

	// when craft button is clicked
	public void CraftButtonClick(){
		List<Item> items = new List<Item> ();

		if (material_1.GetComponent<MaterialBoxScript> ().GetMaterial () != null) {
			items.Add (material_1.GetComponent<MaterialBoxScript> ().GetMaterial ());
		}
		if (material_2.GetComponent<MaterialBoxScript> ().GetMaterial () != null) {
			items.Add(material_2.GetComponent<MaterialBoxScript> ().GetMaterial ());
		}
		if (material_3.GetComponent<MaterialBoxScript> ().GetMaterial () != null) {
			items.Add(material_3.GetComponent<MaterialBoxScript> ().GetMaterial ());
		}

		if (items.Count > 0) {

			// merge same material
			for(int i = 0; i < items.Count; i++){
				for(int j = 1; j < items.Count; j++){
					if(items[j] != null){
						if(items[i].name == items[j].name){
							items[i].AddMore(items[j].amount);
							items[j] = null;
						}
					}
				}
			}

			List<Item> its = new List<Item>();
			for(int i = 0; i < items.Count; i++){
				if(items[i] != null){
					its.Add(items[i]);
				}
			}

			while(its.Count < 3){
				its.Add(null);
			}

			Recipe recipe_p = Craft.CraftItem (its[0], its[1], its[2]);

			if (recipe_p != null) {
				// create the product
				GameObject newItem = Instantiate (inventoryItemPF) as GameObject;
				newItem.GetComponent<Item> ().DisplayItem (new Item (recipe_p.name, 1, recipe_p.description));
				newItem.transform.SetParent (product.transform, false);

				// remove the materials
				material_1.GetComponent<MaterialBoxScript> ().DestroyMaterial ();
				material_2.GetComponent<MaterialBoxScript> ().DestroyMaterial ();
				material_3.GetComponent<MaterialBoxScript> ().DestroyMaterial ();
			} else {
				Debug.Log ("don't exist");
			}
		}
	}
}
