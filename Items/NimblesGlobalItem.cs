using NimblesThrowingStuff.Items.Accessories;
using NimblesThrowingStuff.Items.Weapons.Ranged;
using NimblesThrowingStuff.Items.Weapons.Throwing;
using NimblesThrowingStuff.Projectiles.Ranged;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using static Terraria.ModLoader.ModContent;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Items.Weapons.Ranged.Ammo;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;

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
            if (item.type == ItemID.SWATHelmet)
            {
                item.defense = 20;
                item.vanity = false;
            }
            if (item.type == ItemID.Nail)
            {
                item.ammo = AmmoID.Dart;
            }
            if (item.type == ItemID.NailGun)
            {
                item.useAmmo = AmmoID.Dart;
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
            SoundEngine.PlaySound(SoundID.Item150);
            Gore.NewGore(player.GetSource_FromThis(), position, velocity, Main.rand.Next(11, 14), 1f);
        }
            return false;
        }
            return base.Shoot(item, player, source, position, velocity, type, damage, knockback);
    }
        public override void UpdateEquip(Item item, Player player)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            #region Vanilla shields
            if (item.type >= ItemID.ApprenticeScarf && item.type <= ItemID.MonkBelt)
            {
                modPlayer.whichShield = 8;
                modPlayer.whichGuardSound = 5;
            }
            if (item.type == ItemID.CobaltShield)
            {
                modPlayer.whichShield = 9;
                modPlayer.whichGuardSound = 1;
            }
            if (item.type == ItemID.ObsidianShield)
            {
                modPlayer.whichShield = 10;
                modPlayer.whichGuardSound = 1;
            }
            if (item.type == ItemID.AnkhShield)
            {
                modPlayer.whichShield = 11;
                modPlayer.whichGuardSound = 4;
            }
            if (item.type == ItemID.PaladinsShield)
            {
                modPlayer.whichShield = 12;
                modPlayer.whichGuardSound = 6;
            }
            if (item.type == ItemID.HeroShield)
            {
                modPlayer.whichShield = 13;
                modPlayer.whichGuardSound = 6;
            }
            if (item.type == ItemID.FrozenShield)
            {
                modPlayer.whichShield = 14;
                modPlayer.whichGuardSound = 6;
            }
            #endregion
            #region Attack speed
            if (item.type == ItemID.FrostLeggings)
            {
                modPlayer.rangedSpeed += 0.1f;
            }
            if (item.type == ItemID.CelestialStone || item.type == ItemID.SunStone && Main.dayTime || item.type == ItemID.MoonStone && !Main.dayTime || item.type == ItemID.CelestialShell || item.type == ItemID.Gi || item.type == ItemID.CrystalNinjaLeggings)
            {
                player.GetAttackSpeed(DamageClass.Melee) -= 0.001f;
                modPlayer.universalSpeed += 0.1f;
                if (item.type == ItemID.CelestialShell && !Main.dayTime)
                {
                    player.GetAttackSpeed(DamageClass.Melee) -= 0.001f;
                    modPlayer.universalSpeed += 0.051f;
                }
            }
            if (item.type == ItemID.MoonCharm && !Main.dayTime || item.type == ItemID.MoonShell && !Main.dayTime)
            {
                player.GetAttackSpeed(DamageClass.Melee) -= 0.001f;
                modPlayer.universalSpeed += 0.051f;
            }
            #endregion
            #region Miscellaneous
            if (item.type == ItemID.SWATHelmet)
            {
                player.buffImmune[BuffID.Darkness] = true;
                player.buffImmune[BuffID.Blackout] = true;
                player.buffImmune[BuffID.Obstructed] = true;
            }
            #endregion
        }
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            Player player = Main.player[Main.myPlayer];
            //This is what is done in patches
            Conditions.IsCrimson conditionIsCrimson = new Conditions.IsCrimson();
            if (item.type == ItemID.KingSlimeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<ScavengedKunai>(), 4));
            }
            if (item.type == ItemID.EyeOfCthulhuBossBag)
            {
                itemLoot.Add(ItemDropRule.ByCondition(conditionIsCrimson, ItemType<HealingArrow>(), 1, 20, 50));
            }
            if (item.type == ItemID.QueenBeeBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<Beemerang>(), 3));
            }
            if (item.type == ItemID.WallOfFleshBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<ThrowerEmblem>(), 4));
            }
            if (item.type == ItemID.PlanteraBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<ThornyGlove>(), 3));
            }
            if (item.type == ItemID.GolemBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<GolemGlove>(), 4));
            }
            if (item.type == ItemID.FishronBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<RoyalFin>(), 1, 10, 15));
                itemLoot.Add(ItemDropRule.Common(ItemType<PoseironTrident>(), 4));
            }
            if (item.type == ItemID.BossBagBetsy)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<EtherianChakram>(), 4));
            }    
            if (item.type == ItemID.MoonLordBossBag)
            {
                itemLoot.Add(ItemDropRule.Common(ItemType<CosmosCrasher>(), 5));
                itemLoot.Add(ItemDropRule.Common(ItemType<SatelliteSpear>(), 5));
            }
        }
        public override void AddRecipes()
        {
            #region Shorebrass
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
            #endregion
            recipe = Recipe.Create(ItemID.MusketBall, 50);
            recipe.AddRecipeGroup("IronBar");
            recipe.AddIngredient(ModContent.ItemType<HerbalGunpowder>(), 1);
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
            recipe.AddIngredient(ItemID.Hook, 1);
            recipe.AddTile(TileID.Hellforge);
            recipe.Register();
            recipe = Recipe.Create(ItemID.AngelStatue, 1);
            recipe.AddIngredient(ItemID.StoneBlock, 50);
            recipe.AddTile(TileID.HeavyWorkBench);
            recipe.Register();
            recipe = Recipe.Create(ItemID.Code2, 1);
            recipe.AddIngredient(ItemID.Code1);
            recipe.AddRecipeGroup(nameof(ItemID.AdamantiteBar), 18);
            recipe.AddIngredient(ItemID.CompanionCube);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}