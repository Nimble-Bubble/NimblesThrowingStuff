using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

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
			item.damage = 30;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 32;
			item.useTime = 32;
			item.knockBack = 6.5f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Orange;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.melee = true;
			item.channel = true;
			item.shoot = ModContent.ProjectileType<GrowlingWyvernProj>();
			item.shootSpeed = 13f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<PaladinLance>(), 1);
			recipe.AddIngredient(ItemID.HellstoneBar, 10);
			recipe.AddIngredient(ItemID.Bone, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}