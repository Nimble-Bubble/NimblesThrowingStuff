using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class GrowlingWyvern : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Growling Wyvern");
			Tooltip.SetDefault("A drill-like lance that pierces into the veins of fiends."
				+"\nMay cause bleeding.");
		}
		public override void SetDefaults()
		{
			Item.damage = 30;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 32;
			Item.useTime = 32;
			Item.knockBack = 6.5f;
			Item.width = 20;
			Item.height = 20;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<GrowlingWyvernProj>();
			Item.shootSpeed = 13f;
			Item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<PaladinLance>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}