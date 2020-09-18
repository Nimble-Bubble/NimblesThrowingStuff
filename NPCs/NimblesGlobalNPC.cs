using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.NPCs
{
    public class NimblesGlobalNPC : GlobalNPC
    {

		public override void NPCLoot(NPC npc)
		{
            if (npc.type == NPCID.WallofFlesh && Main.rand.NextBool(7) && !Main.expertMode)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<ThrowerEmblem>(), 1);
			}
            if (npc.type == NPCID.BigMimicHallow && Main.rand.NextBool(4))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<SacredWristband>(), 1);
			}
            if (npc.type >= 338 && npc.type <= 340 && Main.rand.NextBool(2) || npc.type >= 347 && npc.type <= 350 && Main.rand.NextBool(2))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<FestiveCloth>(), 1);
			}
            if (npc.type == NPCID.SantaNK1)
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<FestiveCloth>(), Main.rand.Next(7, 13));
			}
		}
    }
}