﻿using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class StartTile : MonoBehaviour {

  public GameObject deadBandit;
  public GameObject deadBoy;
  public GameObject deadGirl;
  public GameObject startingWeapon;
  public GameObject[] startingTools;

  public int range = 7;

  public void PlaceStartTiles() {
    Tile[,] tileMap = this.GetComponent<RoomManager>().tileMap;

    for (var i = 0; i < 3; i++) {
      this.PlaceInStartingRange(deadBandit);
    }

    this.PlaceInStartingRange(deadGirl);
    this.PlaceInStartingRange(deadBoy);
    this.PlaceInStartingPath(startingWeapon);
    this.PlaceInStartingPath(startingTools[Random.Range(0, startingTools.Length)]);
  }

  private void PlaceInStartingRange(GameObject sprite) {
    Tile[,] tileMap = this.GetComponent<RoomManager>().tileMap;

    int x = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
    int y = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
    while (tileMap[x, y].blocking) {
      x = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
      y = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
    }

    this.GetComponent<RoomManager>().PlaceItem(sprite, x, y);
  }

  private void PlaceInStartingPath(GameObject sprite) {
    Tile[,] tileMap = this.GetComponent<RoomManager>().tileMap;

    int x = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
    int y = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
    while (!tileMap[x, y].path || (x == 15 || x == 16) && (y == 15 || y == 16)) {
      x = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
      y = 16 + Random.Range((int) (-range / 2), (int) (range / 2));
    }

    this.GetComponent<RoomManager>().PlaceItem(sprite, x, y);
  }
}
