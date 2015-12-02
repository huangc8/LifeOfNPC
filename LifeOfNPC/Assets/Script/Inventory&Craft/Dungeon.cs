using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dungeon : MonoBehaviour {

	public int currentFloor;
	public List<DungeonFloor> floors;

	void Start(){
		currentFloor = 0;
	}

	public void ProcessHero(Hero hero){
		// get reference
		int totalPoints = 0;
		DungeonFloor floor = floors [currentFloor];

		// calculate total points
		foreach (Item it in hero.H_Inventory) {
			if(floor.checkIfGoodItem(it.name)){
				totalPoints += 50;
			}
			if(floor.checkIfBadItem(it.name)){
				totalPoints -= 30;
			}
		}
		if (hero.HeroClass == floor.goodClass) {
			totalPoints += 20;
		}
		if (hero.HeroClass == floor.badClass) {
			totalPoints -= 20;
		}
		Destroy (hero);


		if (floor.levelPoints > 0) {
			floor.levelPoints -= totalPoints;
		} else {
			floor.bossPoints -= totalPoints;
		}

		if (floor.bossPoints < 0) {
			currentFloor++;
		}
	}

}
