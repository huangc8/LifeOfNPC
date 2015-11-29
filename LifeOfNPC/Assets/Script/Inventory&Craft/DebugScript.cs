using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void Start(){
		// inventory
		Inventory.AddItem ("Consecrated Spring Water", 2);
		Inventory.AddItem ("Eight-Leaf Clover", 3);

		#region Recipe

		Craft.AddRecipe("Elixir of Minor Rejuvenation");

		#endregion
	}
}
