using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class MountainTile : BiomeTile
{

	// randomization constants
	public int bloomNum = 100;
	public RoomManager.Count bloomSize = new RoomManager.Count(3, 7);

	public const int BiomeNumber = 3;

	public override void RandomBlocking(List<Tile> region) {

		foreach (Tile tile in region) {
			float noise = Mathf.PerlinNoise((float)tile.x * .08f, (float)tile.y * .08f);
			if (noise > .47f && !tile.path && tile.item == null) {
				tile.elevation++;
			}
			if (noise > .65f && !tile.path && tile.item == null) {
				tile.elevation++;
			}

		}

		this.GetComponent<ElevationTile>().SmoothElevation(region);

		/* foreach (Tile tile in region) {

			if (tile.x <= 0 || tile.y <= 0 || tile.x >= )
			for (int x = -1; x <= 1; x++) {
				for (int y = -1; y <= 1; y++) {

				}
			}
		} */

		base.RandomBlocking(region);
	}

	public override int getBiomeNumber() {
		return 3;
	}
}