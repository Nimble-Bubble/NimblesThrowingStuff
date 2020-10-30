using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Weapons.Throwing;
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
            if (context == "bossBag") 
            {
                if (arg == ItemID.QueenBeeBossBag && Main.rand.NextBool(3))
                {
                player.QuickSpawnItem(ItemType<Beemerang>());
                }
                if (arg == ItemID.WallOfFleshBossBag && Main.rand.NextBool(6))
                {
                player.QuickSpawnItem(ItemType<ThrowerEmblem>());
                }
                if (arg == ItemID.PlanteraBossBag && Main.rand.NextBool(3))
                {
                player.QuickSpawnItem(ItemType<ThornyGlove>());
                }
                if (arg == ItemID.GolemBossBag && Main.rand.NextBool(4))
                {
                player.QuickSpawnItem(ItemType<GolemGlove>());
                }
            if (arg == ItemID.FishronBossBag && Main.rand.NextBool(4))
                {
                player.QuickSpawnItem(ItemType<PoseironTrident>());
                }
                if (arg == ItemID.MoonLordBossBag && Main.rand.NextBool(5))
                {
                player.QuickSpawnItem(ItemType<CosmosCrasher>());
                player.QuickSpawnItem(ItemType<SatelliteSpear>());
                }
            }
        }
    }
}