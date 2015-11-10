using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Craft : MonoBehaviour {

	#region Data
	public static Craft _Craft;					// reference to the class
	public static List<Recipe> _Recipes;		// current own recipes list
	public static GameObject CraftPanel;		// Craft Panel object
	public static GameObject RecipePanel;		// recipe panel
	public static GameObject canvas;			// the Canvas object

	public static GameObject CraftPanelPf;		// prefab for craft panel
	public static GameObject RecipePanelPf;		// prefab for recipe panel
	public GameObject CraftPanelPf_r;			// none static craft panel
	public GameObject RecipePanelPf_r;			// none static recipe panel
	public GameObject canvas_r;					// none static canvas reference
	#endregion

	// Use this for initialization
	void Start () {
		_Recipes = new List<Recipe> ();
		CraftPanelPf = CraftPanelPf_r;
		RecipePanelPf = RecipePanelPf_r;
		canvas = canvas_r;
	}

	#region Craft
	// Craft an Item
	public static Recipe CraftItem(Item material_1, Item material_2, Item material_3, Recipe rp){

		// make list
		List<string> ltmp = new List<string> ();
		if (material_1 != null) {
			ltmp.Add (material_1.name + " x " + material_1.amount);
		}
		if (material_2 != null) {
			ltmp.Add (material_2.name + " x " + material_2.amount);
		}
		if (material_3 != null) {
			ltmp.Add (material_3.name + " x " + material_3.amount);
		}

		// find the recipe
		Recipe rt = null;
		if (rp != null) {
			if (rp.checkRecipe (ltmp)) {
				rt = rp;
			}
		} else {
			foreach (Recipe r in _Recipes) {
				if (r.checkRecipe (ltmp)) {
					rt = r;
				}
			}
		}

		// craft or return null
		if (rt != null) {
			// remove materials
			if (material_1 != null) {
				Inventory.RemoveItem (material_1.name, material_1.amount);
			}
			if (material_2 != null) {
				Inventory.RemoveItem (material_2.name, material_2.amount);
			}
			if (material_3 != null) {
				Inventory.RemoveItem (material_3.name, material_3.amount);
			}
			// add crafted item
			Inventory.AddItem (rt.name, 1, rt.description);
			return rt;
		} else {
			Debug.Log("No such recipe");
			return null;
		}
	}
	#endregion

	#region On Screen Craft
	public static void OpenRecipePanel(){
		if (RecipePanel == null) {
			RecipePanel = Instantiate (RecipePanelPf) as GameObject;
			RecipePanel.transform.SetParent(canvas.transform, false);
		}
	}

	public static void CloseRecipePanel(){
		if (RecipePanel != null) {
			Destroy (RecipePanel);
		}
	}

	public static void OpenCraftPanel(string name){
		if (CraftPanel == null) {
			Recipe recipe = null;
			if(name != null){
				recipe = GetRecipe(name);
			}
			CraftPanel = Instantiate (CraftPanelPf) as GameObject;
			CraftPanel.GetComponent<CraftPanelScript>().recipe = recipe;
			CraftPanel.transform.SetParent (canvas.transform, false);
		}
	}
	
	// close inventory
	public static void CloseCraftPanel(){
		if (CraftPanel != null) {
			Destroy (CraftPanel);
		}
	}
	#endregion

	#region Recipe
	// Add a Recipe
	public static void AddRecipe(string name, List<string> materials, string description){
		// add a new recipe if don't exist
		if (GetRecipe(name) == null) {
			_Recipes.Add(new Recipe(name, materials, description));
		}
	}

	// Get a Recipe
	public static Recipe GetRecipe(string name){
		// find the recipe and return else return null
		foreach(Recipe re in _Recipes){
			if(re.name == name){
				return re;
			}
		}
		return null;
	}
	#endregion
}

#region RecipeClass
// Recipe Class
public class Recipe : IComparable<Item> {
	public string name;
	public List<string> materials;
	public string description;
	
	// constructor
	public Recipe (string name, List<string> materials, string description){
		this.name = name;
		this.materials = materials;
		this.description = description;
	}

	// check if this is the recipe
	public bool checkRecipe(List<string> given){
		if (given.Count == materials.Count){
			foreach (string g in given) {
				bool check = false;
				foreach (string m in materials) {
					if (g == m) {
						check = true;
					}
				}

				if (!check) {
					return false;
				}
			}
			return true;
		}
		return false;
	}

	// compareTo method
	public int CompareTo(Item other){
		if(other == null){
			return 1;
		}
		if (name == name) {
			return 0;
		} else {
			return 1;
		}
	}
}
#endregion