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
        public int maxShells;
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
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (item.CountsAsClass(DamageClass.Ranged) && player.GetModPlayer<NimblesPlayer>().rangeMisfire && Main.mouseRight)
            {
        if (player.statMana > 100)
        {
                    Projectile.NewProjectile(player.GetSource_FromThis(), position, velocity, ModContent.ProjectileType<MisfireProj>(), damage *= 2, knockback *= 2, Main.myPlayer, 0f);
                        player.statMana -= 100;
        }
        else
        {
            Gore.NewGore(player.GetSource_FromThis(), position, velocity, Main.rand.Next(11, 14), 1f);
        }
            return false;
        }
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
    }
        public override void UpdateEquip(Item item, Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            if (item.type == 686)
            {
                modPlayer.rangedSpeed += 0.1f;
            }
            if (item.type == 1865 || item.type == 899 && Main.dayTime || item.type == 900 && !Main.dayTime || item.type == 3110 || item.type == 2277 || item.type == 4984)
            {
                modPlayer.rangedSpeed += 0.1f;
                modPlayer.magicSpeed += 0.1f;
                modPlayer.thrownSpeed += 0.1f;
                if (item.type == 3110 && !Main.dayTime)
                {
                    modPlayer.rangedSpeed += 0.051f;
                    modPlayer.magicSpeed += 0.051f;
                    modPlayer.thrownSpeed += 0.051f;
                }
            }
        }
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            Player player = Main.player[Main.myPlayer];
            if (item.type == ItemID.KingSlimeBossBag && Main.rand.NextBool(4))
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<ScavengedKunai>(), 1);
            }
            if (item.type == ItemID.QueenBeeBossBag && Main.rand.NextBool(3))
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<Beemerang>(), 1);
            }
            if (item.type == ItemID.WallOfFleshBossBag && Main.rand.NextBool(6))
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<ThrowerEmblem>(), 1);
            }
            if (item.type == ItemID.PlanteraBossBag && Main.rand.NextBool(3))
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<ThornyGlove>(), 1);
            }
            if (item.type == ItemID.GolemBossBag && Main.rand.NextBool(4))
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<GolemGlove>(), 1);
            }
            if (item.type == ItemID.FishronBossBag)
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<RoyalFin>(), Main.rand.Next(10, 15));
                if (Main.rand.NextBool(4))
                {
                    player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<PoseironTrident>(), 1);
                }
            }
            if (item.type == ItemID.BossBagBetsy && Main.rand.NextBool(4))
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<EtherianChakram>(), 1);
            }    
            if (item.type == ItemID.MoonLordBossBag && Main.rand.NextBool(5))
            {
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<CosmosCrasher>(), 1);
                player.QuickSpawnItem(player.GetSource_FromThis(), ItemType<SatelliteSpear>(), 1);
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
            recipe = Recipe.Create(ItemID.DepthMeter, 1);
            recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 5);
            recipe.AddIngredient(ModContent.ItemType<BatFlesh>(), 5);
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
            recipe = Recipe.Create(ItemID.DepthMeter, 1);
            recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 5);
            recipe.AddIngredient(ModContent.ItemType<BatFlesh>(), 5);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
            recipe = Recipe.Create(ItemID.Compass, 1);
            recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 10);
            recipe.AddIngredient(ItemID.MarbleBlock, 25);
            recipe.AddIngredient(ItemID.GraniteBlock, 25);
            recipe.AddTile(TileID.Tables);
            recipe.AddTile(TileID.Chairs);
            recipe.Register();
            recipe = Recipe.Create(ItemID.Compass, 1);
            recipe.AddRecipeGroup("IronBar", 20);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 10);
            recipe.AddIngredient(ItemID.MarbleBlock, 25);
            recipe.AddIngredient(ItemID.GraniteBlock, 25);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
            recipe = Recipe.Create(ItemID.Leather, 1);
            recipe.AddIngredient(ItemID.Vertebrae, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
            recipe = Recipe.Create(ItemID.LavaFishingHook, 1);
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
            recipe.AddIngredient(ItemID.Seashell, 1);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
            recipe = Recipe.Create(ItemID.AngelStatue, 1);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
        }
    }
}