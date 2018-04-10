using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMatchManager : MonoBehaviour {

	static List<PlayerHealth> players = new List<PlayerHealth>();
	// Use this for initialization
	public static void AddPlayer(PlayerHealth player) {
		players.Add(player);
	}

	public static bool RemovePlayerAndCheck(PlayerHealth player) {
		players.Remove(player);
		if(players.Count == 1) {
			return true;
		}
		return false;
	}

	public static PlayerHealth GetWinner() {
		if(players.Count != 1) {
			return null;
		}
		return players[0];
	}
}
