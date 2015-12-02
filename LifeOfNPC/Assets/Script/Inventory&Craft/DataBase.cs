using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DataBase : MonoBehaviour {
	
	public Supply _Supply;

	void Start(){
		_Supply = this.GetComponent<Supply> ();
	}

	public void addRecipe(string name){
		List<string> ltmp = new List<string> ();
		int type = 0; // material - 0, armor - 1, weapon - 2, potion - 3 
		switch (name) {
		case "Elixir of Minor Rejuvenation":
			ltmp.Add("Consecrated Spring Water x 1");
			ltmp.Add("Eight-Leaf Clover x 2");
			type = 3;
			break;
		case "Elixir of Rejuvenation":
			ltmp.Add("Consecrated Spring Water x 3");
			ltmp.Add("Eight-Leaf Clover x 5");
			type = 3;
			break;
		case "Elixir of Major Rejuvenation":
			ltmp.Add("Consecrated Spring Water x 5");
			ltmp.Add("Eight-Leaf Clover x 8");
			ltmp.Add("Powdered Fairy Wing x 2");
			type = 3;
			break;
		case "Unguent of Minor Invigoration":
			ltmp.Add("Consecrated Spring Water x 1");
			ltmp.Add("Azure Slime Jelly x 2");
			type = 3;
			break;
		case "Unguent of Invigoration":
			ltmp.Add("Consecrated Spring Water x 3");
			ltmp.Add("Azure Slime Jelly x 4");
			type = 3;
			break;
		case "Unguent of Major Invigoration":
			ltmp.Add("Consecrated Spring Water x 7");
			ltmp.Add("Azure Slime Jelly x 7");
			type = 3;
			break;
		case "Tonic of Minor Restoration":
			ltmp.Add("Crimson Slime Jelly x 2");
			ltmp.Add("Azure Slime Jelly x 2");
			type = 3;
			break;
		case "Tonic of Restoration":
			ltmp.Add("Crimson Slime Jelly x 4");
			ltmp.Add("Azure Slime Jelly x 4");
			type = 3;
			break;
		case "Tonic of Major Restoration":
			ltmp.Add("Crimson Slime Jelly x 7");
			ltmp.Add("Azure Slime Jelly x 7");
			type = 3;
			break;
		case "Paralytic Poison":
			ltmp.Add("Ectoplasmic Ooze x 2");
			ltmp.Add("Azure Slime Jelly x 3");
			type = 3;
			break;
		case "Combustive Poison":
			ltmp.Add("Ectoplasmic Ooze x 2");
			ltmp.Add("Crimson Slime Jelly x 3");
			type = 3;
			break;
		case "God-Felling Venom":
			ltmp.Add("Manticore Quill x 3");
			ltmp.Add("Fermented Yeti Blood x 4");
			ltmp.Add("Golden Slime Jelly x 1");
			type = 3;
			break;
		case "Everflowing Panacea":
			ltmp.Add("Consecrated Spring Water x 4");
			ltmp.Add("Crimson Slime Jelly x 2");
			ltmp.Add("Azure Slime Jelly x 2");
			type = 3;
			break;
		case "Trusty Sword":
			ltmp.Add("Consecrated Spring Water x 1");
			ltmp.Add("Sacred Yew Sapling x 1");
			ltmp.Add("Meteoric Iron x 2");
			type = 2;
			break;
		case "Treebirthed Sword":
			ltmp.Add("Luminescent Scale x 1");
			ltmp.Add("Sacred Yew Sapling x 2");
			ltmp.Add("Meteoric Iron x 4");
			type = 2;
			break;
		case "Lakeborn Sword":
			ltmp.Add("Luminescent Scale x 3");
			ltmp.Add("Minotaur's Horn x 3");
			ltmp.Add("Mythreal Ore x 2");
			type = 2;
			break;
		case "Wooden Shield":
			ltmp.Add("Consecrated Spring Water x 1");
			ltmp.Add ("Sacred Yew Sapling x 3");
			ltmp.Add("Arachne Gossamer x 2");
			type = 1;
			break;
		case "Holy Shield":
			ltmp.Add("Consecrated Spring Water x 3");
			ltmp.Add("Werewolf Hide x 2");
			ltmp.Add("Meteoric Iron x 2");
			type = 1;
			break;
		case "Divine Aegis":
			ltmp.Add("Cerberus Fang x 3");
			ltmp.Add("Meteoric Iron x 4");
			ltmp.Add("Mythreal Ore  x 2");
			type = 1;
			break;
		case "Emblem of Power":
			ltmp.Add("Albino Goblin's Eye x 2");
			ltmp.Add("Sacred Yew Sapling x 3");
			ltmp.Add("Crimson Slime Jelly x 1");
			type = 1;
			break;
		case "Emblem of Endurance":
			ltmp.Add("Albino Goblin's Eye x 2");
			ltmp.Add("Sacred Yew Sapling x 3");
			ltmp.Add("Azure Slime Jelly x 1");
			type = 1;
			break;
		case "Emblem of Acuity":
			ltmp.Add("Albino Goblin's Eye x 2");
			ltmp.Add("Meteoric Iron x 2");
			ltmp.Add("Azure Slime Jelly x 1");
			type = 1;
			break;
		case "Emblem of Vitality":
			ltmp.Add("Albino Goblin's Eye x 2");
			ltmp.Add("Meteoric Iron x 2");
			ltmp.Add("Crimson Slime Jelly x 1");
			type = 1;
			break;
		case "Emblem of Superiority":
			ltmp.Add("Albino Goblin's Eye x 3");
			ltmp.Add("Meteoric Iron x 4");
			ltmp.Add("Ancient Phylactery x 1");
			type = 1;
			break;
		case "Staff of Blasting":
			ltmp.Add("Sacred Yew Sapling x 2");
			ltmp.Add("Crimson Slime Jelly x 4");
			ltmp.Add("Albino Goblin's Eye x 2");
			type = 2;
			break;
		case "Staff of Healing":
			ltmp.Add("Sacred Yew Sapling x 2");
			ltmp.Add("Consecrated Spring Water x 3");
			ltmp.Add("Luminescent Scale x 3");
			type = 2;
			break;
		case "Staff of Indomitability":
			ltmp.Add("Sacred Yew Sapling x 2");
			ltmp.Add("Cerberus Fang x 3");
			ltmp.Add("Luminescent Scale x 3");
			type = 2;
			break;
		case "Staff of Omnipotence":
			ltmp.Add("Sacred Yew Sapling x 5");
			ltmp.Add("Golden Slime Jelly x 1");
			ltmp.Add("Elder Dragon's Heart x 1");
			type = 1;
			break;
		case "Monk's Robes":
			ltmp.Add("Arachne Gossamer x 3");
			ltmp.Add("Azure Slime Jelly x 1");
			type = 1;
			break;
		case "Archmage's Raiment":
			ltmp.Add("Arachne Gossamer x 5");
			ltmp.Add("Crimson Slime Jelly x 3");
			ltmp.Add("Werewolf Hide x 2");
			type = 1;
			break;
		case "Saint's Shroud":
			ltmp.Add("Arachne Gossamer x 7");
			ltmp.Add("Luminescent Scale x 5");
			ltmp.Add("Golden Slime Jelly x 1");
			type = 1;
			break;
		case "Page's Armor":
			ltmp.Add("Dire Bear Derriere x 4");
			ltmp.Add("Meteoric Iron x 2");
			type = 1;
			break;
		case "Squire's Armor":
			ltmp.Add("Dire Bear Derriere x 6");
			ltmp.Add("Meteoric Iron x 3");
			type = 1;
			break;
		case "Paladin's Armor":
			ltmp.Add("Meteoric Iron x 6");
			ltmp.Add("Luminescent Scale x 6");
			ltmp.Add("Mythreal Ore x 1");
			type = 1;
			break;
		case "Ursinine Armor":
			ltmp.Add("Dire Bear Derriere x 20");
			type = 1;
			break;
		case "Short Bow":
			ltmp.Add("Sacred Yew Sapling x 3");
			ltmp.Add("Arachne Gossamer x 2");
			type = 2;
			break;
		case "Cross Bow":
			ltmp.Add("Sacred Yew Sapling x 4");
			ltmp.Add("Meteoric Iron x 2");
			ltmp.Add("Consecrated Spring Water x 5");
			type = 2;
			break;
		case "Elongated Bow":
			ltmp.Add("Sacred Yew Sapling x 5");
			ltmp.Add("Arachne Gossamer x 3");
			ltmp.Add("Minotaur's Horn x 3");
			type = 2;
			break;
		case "Heroic Bow":
			ltmp.Add("Sacred Yew Sapling x 6");
			ltmp.Add("Arachne Gossamer x 4");
			ltmp.Add("Golden Slime Jelly x 3");
			type = 2;
			break;
		case "Explosive Bombs":
			ltmp.Add("Salamander Oil x 3");
			ltmp.Add("Crimson Slime Jelly x 3");
			ltmp.Add("Kobold Tears x 1");
			type = 2;
			break;
		case "Poisonous Arrows":
			ltmp.Add("Sacred Yew Sapling x 2");
			ltmp.Add("Ectoplasmic Ooze x 3");
			ltmp.Add("Manticore Quill x 4");
			type = 2;
			break;
		case "Fiery Arrows":
			ltmp.Add("Sacred Yew Sapling x 3");
			ltmp.Add("Salamander Oil x 2");
			ltmp.Add("Crimson Slime Jelly x 2");
			type = 2;
			break;
		case "The Absolute Annihilator of the Ancient Archdeity":
			ltmp.Add("Elder Dragon's Heart x 3");
			ltmp.Add("Ancient Phylactery x 3");
			ltmp.Add("Mythreal Ore x 3");
			type = 3;
			break;
		}
		Craft.AddRecipe (name, ltmp, getDescription(name), type);
	}

	public string getDescription(string name){
		switch(name){
		case "Salamander Oil":
			return "This is something you definitely don't want " +
				"to mix up with anything else.  I knew a man who used Salamander " +
					"Oil instead of olive oil during his cooking once; suffice " +
					"it to say that his taste buds didn't survive the experience - " +
					"or his tongue, for that matter.  Salamander Oil comes straight " +
					"from those vermin in your fireplace, and they're nothing better " +
					"when you want something to burn.  It has medicinal uses as well, " +
					"but be careful with it, lest you be the one feeling the heat...";
			break;
		case "Cerberus Fang":
			return "Have you ever tried cleaning a Cerberus's teeth?  " +
				"Your brush - and head, arms, clothing, and other valuables - " +
					"had better be resilient, because the stench of a Cerberus's " +
					"breath alone is lethal, let alone the poison.  Still, if you " +
					"manage to get a spare tooth of it, count yourself lucky.  " +
					"They're fairly durable, so they're useful for making something sturdy."; 
			break;
		case "Eight-Leaf Clover":
			return "If a four-leaf clover is lucky, then an eight-leaf clover " +
				"is twice as lucky, right?  Then again, you'd think that they'd be rare, " +
					"but there's quite a few of them by the sewage channels of the castle town...";
			break;
		case "Powdered Fairy Wing":
			return "Fairies, fairies, fairies... accursed little brats.  Always fluttering " +
				"about, scattering dust everywhere, reminding you of appointments only after they've " +
					"passed and pointing out things you already knew about.  The only thing they're good " +
					"for is reviving an Adventurer on the verge of death.";
			break;
		case "Werewolf Hide":
			return "Werewolves... pathetic creatures, really.  Go mad at the mere sight of the " +
				"moon, slaughtering everyone around them whether friend, family, or foe, constantly on " +
					"the lookout for thrown sticks or fresh bones... I'd hate to be a werewolf.  Luckily, " +
					"they're not human anymore, so we can skin them all we want!  Their hide is quite " +
					"resilient, so great for protection - as long as you get the fleas out of it.";
			break;
		case "Consecrated Spring Water":
			return "Holy water, straight from the priests and nuns of the Holy Church.  It's " +
				"used to bless all sorts of things, from wailing babies to whaling lances, " +
					"and even has a bit of fizz to it from the divine blessings. If you ask me, " +
					"though, normal river water would work just as well, and for 100g less.";
			break;
		case "Fermented Yeti Blood":
			return "I'm not sure who was desperate enough - more likely crazy enough - to " +
				"drink a yeti's blood, much less fermented blood, but they were a genius!  It has " +
					"incredibly potent medicinal properties, and it even tastes like cherries if you've " +
					"prepared it right!  However, yeti blood is a fickle and dangerous thing, capable of " +
					"burning holes clean through your throat.  If it tastes like grape... that's the " +
					"end for you.";
			break;
		case "Sacred Yew Sapling":
			return "The yew tree - a sacred tree to druids, who view it as a powerful being " +
				"of purification and association with the afterlife.  But more, importantly, it's " +
					"sturdy, yet flexible, making it perfect for both bows and swords!  They're very " +
					"useful for quite a few items, so shopkeepers need quite a few of them.  As to " +
					"where we get them... well, the druids have such a large forest, so I'm sure " +
					"they can spare a few... or many.";
			break;
		case "Luminescent Scale":
			return "Beautiful, isn't it?  It shines like the rainbow, and it's " +
				"useful for all sorts of things: clothes, weapons, the list goes on.  " +
					"Legend has it that there were once fish as clear as glass that " +
					"leaped into rainbows and dyed themself in its light.  And that legend " +
					"is true!  Well, if by \"rainbow\", you mean \"runoff from the castle town upstream\".";
			break;
		case "Meteoric Iron":
			return "The stars hold incredible power, and this material is no different.  " +
				"Meteoric Iron - retrieved directly from a fallen star - and more resilient than " +
					"nearly any metal of this earth.  As for the shape, well... maybe a god burned " +
					"their hand while doing the laundry?";
			break;
		case "Kobold Tears":
			return "Have you ever tried to squeeze water from a rock, or milk a dragon? " +
				"I'll tell you right now - both of those are easier than getting a Kobold to cry. " +
					"As common as the vermin are, it's extremely rare to see a kobold cry. " +
					"People have tried everything - onions, tragedies, roc feathers to the armpit - " +
					"but nothing worked.  Eventually people just gave up and cut the tear ducts clean " +
					"out of them.";
			break;
		case "Elder Dragon's Heart":
			return "The Dragon - the mightiest of all creatures.  Ancient, powerful, deadly, " +
				"and well-versed in magic as well; slaying one would be quite a feat.  However, " +
					"their hearts contain immense wellsprings of magical energy, making them well-suited " +
					"for magical armaments such as staffs.  To tell the truth, pretty much any part of " +
					"their body would do, but Elder Dragon's Heart has such a better ring to it than " +
					"Elder Dragon's Liver or Elder Dragon's Duodenum.";
			break;
		case "Albino Goblin's Eye":
			return "For something as unassuming as a goblin, you'd be amazed how many uses " +
				"you can get out of one.  The skin makes good leather, the bones excellent dice, " +
					"the sinews fine nets; even the dung has a use. Long ago, the ancients were able " +
					"to use every single piece of a goblin - even the gallbladder! The eyes, however, " +
					"make for adequate foci of mana.  They don't have to be albino, but the red really " +
					"adds a nice shine, don't you think?";
			break;
		case "Minotaur's Horn":
			return "Sure, Minotaur Steaks are delicious, but it's the horns that are really " +
				"useful.  You can forge them into weapons or melt them down entirely to reinforce a " +
					"material.  You can't eat them, though - don't even try.";
			break;
		case "Ectoplasmic Ooze":
			return "Undeath is a messy, messy thing.  Skeletons shatter the moment they stumble, " +
				"vampires explode the moment they die, getting ash everywhere.  But ghosts?  Ghosts are " +
					"the worst.  They spew ooze everywhere; it drips off them as they float, gets all over " +
					"you if you fight one, and gods help you if you get possessed.  At least the lifeforce " +
					"in the ooze is useful for medicinal purposes, and more importantly, for texture.";
			break;
		case "Ancient Phylactery":
			return "Ignore the shadowy miasma of evil, occasional murmurs, and slight smell of milk. " +
				"This is a charm that once held the soul of an ancient and powerful necromantic sorcerer - " +
					"undoubtedly a superb material for any sort of amulet. Luckily, the phylactery has been " +
					"emptied of any malevolent souls, leaving only potent traces of magical energy behind. " +
					"Probably.";
			break;
		case "Mythreal Ore":
			return "Mythreal Ore's the rarest metal you'll ever see - in no small part because " +
				"you might not even see it at all.  Blasted stuff warps in and out of existence at a whim, " +
					"but it's more durable than anything else.  Poor Shroedy found that out the hard way when " +
					"he ate some I had lying around.  Every so often I still hear him mewling for his dinner...";
			break;
		case "Manticore Quill":
			return "Hydras this, hydras that, everyone's always blathering on about hydras!  " +
				"Stupid overgrown, overhyped, overexaggerated gecko; it only has nine heads because " +
					"its poison is nine times weaker than a manticore's!  Hydra venom is overpriced trash - " +
					"Manticore Quills are you really want!  A single prick, and in one minute, paralysis, in " +
					"two, terrible agony, and in three, death.";
			break;
		case "Crimson Slime Jelly":
			return "Crimson Slime Jelly comes from, well, Crimson Slimes.  The little critters " +
				"are mostly harmless, but their fluids'll burn more than just your clothing.  " +
					"Forget your chastity if you're enveloped; you'll be lucky to have your skin intact!";
			break;
		case "Azure Slime Jelly":
			return "Azure Slime Jelly comes from Azure Slimes, which are azure.  They're far less " +
				"immediately damaging than Crimson Slimes - about three times less, in fact - but their " +
					"fluids are a powerful paralytic.  Getting enveloped by one is highly unpleasant, but " +
					"being left at the mercy of whatever, or whoever, happens to come along?  Well, that's a " +
					"scenario that best goes unthought.";
			break;
		case "Golden Slime Jelly":
			return "This glittering golden ichor's extracted from the mighty and mysterious Golden " +
				"Slime, the rarest breed of them all.  Don't believe any rumors you hear about reducing " +
					"Golden Slime populations to drive up Golden Slime Jelly prices - that would be ridiculous!  " +
					"Still, even if this jelly wasn't ten times more effective than other Slime Jellies (which " +
					"it is, of course), it's got such a lovely sparkle to it! It'd be a shame to sell it for less.";
			break;
		case "Arachne Gossamer":
			return "Dungeons are just like cellars: dark, unpleasant, and filled with cobwebs.  " +
				"Unlike the cobwebs cluttering your cellar, however, Arachne Gossamer is far more useful.  " +
					"It's sturdy, flexible, and even dyes easily!  Just make sure you clean out the adventurer " +
					"bits first.";
			break;
		case "Dire Bear Derriere":
			return "You know how it is with things: Go out into the Wilde Wastes of Nowhere Moor, " +
				"slay as many Dire Bears as you can, and claim the surprisingly durable booty.  It's a real " +
					"grind getting these things, but they're a useful material for armor.  If only everything " +
					"about them wasn't such a pain in the...";
			break;
		}
		return "";
	}

	public int getOfficalPrice(string name){
		switch(name){
		case "Salamander Oil":
			return 150;
			break;
		case "Cerberus Fang":
			return 700;
			break;
		case "Eight-Leaf Clover":
			return 150;
			break;
		case "Powdered Fairy Wing":
			return 500;
			break;
		case "Werewolf Hide":
			return 600;
			break;
		case "Consecrated Spring Water":
			return 100;
			break;
		case "Fermented Yeti Blood":
			return 600;
			break;
		case "Sacred Yew Sapling":
			return 100;
			break;
		case "Luminescent Scale":
			return 500;
			break;
		case "Meteoric Iron":
			return 500;
			break;
		case "Kobold Tears":
			return 700;
			break;
		case "Elder Dragon's Heart":
			return 1000;
			break;
		case "Albino Goblin's Eye":
			return 400;
			break;
		case "Minotaur's Horn":
			return 600;
			break;
		case "Ectoplasmic Ooze":
			return 200;
			break;
		case "Ancient Phylactery":
			return 1000;
			break;
		case "Mythreal Ore":
			return 1000;
			break;
		case "Manticore Quill":
			return 600;
			break;
		case "Crimson Slime Jelly":
			return 150;
			break;
		case "Azure Slime Jelly":
			return 150;
			break;
		case "Golden Slime Jelly":
			return 1000;
			break;
		case "Arachne Gossamer":
			return 200;
			break;
		case "Dire Bear Derriere":
			return 200;
			break;

		// =================== product ====================

		case "Elixir of Minor Rejuvenation":
			return 500;
			break;
		case "Elixir of Rejuvenation":
			return 1500;
			break;
		case "Elixir of Major Rejuvenation":
			return 3500;
			break;
		case "Unguent of Minor Invigoration":
			return 500;
			break;
		case "Unguent of Invigoration":
			return 1200;
			break;
		case "Unguent of Major Invigoration":
			return 4000;
			break;
		case "Tonic of Minor Restoration":
			return 800;
			break;
		case "Tonic of Restoration":
			return 1600;
			break;
		case "Tonic of Major Restoration":
			return 4000;
			break;
		case "Paralytic Poison":
			return 1000;
			break;
		case "Combustive Poison":
			return 1000;
			break;
		case "God-Felling Venom":
			return 7500;
			break;
		case "Everflowing Panacea":
			return 1500;
			break;
		case "Trusty Sword":
			return 1500;
			break;
		case "Treebirthed Sword":
			return 3500;
			break;
		case "Lakeborn Sword":
			return 6500;
			break;
		case "Wooden Shield":
			return 1000;
			break;
		case "Holy Shield":
			return 3000;
			break;
		case "Divine Aegis":
			return 7500;
			break;
		case "Emblem of Power":
			return 1500;
			break;
		case "Emblem of Endurance":
			return 1500;
			break;
		case "Emblem of Acuity":
			return 2500;
			break;
		case "Emblem of Vitality":
			return 2500;
			break;
		case "Emblem of Superiority":
			return 5500;
			break;
		case "Staff of Blasting":
			return 2000;
			break;
		case "Staff of Healing":
			return 3000;
			break;
		case "Staff of Indomitability":
			return 4500;
			break;
		case "Staff of Omnipotence":
			return 5000;
			break;
		case "Monk's Robes":
			return 1000;
			break;
		case "Archmage's Raiment":
			return 3500;
			break;
		case "Saint's Shroud":
			return 6000;
			break;
		case "Page's Armor":
			return 2500;
			break;
		case "Squire's Armor":
			return 4500;
			break;
		case "Paladin's Armor":
			return 10000;
			break;
		case "Ursinine Armor":
			return 5000;
			break;
		case "Short Bow":
			return 1000;
			break;
		case "Cross Bow":
			return 2500;
			break;
		case "Elongated Bow":
			return 3500;
			break;
		case "Heroic Bow":
			return 5500;
			break;
		case "Explosive Bombs":
			return 2500;
			break;
		case "Poisonous Arrows":
			return 4000;
			break;
		case "Fiery Arrows":
			return 1500;
			break;
		case "The Absolute Annihilator of the Ancient Archdeity":
			return 20000;
			break;
		}
		return 0;
	}

	public void stackSupply(){
		List<string> tmp = new List<string>();
		switch (GameMaster.currentDay) {
		case 1:
			tmp.Add("Consecrated Spring Water");
			tmp.Add("Eight-Leaf Clover");
			tmp.Add("Salamander Oil");
			tmp.Add("Cerberus Fang");
			tmp.Add("Powdered Fairy Wing");
			tmp.Add("Werewolf Hide");
			tmp.Add("Fermented Yeti Blood");
			tmp.Add("Sacred Yew Sapling");
			tmp.Add("Luminescent Scale");
			tmp.Add("Meteoric Iron");
			tmp.Add("Kobold Tears");
			tmp.Add("Elder Dragon's Heart");
			tmp.Add("Minotaur's Horn");
			tmp.Add("Ectoplasmic Ooze");
			tmp.Add("Ancient Phylactery");
			tmp.Add("Mythreal Ore");
			tmp.Add("Manticore Quill");
			tmp.Add("Crimson Slime Jelly");
			tmp.Add("Azure Slime Jelly");
			tmp.Add("Golden Slime Jelly");
			tmp.Add("Arachne Gossamer");
			tmp.Add("Dire Bear Derriere");
			break;
		}

		// add to supply
		_Supply.supplyList = new List<Item> ();
		for (int i = 0; i < tmp.Count; i++) {
			_Supply.supplyList.Add (new Item (tmp[i], 0, "", getOfficalPrice(tmp[i]), 0));
		}
	}
}
