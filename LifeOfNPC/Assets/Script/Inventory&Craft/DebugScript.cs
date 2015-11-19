using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;

public class DebugScript : MonoBehaviour {

	void Start(){
		// inventory
		Inventory.AddItem ("Consecrated Spring Water", 2, "Holy water, " +
			"straight from the priests and nuns of the Holy Church.  " +
			"It's used to bless all sorts of things, from wailing babies " +
			"to whaling lances, and even has a bit of fizz to it from the " +
			"divine blessings. If you ask me, though, normal river water " +
			"would work just as well, and for 100g less.");
		Inventory.AddItem ("Eight-Leaf Clover", 3, "If a four-leaf clover is lucky, " +
			"then an eight-leaf clover is twice as lucky, right?  Then again, you'd " +
			"think that they'd be rare, but there's quite a few of them by the sewage " +
			"channels of the castle town...");

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

		List<string> ltmp5 = new List<string> ();
		ltmp5.Add ("Consecrated Spring Water x 1");
		ltmp5.Add("Azure Slime Jelly x 2");
		Craft.AddRecipe("Unguent of Minor Invigoration", ltmp5, "A potion");

		List<string> ltmp6 = new List<string> ();
		ltmp6.Add ("Consecrated Spring Water x 3");
		ltmp6.Add("Azure Slime Jelly x 4");
		Craft.AddRecipe("Unguent of Invigoration", ltmp6, "A potion");

		List<string> ltmp7 = new List<string>();
		ltmp7.Add ("Consecrated Spring Water x 7");
		ltmp7.Add("Azure Slime Jelly x 7");
		ltmp7.Add("Fermented Yeti Blood x 2");
		Craft.AddRecipe("Unguent of Major Invigoration", ltmp7, "A potion");

		List<string> ltmp8 = new List<string>();
		ltmp8.Add("Crimson Slime Jelly x 2");
		ltmp8.Add("Azure Slime Jelly x 2");
		Craft.AddRecipe("Tonic of Minor Restoration", ltmp8, "A potion");

		List<string> ltmp9 = new List<string>();
		ltmp9.Add("Crimson Slime Jelly x 4");
		ltmp9.Add("Azure Slime Jelly x 4");
		Craft.AddRecipe("Tonic of Restoration", ltmp9, "A potion");

		List<string> ltmp10 = new List<string>();
		ltmp10.Add("Crimson Slime Jelly x 7");
		ltmp10.Add("Azure Slime Jelly x 7");
		ltmp10.Add ("Manticore Quill x 2");
		Craft.AddRecipe("Tonic of Major Restoration", ltmp10, "A potion");

		Supply _sup = this.GetComponent<Supply>();
		_sup.supplyList = new List<Item> ();
		_sup.supplyList.Add (new Item ("Consecrated Spring Water", 0, "Holy water, straight from the priests and nuns of the Holy Church.  It's used to bless all sorts of things, from wailing babies to whaling lances, and even has a bit of fizz to it from the divine blessings. If you ask me, though, normal river water would work just as well, and for 100g less."));
		_sup.supplyList.Add (new Item ("Eight-Leaf Clover", 0, "If a four-leaf clover is lucky, then an eight-leaf clover is twice as lucky, right?  Then again, you'd think that they'd be rare, but there's quite a few of them by the sewage channels of the castle town..."));

		#endregion
	}
}
