using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NimblesThrowingStuff.Items.Materials;
using Terraria.DataStructures;

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
            if (item.type == ItemID.ReaverShark)
            {
                item.pick = 65;
            }
		}
        public override bool CanRightClick(Item item)
        {
            if (item.CountsAsClass(DamageClass.Ranged) && Main.player[item.playerIndexTheItemIsReservedFor].GetModPlayer<NimblesPlayer>().rangeMisfire)
            {
                return true;
            }
            return base.CanRightClick(item);
        }
        //public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        //{
        //    if (source.ranged && Main.player[item.playerIndexTheItemIsReservedFor].GetModPlayer<NimblesPlayer>().rangeMisfire && Main.mouseRight)
        //    {
                //if (Main.player[item.playerIndexTheItemIsReservedFor].statMana > 100)
                //{
        //            Projectile.NewProjectile(position, Velocity, ModContent.ProjectileType<MisfireProj>(), damage *= 2, knockBack *= 2, Main.myPlayer, 0f);
                //}
                //else
                //{
                //    Gore.NewGore(position, new Vector2 (speedX, speedY), Main.rand.Next(11, 14), 1f);
                //}
        //    return false;
        //}
        //    return base.Shoot(player, item, source, position, Velocity, type, damage, knockBack);
        //}
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            if (context == "bossBag") 
            {
                if (arg == ItemID.QueenBeeBossBag && Main.rand.NextBool(3))
                {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<Beemerang>(), 1);
                }
                if (arg == ItemID.WallOfFleshBossBag && Main.rand.NextBool(6))
                {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<ThrowerEmblem>(), 1);
                }
                if (arg == ItemID.PlanteraBossBag && Main.rand.NextBool(3))
                {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<ThornyGlove>(), 1);
                }
                if (arg == ItemID.GolemBossBag && Main.rand.NextBool(4))
                {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<GolemGlove>(), 1);
                }
            if (arg == ItemID.FishronBossBag && Main.rand.NextBool(4))
                {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<PoseironTrident>(), 1);
                }
                if (arg == ItemID.MoonLordBossBag && Main.rand.NextBool(5))
                {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<CosmosCrasher>(), 1);
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<SatelliteSpear>(), 1);
                }
            }
            
         }
        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.Muramasa);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.MagicMissile);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 9);
            recipe.AddIngredient(ItemID.Diamond, 5);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.AquaScepter);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.BlueMoon);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 15);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.Valor);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 9);
            recipe.AddIngredient(ItemID.Cobweb, 20);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.Handgun);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.CobaltShield);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 18);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.ShadowKey);
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 18);
            recipe.AddIngredient(ItemID.Obsidian, 25);
            recipe.AddIngredient(ItemID.GoldenKey, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            recipe = Recipe.Create(ItemID.MusketBall, 50);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}