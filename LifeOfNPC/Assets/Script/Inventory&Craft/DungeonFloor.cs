using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DungeonFloor : MonoBehaviour {
	public int level;
	public List<string> goodItem;
	public List<string> badItem;
	public int goodClass;	// 1 - wizard, 2 - warrior, 3 - ranger 
	public int badClass;
	public List<string> monsters;
	public string boss;
	
	public int levelPoints;
	public int bossPoints;

	public bool checkIfGoodItem(string name){
		foreach (string str in goodItem) {
			if(str == name){
				return true;
			}
		}
		return false;
	}

	public bool checkIfBadItem(string name){
		foreach (string str in badItem) {
			if(str == name){
				return true;
			}
		}
		return false;
	}
}
