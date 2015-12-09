using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void Start(){
		#region Item
		// inventory
		Inventory.AddItem ("Consecrated Spring Water", 2);
		Inventory.AddItem ("Eight-Leaf Clover", 3);
		Inventory.AddItem ("Elixir of Minor Rejuvenation", 5, "Blah", 3);
		#endregion

		#region Recipe
		Craft.AddRecipe("Elixir of Minor Rejuvenation");
		Craft.AddRecipe("Elixir of Rejuvenation");
		//Craft.AddRecipe("Elixir of Major Rejuvenation");
		Craft.AddRecipe("Unguent of Minor Invigoration");
		Craft.AddRecipe("Unguent of Invigoration");
		//Craft.AddRecipe("Unguent of Major Invigoration");
		Craft.AddRecipe("Tonic of Minor Restoration");
		Craft.AddRecipe("Tonic of Restoration");
		//Craft.AddRecipe("Tonic of Major Restoration");
		//Craft.AddRecipe("Paralytic Poison");
		//Craft.AddRecipe("Combustive Poison");
		//Craft.AddRecipe("God-Felling Venom");
		//Craft.AddRecipe("Everflowing Panacea");
		//Craft.AddRecipe("Trusty Sword");
		//Craft.AddRecipe("Treebirthed Sword");
		//Craft.AddRecipe("Lakeborn Sword");
		Craft.AddRecipe("Wooden Shield");
		//Craft.AddRecipe("Holy Shield");
		//Craft.AddRecipe("Divine Aegis");
		//Craft.AddRecipe("Emblem of Power");
		//Craft.AddRecipe("Emblem of Endurance");
		//Craft.AddRecipe("Emblem of Acuity");
		//Craft.AddRecipe("Emblem of Vitality");
		//Craft.AddRecipe("Emblem of Superiority");
		//Craft.AddRecipe("Staff of Blasting");
		//Craft.AddRecipe("Staff of Healing");
		//Craft.AddRecipe("Staff of Indomitability");
		//Craft.AddRecipe("Staff of Omnipotence");
		Craft.AddRecipe("Monk's Robes");
		//Craft.AddRecipe("Archmage's Raiment");
		//Craft.AddRecipe("Saint's Shroud");
		//Craft.AddRecipe("Page's Armor");
		//Craft.AddRecipe("Squire's Armor");
		//Craft.AddRecipe("Paladin's Armor");
		//Craft.AddRecipe("Ursinine Armor");
		Craft.AddRecipe("Short Bow");
		Craft.AddRecipe("Cross Bow");
		//Craft.AddRecipe("Elongated Bow");
		//Craft.AddRecipe("Heroic Bow");
		//Craft.AddRecipe("Explosive Bombs");
		//Craft.AddRecipe("Poisonous Arrows");
		//Craft.AddRecipe("Fiery Arrows");
		//Craft.AddRecipe("The Absolute Annihilator of the Ancient Archdeity");
		#endregion
	}
}
