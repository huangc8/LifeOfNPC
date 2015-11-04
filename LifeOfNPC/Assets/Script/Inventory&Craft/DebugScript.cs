using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void Start(){
		// inventory
		Inventory.AddItem ("Apple", 3, "An Apple");
		Inventory.AddItem ("Orange", 1, "An Orange");
		Inventory.AddItem ("Consecrated Spring Water", 50, "blah");
		Inventory.AddItem ("Eight-Leaf Clover", 50, "blah");

		// recipe
		// Banana
		List<string> ltmp = new List<string> ();
		ltmp.Add("Apple x 2");
		ltmp.Add("Apple x 1");
		ltmp.Add("Orange x 1");
		Craft.AddRecipe("Banana", ltmp, "A Banana");

		// Elixir of Minor Rejuvenation
		List<string> ltmp2 = new List<string> ();
		ltmp2.Add ("Consecrated Spring Water x 1");
		ltmp2.Add ("Eight-Leaf Clover x 2");
		ltmp2.Add ("Eight-Leaf Clover x 3");
		Craft.AddRecipe ("Elixir of Minor Rejuvination", ltmp2, "A potion");

		// Elixir of Rejuvenation
		List<string> ltmp3 = new List<string> ();
		ltmp3.Add ("Consecrated Spring Water x 3");
		ltmp3.Add ("Eight-Leaf Clover x 5");
		ltmp2.Add ("Eight-Leaf Clover x 3");
		Craft.AddRecipe ("Elixir of Rejuvenation", ltmp3, "A potion");

		// Elixir of Major Rejuvenation
		List<string> ltmp4 = new List<string> ();
		ltmp4.Add ("Consecrated Spring Water x 5");
		ltmp4.Add ("Eight-Leaf Clover x 8");
		ltmp2.Add ("Eight-Leaf Clover x 3");
		Craft.AddRecipe ("Elixir of Major Rejuvenation", ltmp4, "A potion");
	}
}
