using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class Craft : MonoBehaviour {

	public static Craft _Craft;
	public static List<Recipe> _Recipes;
	
	// Use this for initialization
	void Start () {
		_Recipes = new List<Recipe> ();
	}

	// Craft a Item
	public static void CraftItem(Item material_1, Item material_2, Item material_3){

		List<string> ltmp = new List<string> ();
		ltmp.Add (material_1.name);
		ltmp.Add (material_2.name);
		ltmp.Add (material_3.name);

		Recipe rt = null;
		foreach (Recipe r in _Recipes) {
			if(r.checkRecipe(ltmp)){
				rt = r;
			}
		}

		if (rt != null) {
			ActualCraft(rt, material_1, material_2, material_3);
		} else {
			Debug.Log("No such recipe");
		}
	}

	// Remove materials and add item to inventory
	public static void ActualCraft(Recipe recipe, Item material_1, Item material_2, Item material_3){
		// remove materials
		Inventory.RemoveItem (material_1.name, material_1.amount);
		Inventory.RemoveItem (material_2.name, material_2.amount);
		Inventory.RemoveItem (material_3.name, material_3.amount);

		// add crafted item
		Inventory.AddItem (recipe.name, 1, recipe.description);
	}

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
		
		foreach(Recipe re in _Recipes){
			if(re.name == name){
				return re;
			}
		}
		return null;
	}
	#endregion
}

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

		bool found = true;
		foreach (string g in given) {
			bool check = false;
			foreach (string m in materials) {
				if(g == m){
					check = true;
				}
			}

			if(!check){
				found = false;
				break;
			}
		}
		return found;
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