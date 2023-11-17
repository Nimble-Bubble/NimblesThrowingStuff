using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class ShockLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Shock Lance");
			/* Tooltip.SetDefault("High voltage gives this blade an electric touch."
				+"\nRight click to fire an electric beam."); */
		}
		public override void SetDefaults()
		{
			Item.damage = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 3f;
			Item.width = 56;
			Item.height = 56;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 6, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<ShockLanceProj>();
			Item.shootSpeed = 10f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Estoc>(), 1);
			recipe.AddRecipeGroup(nameof(ItemID.DemoniteBar), 10);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ItemID.Leather, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddRecipeGroup(nameof(ItemID.DemoniteBar), 10);
			recipe.AddRecipeGroup("Fireflies", 10);
			recipe.AddIngredient(ItemID.Leather, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}