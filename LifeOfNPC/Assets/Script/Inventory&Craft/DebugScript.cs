using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void Start(){
		// inventory
		Inventory.AddItem ("Consecrated Spring Water", 2, "blah");
		Inventory.AddItem ("Eight-Leaf Clover", 3, "blah");

		#region Recipe
		// Elixir of Minor Rejuvenation
		List<string> ltmp2 = new List<string> ();
		ltmp2.Add ("Consecrated Spring Water x 1");
		ltmp2.Add ("Eight-Leaf Clover x 2");
		Craft.AddRecipe ("Elixir of Minor Rejuvination", ltmp2, "A potion");

		// Elixir of Rejuvenation
		List<string> ltmp3 = new List<string> ();
		ltmp3.Add ("Consecrated Spring Water x 3");
		ltmp3.Add ("Eight-Leaf Clover x 5");
		Craft.AddRecipe ("Elixir of Rejuvenation", ltmp3, "A potion");

		// Elixir of Major Rejuvenation
		List<string> ltmp4 = new List<string> ();
		ltmp4.Add ("Consecrated Spring Water x 5");
		ltmp4.Add ("Eight-Leaf Clover x 8");
		Craft.AddRecipe ("Elixir of Major Rejuvenation", ltmp4, "A potion");

		Supply _sup = this.GetComponent<Supply>();

		_sup.supplyList = new List<Item> ();
		_sup.supplyList.Add (new Item ("Consecrated Spring Water", 0, "blah"));
		_sup.supplyList.Add (new Item ("Eight-Leaf Clover", 0, "blah"));

		#endregion
	}
}
