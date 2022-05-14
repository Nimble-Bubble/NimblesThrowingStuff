using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NimblesThrowingStuff.Items.Materials;

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
                if (Main.player[item.owner].statMana > 100)
                {
                    Projectile.NewProjectile(position.X, position.Y, speedX, speedY, ModContent.ProjectileType<MisfireProj>(), damage *= 2, knockBack *= 2, Main.myPlayer, 0f);
                }
                else
                {
                    Gore.NewGore(position, new Vector2 (speedX, speedY), Main.rand.Next(11, 14), 1f);
                }
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
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Muramasa);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 9);
            recipe.AddIngredient(ItemID.Diamond, 5);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.MagicMissile);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.AquaScepter);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 15);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.BlueMoon);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 9);
            recipe.AddIngredient(ItemID.Cobweb, 20);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Valor);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.Handgun);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 18);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.CobaltShield);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 18);
            recipe.AddIngredient(ItemID.Obsidian, 25);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.ShadowKey);
            recipe.AddRecipe();
        }
    }
}