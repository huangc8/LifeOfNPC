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

		// =================== product ===================== 
		case "Elixir of Minor Rejuvenation":
			return "Not the best of potions to fix you up, but definitely the cheapest.  Guaranteed to restore " +
				"25 HP per bottle!  As for what HP even stands for... Well, the apothecaries will reach a " +
				"consensus on that when platypi fly.";
			break;
		case "Elixir of Rejuvenation":
			return "Your standard HP-restoring potion, guaranteed to restore 100 HP per bottle!  The cherry flavor " +
				"comes free of charge.";
			break;
		case "Elixir of Major Rejuvenation":
			return "The elite of the elites of HP-restoring potions, guaranteed to restore 500 HP per bottle!  Each " +
				"drop is individually blessed by fairies to ensure your maximum satisfaction.";
			break;
		case "Unguent of Minor Invigoration":
			return "Magic Points, Mana Points, Mystic Points... Does the name even matter?  Whatever you call it, this " +
				"potions lets you sling spells for an extra 25 MP, and even has a pleasant fizzy aftertaste!  Just don't " +
				"drink too many at once; the last time a wizard tried casting spells while he had the hiccups... Well, it " +
				"was very unpleasant.";
			break;
		case "Unguent of Invigoration":
			return "Your basic MP potion that restores 100 MP, best suited for the adventurer beginning to make a name for " +
				"themself.  Hopefully it's not too embarrassing of a name, like Vomit, or Ryuugatatsumaru, or Steve.";
			break;
		case "Unguent of Major Invigoration":
			return "This product's meant for serious spellcasters.  If you're still working on your birthday party animal " +
				"conjurations, this potion isn't for you.  But if you're a true sorcerer - more of a living artillery cannon " +
				"than a man - then this potion will restore 500 MP, so you'll never have to worry about being out of firepower.";
			break;
		case "Tonic of Minor Restoration":
			return "You might think that they're just a mild inconvenience, but status ailments can make the difference between " +
				"victory and defeat.  That's why you need a tonic to clear yourself of any kind of status ailment, including but " +
				"not limited to: BRN, PAR, FRZ, PSN, SLP, CHM, STN, FLI, AGR, EGG, TEM, TMI, IMO, OMG, TFW, and KEK.  This tonic " +
				"nly clears PAR and PSN, though.  Hey, there's a reason this is cheap, you know?";
			break;
		case "Tonic of Restoration":
			return "A more multipurpose tonic for a more multipurpose Adventurer... Well, a more affluent one, at any rate.  " +
				"Unlike a Tonic of Minor Restoration, this potion cures BRN, FRZ, SLP, CHM, and AGR.  If you can't get the afflicted " +
				"to drink it, then throwing it at them should work just fine.  For any resultant lacerations from broken glass, we " +
				"recommend an Elixir of Rejuvenation!";
			break;
		case "Tonic of Major Restoration":
			return "With this tonic, you won't need to worry about searching out the correct antidote any longer!  That's right; this " +
				"tonic remedies ALL status ailments (but not the beneficial ALL status, no need to worry there).  That means you don't " +
				"even need to know those strange abbreviations stand for anymore!  Just quaff a Tonic of Major Restoration, and all of " +
				"your worries will disappear!";
			break;
		case "Paralytic Poison":
			return "A paralytic poison is a poison that is paralytic. WOO!... is not what people will say after taking some into their bloodstream.  " +
				"They won't be saying much of anything, given that even their lips will be paralyzed.  Too strong a dose, and their heartbeat will " +
				"stop and they'll die.  Feel free to overdose monsters, though!  We've taken special care to ensure full effectiveness, even when applied " +
				"to weapons, so just make sure you don't prick yourself...";
			break;
		case "Combustive Poison":
			return "Some toxins are meant to incapacitate.  Others induce pleasure, or delusion.  But this particular tincture?  No.  This poison is meant to " +
				"hurt, to agonize, to excruciate.  Those afflicted swell uncontrollably, sweat profusely, and their flesh will feel as if it is melting off their " +
				"bones, leaving only unbearably agony in its wake.  Despite the name, it's completely flame-retardant.";
			break;
		case "God-Felling Venom":
			return "The most toxic toxin in terms of toxicity to ever toxify a target.  Its mere odor scours at your nostrils, its emanations permanently scar the " +
				"eyes, and its ingestion brings death, agonizing and inexorable.  As the name suggests, deicide is but a matter of course for a poisonous poison that " +
				"poisons people such as this.  Deicide is still a crime, however.  Neither the producers of God-Felling Venom or its sellers and distributors are to be " +
				"held liable for any deicide that may occur.";
			break;
		case "Everflowing Panacea":
			return "For those nights at the bar where you need an extra dose of liquid carbs to keep you company, or those lonely nights alone where you need a friend to " +
				"help you forget your sorrows, or those lonely afternoons without friends, or any time you're lonely at all, we're here for you to put an arm around your shoulder " +
				"and hold you tight for as long as we want.  Side effects include euphoria, a pleasant warm sensation in the pit of the stomach, complete enmotional and chemical " +
				"dependence, glossier skin, increased confidence, and slight weight gain.";
			break;
		case "Trusty Sword":
			return "A simple yet sturdy blade, suitable for the start of a grand adventure.  For those who weren't lucky enough to inherit their father's sword, or retrieve an ancient " +
				"sword from a dilapidated shrine, or meet a mysterious girl who transforms into a legendary sword, this sword is the sword for you!  Until it's time for you to wield the " +
				"true magic sword that you were always meant to, this mundane yet reliable sword will do.";
			break;
		case "Treebirthed Sword":
			return "This shining sword is perfect for the eco-friendly adventurer!  Specially grown from a sacred tree, this magnificent blade channels the energy of the sun into devastating " +
				"strikes certain to slay any foe.  Best of all, there are zero harmful emissions!  Protect the planet while you protect the kingdom with the Treebirthed Sword!";
			break;
		case "Lakeborn Sword":
			return "The greatest of holy blades that graces our land; it shines with the light of humanity's hopes and dreams.  A sword guaranteed to never break and capable of slaying an army " +
				"with one swing - provided you have the MP available for its Limit Break Mode.  That said, make sure you don't fall into any lakes while you've got this sword; it wasn't exactly " +
				"acquired... willingly.";
			break;
		case "Wooden Shield":
			return "A simple wooden shield perfect for the defensively-minded novice Adventurer.  As required by industry standards, this shield is electricity-resistant, so you'll have no need to " +
				"be shocked by any sudden ectrifying encounters.  So much as look at a torch and your chances will go up in flames, though, so be cautious.  Of course, you can always buy another shield " +
					"if something happens to this one!";  
			break;
		case "Holy Shield":
			return "Unlike cheaper shields, there's no need to worry about this one spontaneously combusting, or nonspontaneously combusting for that matter.  This sacred shield not only protects against " +
				"all manner of blows, but it even conduct electricity!  Too well, in fact; anyone attempting to block an electrical attack with this shield will get quite the... discharge.";
			break;
		case "Divine Aegis":
			return "The mightiest of shields, and completely impervious to all manner of damage.  Its construction from unspeakably rare metals provides unparalleled protection from flame and force, and the " +
				"numerous divine blessings imbued into its surface prevent electrical attacks from damaging the user.  Well, that or the coating of cerberus enamel.";
			break;
		case "Emblem of Power":
			return "Looking to add a bit more power to your punches?  Want to get stronger without going to the gym?  If so, then the Emblem of Power is the perfect fit for you!  This inexpensive amulet adds " +
				"+15 STR, ensuring each of your strikes will knock your enemies clean out of the park - or at least off their feet.  Emblems of Courage and Wisdom sold separately.";
			break;
		case "Emblem of Endurance":
			return "For Adventurers interested in better taking a hit, we have the Emblem of Endurance.  This amulet gives you +15 to END, making taking it easier than ever, if u ket what I mean.";
			break;
		case "Emblem of Acuity":
			return "Tired of everyone laughing at jokes you don't understand?  Sick of being the only one in the " +
				"party to talk slowly and haltingy without a proper grasp of grammatical conventions?  Then the " +
				"Emblem of Acuity is the item for you!  This lovely blue magical amulet grants +50 WIS, " +
				"transforming the town dullard into the town teacher!  Oh, and it also boosts MP regeneration.";
			break;
		case "Emblem of Vitality":
			return "The Emblem of Vitality is vital for any Adventurer looking to last just that extra moment " +
				"longer in the Dungeon.  It grants +200 to HP, ensuring that you have time for one extra Tonic " +
				"of Rejuvenation (sold separately), one last invocation of your Staff of Blasting (also sold " +
				"separately), or one final dramatic swing of your Lakeborn Sword (buy 1, get one amulet of your " +
				"choice free!).";
			break;
		case "Emblem of Superiority":
			return "This mighty amulet is perfect for the sorcerer determined to excel in all matters.  The Emblem " +
				"of Superiority grants +300 to HP, MP, WIS, END, STR, AGI, CHA, FOR, WIL, REF, CON, LSD, PSI, PCP, " +
				"TSA, and TMI, ensuring your undeniable superiority over everyone else.  If the side-effects don't " +
				"give you a god complex and inflated ego, then the sheer power at your disposal will!";
			break;
		case "Staff of Blasting":
			return "A basic offensive staff meant for a novice Adventurer.  For when your Fighter or Monk can't " +
				"punch an obstacle out of the way and your Ranger or Thief can't budge it, just use your Staff " +
				"of Blasting to obliterate it!  There's no need for finesse with this baby in your hands!";
			break;
		case "Staff of Healing":
			return "As fun as spellslinging can be, it's not all lightning bolts and fireballs.  For when you " +
				"need to heal a party member and your cleric and priest are all out of prayers, this staff is here!" +
				"For only 50 MP, you can heal up to 200 HP on a single Adventurer!  That's not all it can do, " +
				"though.  You'll find certain undead enemies won't enjoy being reunited with their mortal flesh; " +
				"and in the worse case scenario, you can always inflict a light wound or two!  " +
				"I hear <<Blunt>> damage works fairly well against Skeleton Dudes...";
			break;
		case "Staff of Indomitability":
			return "If your arms are too scrawny to hold a shield and your BRA's too low to wear an amulet, " +
				"then this staff is the staff for you!  The Staff of Indomitability renders its wielder an " +
				"impregnable bulwark of stalwart defense, ensuring damage is little more than a scratch.  " +
				"Well, except for <<Piercing>> attacks... but what are the chances that you'll run into those?";
			break;
		case "Staff of Omnipotence":
			return "The greatest of all magical staffs, meant only for the greatest of Wizards and Sorcerers.  " +
				"This magnificent tool boosts MP by +1500 and WIS by +500, ensuring that its wielder will never " +
				"run short of power and spells.  Whosoever wields this almight staff could easily be considered " +
				"a god - but in that case, should watch out for poison... ";
			break;
		case "Monk's Robes":
			return "Simple yet effective robes that increase MP by +100 and WIS by +20.  While the clothes may " +
				"make the man, it's up to the man to outgrow the clothes.  That said, they are one size fits all," +
				"so for the more vertically challenged, that could be rather difficult...";
			break;
		case "Archmage's Raiment":
			return "Robes suitable for a more knowledgable Wizard that grant +200 to MP and +50 to WIS.  " +
				"Unlike basic robes, the Archmage's Raiment possesses a modicum of protection against heat" +
				"and flame, allowing its wearer to travel to more arid locales.  Just make sure you don't" +
				"get it wet, though; the smell of the wet fur lining takes ages to dissipate.";
			break;
		case "Saint's Shroud":
			return "Lovely robes capable of withstanding not only extreme climes both sweltering and frigid, " +
				"but also imbued with a potent enchantment permitting for underwater breathing.  " +
				"These magnificent robes grant +400 MP and +100 WIS, and have multiple color and style " +
				"modes as well!";
			break;
		case "Page's Armor":
			return "Simple armor befitting a beginning knight lacking a traditional set of the family armor.  " +
				"This armor provides +150 to END, allowing for plenty of mistakes as its wearer grows into a " +
				"splendid knight.  It lacks excretory capabilities, however, so make sure that you don't " +
				"drink too many potions...";
			break;
		case "Squire's Armor":
			return "Well-made armor suitable for a knight's graduation to a greater rank.  Not only does it " +
				"grant +300 to END, but it also shines with a lovely iridescent luster when clean!";
			break;
		case "Paladin's Armor":
			return "Splendid armor befitting the most decorated and valorous of knights.  The Paladin's Armor" +
				"grants not only +1000 to END, but also +300 to HP.  Furthermore, it's even self-cleaning!" +
				"Stains tend to flicker clean out of existence - along with the occasional coat of arms and" +
				"doublet.";
			break;
		case "Ursinine Armor":
			return "Wild armor suitable for a wild and boisterous Adventurer.  Rather than continuously " +
				"forged steel, only the hide of slain beasts serves as your protection!  Rekindle your " +
				"inner beast, and gain +500 END and +300 STR!";
			break;
		case "Short Bow":
			return "A short bow, meant for a short Adventurer who's only spent a short amount of time in " +
				"The Dungeon.  It's got a short range, but its power is nothing to scoff at.  Arrows sold " +
				"separately.";
			break;
		case "Cross Bow":
			return "A partially automated bow built by the Church in their quest to cleanse the land of all " +
				"those they deem unholy.  Despite the odd shape, it's devastatingly effective, and capable " +
				"tearing through living and undead enemies with ease.";
			break;
		case "Elongated Bow":
			return "A lengthy bow meant for a lengthy individual.  Rather than fighting at mid- or close range, " +
				"the Elongated Bow is best suited for snipers and Archers who prefer to engage from a distance.  " +
				"This resilient bow can fire up to 400 feet when fully drawn, and even grants +150 DEX when " +
				"equipped.";
			break;
		case "Heroic Bow":
			return "The legendary bow used by the great hero of the kingdom himself... Well, an accurate model" +
				"of it.  This golden bow can fire three arrows at the same without any loss in power or accuracy," +
				"and is guaranteed to slay any enemy it is used against - or the mind of any physicist or" +
				"engineer that sees it.";
			break;
		case "Explosive Bombs":
			return "As you might expect, an Explosive Bomb is a bomb that explodes.  Rather than poison or " +
				"smoke, pure destructive power is the emphasis for these devastating items.  They're sold " +
				"in packs of ten, and best stored in our special Bomb Bag (sold separately).  While you can" +
				"store them otherwise, we can't be held liable for any mishaps bound to happen...";
			break;
		case "Poisonous Arrows":
			return "These arrows come laced with deadly poison to sicken your enemies, saving you the " +
				"trouble of doing so yourself.  Of course, while you can't poison yourself dosing the " +
				"arrows, caution is still required in handling them.  As the adage goes: You poison " +
					"yourself like an idiot, you buy it.";
			break;
		case "Fiery Arrows":
			return "Arrows specially doused in accelerants that ignite when fired through air friction.  " +
				"Our special blend of ingredients prevents them from burning too quickly before they reach " +
				"their target or failing to ignite, so detonating faraway crates of explosives or adding an " +
				"extra banf to your blasts is easier than ever before!  Just make sure you keep them in a " +
				"fireproof quiver.";
			break;
		case "The Absolute Annihilator of the Ancient Archdeity":
			return "The greatest artifact of our time, the most sacrosanct and mysterious relic left of an " +
				"ancient civilization of unspeakable wisdom and power who spanned the world, the most mighty " +
				"of all devices of mystical power... and we have no idea what it does.  It's very impressive " +
				"looking, though!";
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
		default:
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
