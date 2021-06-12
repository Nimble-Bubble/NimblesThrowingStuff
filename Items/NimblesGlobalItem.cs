using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NimblesThrowingStuff.Items
{
    public class NimblesGlobalItem : GlobalItem
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
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
        public override bool CanRightClick(Item item)
        {
            if (item.ranged && Main.player[item.owner].GetModPlayer<NimblesPlayer>().rangeMisfire)
            {
                return true;
            }
            return base.CanRightClick(item);
        }
        public override bool Shoot(Item item, Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (item.ranged && Main.player[item.owner].GetModPlayer<NimblesPlayer>().rangeMisfire && Main.mouseRight)
            {
                Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<MisfireProj>(), damage *= 2, knockBack *= 2, Main.myPlayer, 0f);
            return false;
        }
            return base.Shoot(item, player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
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