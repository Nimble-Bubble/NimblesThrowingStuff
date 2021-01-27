using NimblesThrowingStuff.NPCs;
using NimblesThrowingStuff.Projectiles;
using NimblesThrowingStuff.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace NimblesThrowingStuff
{
    public static class Utilities
    {        
		#region Object Extensions
		public static NimblesPlayer Nimbles(this Player player) => player.GetModPlayer<NimblesPlayer>();
		public static NimblesGlobalNPC Nimbles(this NPC npc) => npc.GetGlobalNPC<NimblesGlobalNPC>();
		public static NimblesGlobalItem Nimbles(this Item item) => item.GetGlobalItem<NimblesGlobalItem>();
		public static NimblesGlobalProjectile Nimbles(this Projectile proj) => proj.GetGlobalProjectile<NimblesGlobalProjectile>();
		#endregion

		#region Player Utilities
		// These functions factor in TML 0.11 allDamage to get the player's total damage boost which affects the specified class.
		public static float MeleeDamage(this Player player) => player.allDamage + player.meleeDamage - 1f;
		public static float RangedDamage(this Player player) => player.allDamage + player.rangedDamage - 1f;
		public static float MagicDamage(this Player player) => player.allDamage + player.magicDamage - 1f;
		public static float MinionDamage(this Player player) => player.allDamage + player.minionDamage - 1f;
		public static float ThrownDamage(this Player player) => player.allDamage + player.thrownDamage - 1f;
		public static float AverageDamage(this Player player) => player.allDamage + (player.meleeDamage + player.rangedDamage + player.magicDamage + player.minionDamage + player.thrownDamage - 5f) / 5f;

		public static bool IsUnderwater(this Player player) => Collision.DrownCollision(player.position, player.width, player.height, player.gravDir);
		public static bool InSpace(this Player player)
		{
			float x = Main.maxTilesX / 4200f;
			x *= x;
			float spaceGravityMult = (float)((player.position.Y / 16f - (60f + 10f * x)) / (Main.worldSurface / 6.0));
			return spaceGravityMult < 1f;
		}
		public static bool PillarZone(this Player player) => player.ZoneTowerStardust || player.ZoneTowerSolar || player.ZoneTowerVortex || player.ZoneTowerNebula;
		public static bool InventoryHas(this Player player, params int[] items) => player.inventory.Any(item => items.Contains(item.type));
		#endregion

        #region OreSpawn
        public static void SpawnOre(int type, double frequency, float depth, float depthLimit)
        {
            int x = Main.maxTilesX;
            int y = Main.maxTilesY;
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                for (int k = 0; k < (int)((double)(x * y) * frequency); k++)
                {
                    int tilesX = WorldGen.genRand.Next(0, x);
                    int tilesY = WorldGen.genRand.Next((int)(y * depth), (int)(y * depthLimit));
                    WorldGen.OreRunner(tilesX, tilesY, (double)WorldGen.genRand.Next(3, 8), WorldGen.genRand.Next(3, 8), (ushort)type);
                }
            }
        }
        #endregion

        #region Tile Merge Utilities
        /// <summary>
        /// Sets the mergeability state of two tiles. By default, enables tile merging.
        /// </summary>
        /// <param name="type1">The first tile type which should merge (or not).</param>
        /// <param name="type2">The second tile type which should merge (or not).</param>
        /// <param name="merge">The mergeability state of the tiles. Defaults to true if omitted.</param>
        public static void SetMerge(int type1, int type2, bool merge = true)
        {
            if (type1 != type2)
            {
                Main.tileMerge[type1][type2] = merge;
                Main.tileMerge[type2][type1] = merge;
            }
        }

        /// <summary>
        /// Makes the first tile type argument merge with all the other tile type arguments. Also accepts arrays.
        /// </summary>
        /// <param name="myType">The tile whose merging properties will be set.</param>
        /// <param name="otherTypes">Every tile that should be merged with.</param>
        public static void MergeWithSet(int myType, params int[] otherTypes)
        {
            for (int i = 0; i < otherTypes.Length; ++i)
                SetMerge(myType, otherTypes[i]);
        }

        /// <summary>
        /// Makes the specified tile merge with the most common types of tiles found in world generation.<br></br>
        /// Notably excludes Ice.
        /// </summary>
        /// <param name="type">The tile whose merging properties will be set.</param>
        public static void MergeWithGeneral(int type) => MergeWithSet(type, new int[] {
            // Soils
            TileID.Dirt,
            TileID.Mud,
            TileID.ClayBlock,
            // Stones
            TileID.Stone,
            TileID.Ebonstone,
            TileID.Crimstone,
            TileID.Pearlstone,
            // Sands
            TileID.Sand,
            TileID.Ebonsand,
            TileID.Crimsand,
            TileID.Pearlsand,
            // Snows
            TileID.SnowBlock
        });
		#endregion
	}
}