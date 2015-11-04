using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void Start(){
		Inventory.AddItem ("Apple", 3, "An Apple");
		Inventory.AddItem ("Orange", 1, "An Orange");

		List<string> ltmp = new List<string> ();
		ltmp.Add("Apple");
		ltmp.Add("Apple");
		ltmp.Add("Orange");
		
		Craft.AddRecipe("Banana", ltmp, "A Banana");


		List<string> ltmp2 = new List<string> ();

	}
}
