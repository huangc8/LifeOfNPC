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
	public static GameMaster _GameMaster;		// the game master reference
	public static DataBase _DataBase;			// the database reference
	public static GameObject CraftPanelPf;		// prefab for craft panel
	public static GameObject RecipePanelPf;		// prefab for recipe panel
	public GameObject CraftPanelPf_r;			// none static craft panel
	public GameObject RecipePanelPf_r;			// none static recipe panel
	public GameObject canvas_r;					// none static canvas reference
	#endregion

	// Use this for initialization
	void Awake () {
		_Recipes = new List<Recipe> ();
		CraftPanelPf = CraftPanelPf_r;
		RecipePanelPf = RecipePanelPf_r;
		canvas = canvas_r;
		_GameMaster = this.GetComponent<GameMaster> ();
		_DataBase = this.GetComponent<DataBase> ();
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
			Inventory.AddItem (rt.name, 1, rt.description, rt.type);
			if(rt.type == 1){
				_GameMaster._AudioScript.playMetalCraft();
			}else if (rt.type == 2){
				_GameMaster._AudioScript.playWoodCraft();
			}else if (rt.type == 3){
				_GameMaster._AudioScript.playPotionCraft();
			}
			return rt;
		} else {
			Debug.Log("No such recipe");
			return null;
		}
	}
	#endregion

	#region On Screen Craft

	public static void OpenCraftPanel(){
		if (CraftPanel == null) {
			CraftPanel = Instantiate (CraftPanelPf) as GameObject;
			CraftPanel.GetComponent<CraftPanelScript>().OpenCraftPanel();
			CraftPanel.transform.SetParent (canvas.transform, false);
		}
	}
	
	// close inventory
	public static void CloseCraftPanel(){
		if (CraftPanel != null) {
			Destroy (CraftPanel);
		}
		_GameMaster.OpenNightMenu ();
	}
	#endregion

	#region Recipe
	// Add a Recipe
	public static void AddRecipe(string name, List<string> materials, string description, int type){
		// add a new recipe if don't exist
		if (GetRecipe(name) == null) {
			_Recipes.Add(new Recipe(name, materials, description, type));
		}
	}

	public static void AddRecipe(string name){
		_DataBase.addRecipe (name);
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
	public int type;
	
	// constructor
	public Recipe (string name, List<string> materials, string description, int type){
		this.name = name;
		this.materials = materials;
		this.description = description;
		this.type = type;
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

	// determine color -> 0 - green, 1 - yellow, 2 - red
	public int checkColor(){
		int fulfill = 0;
		for (int i = 0; i < this.materials.Count; i++) {
			string[] ss = this.materials[i].Split(new string[] {" x "}, StringSplitOptions.None);
			int required = int.Parse(ss[1]);
			if(required <= Inventory.getItemAmount(ss[0])){
				fulfill++;
			}
		}
		if (fulfill == this.materials.Count) {
			return 0;
		} else if (fulfill > this.materials.Count / 2) {
			return 1;
		} else {
			return 2;
		}
	}

	// get the material name of given index
	public string getName(int index){
		string[] ss = this.materials[index].Split(new string[] {" x "}, StringSplitOptions.None);
		return ss [0];
	}

	public int getAmount(int index){
		string[] ss = this.materials[index].Split(new string[] {" x "}, StringSplitOptions.None);
		return int.Parse(ss [1]);
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