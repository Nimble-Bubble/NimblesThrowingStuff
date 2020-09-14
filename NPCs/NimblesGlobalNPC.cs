using NimblesThrowingStuff.Items.Accessories;
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
            if (npc.type == NPCID.WallofFlesh && Main.rand.NextBool(7))
			{
				Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ItemType<ThrowerEmblem>(), 1);
			}
		}
    }
}