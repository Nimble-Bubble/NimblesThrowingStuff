using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class KnightLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("Made with valuable ores, this lance can slice and thrust."
				+"\nRight click to swing like a sword."); */
		}
		public override void SetDefaults()
		{
			Item.damage = 47;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 26;
			Item.useTime = 26;
			Item.knockBack = 6.5f;
			Item.width = 76;
			Item.height = 76;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.LightRed;
			Item.value = Item.buyPrice(0, 15, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<KnightLanceProj>();
			Item.shootSpeed = 13f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1.15f;
		}
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
				Item.useStyle = ItemUseStyleID.Swing;
				Item.shoot = ProjectileID.None;
				Item.noUseGraphic = false;
				Item.noMelee = false;
            }
			else
            {
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.shoot = ModContent.ProjectileType<KnightLanceProj>();
				Item.noUseGraphic = true;
				Item.noMelee = true;
			}
			return base.CanUseItem(player);
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<GrowlingWyvern>(), 1);
			recipe.AddRecipeGroup(nameof(ItemID.CobaltBar), 12);
			recipe.AddIngredient(ItemID.CrystalShard, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalShard, 10);
			recipe.AddRecipeGroup(nameof(ItemID.CobaltBar), 18);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}