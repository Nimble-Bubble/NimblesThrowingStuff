using System;
using System.IO;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Terraria.Utilities;
using NimblesThrowingStuff.Items;
using NimblesThrowingStuff.NPCs.Morilus;
using static Terraria.ModLoader.ModContent;
using System.Linq;


namespace NimblesThrowingStuff
{
    public class NimblesWorld : ModSystem
    {
        public static bool downedMorilus;
        public static int sizeMult = (int)(Math.Round(Main.maxTilesX / 4200f)); //Small = 2; Medium = ~3; Large = 4;

        public override void OnWorldLoad()
        {
            sizeMult = (int)(Math.Floor(Main.maxTilesX / 4200f));
            downedMorilus = false;
        }
        public override void LoadWorldData(TagCompound tag)
        {
            IList<string> downed = tag.GetList<string>("downed");
            downedMorilus = downed.Contains("MorilusMain");
        }

        public override void SaveWorldData(TagCompound tag)/* Edit tag parameter rather than returning new TagCompound */
        {
            TagCompound nottag = new TagCompound();
            var downed = new List<string>();
            bool obs = false;
            int pwr = 0;
            if (downedMorilus) downed.Add("MorilusMain");
            

            //return new TagCompound {
            //    {"downed", downed},
            //};
            //return nottag;
        }
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = downedMorilus;

            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedMorilus = flags[0];
        }
        public override void PostWorldGen()
		{
			int[] dung = new int[] {Mod.Find<ModItem>("Skelespear").Type};
            int[] eon = new int[] {Mod.Find<ModItem>("AquaBlastCore").Type};
			for (int i = 0; i < 1000; i++)
			{
				Chest chest = Main.chest[i];
				if (chest != null && Main.tile[chest.x, chest.y].TileType == 21 && Main.tile[chest.x, chest.y].TileFrameX == 72)
				{
                    if (Main.rand.Next(5) == 0)
                    {
					for (int j = 0; j < 40; j++)
					{
						if (chest.item[j].type == 0)
						{
							chest.item[j].SetDefaults(Main.rand.Next(dung));
							break;
						}
					}
                    }
                    if (Main.rand.Next(5) == 1)
                    {
                    for (int j = 0; j < 40; j++)
					{
						if (chest.item[j].type == 0)
						{
							chest.item[j].SetDefaults(Main.rand.Next(eon));
							break;
						}
					}
                    } 
				}
			}
		}
	}
}