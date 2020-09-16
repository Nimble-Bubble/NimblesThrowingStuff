using NimblesThrowingStuff.Items.Accessories;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.Items
{
    public class NimblesGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item) //no longer virtual
        {
            if (item.type == ItemID.ObsidianHelm)
            {
             item.defense = 5; 
            }
            if (item.type == ItemID.ObsidianShirt)
            {
             item.defense = 6; 
            }
            if (item.type == ItemID.ObsidianPants)
            {
             item.defense = 5; 
            }
		}
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag" && arg == ItemID.WallOfFleshBossBag)
            {
                if (Main.rand.NextBool(6))
                {
                player.QuickSpawnItem(ItemType<ThrowerEmblem>());
                }
            }
        }
    }
}