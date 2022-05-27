using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class PaladinLance : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Paladin Lance");
			Tooltip.SetDefault("A powerful and heavy lance known for its presence on the battlefield.");
		}
		public override void SetDefaults()
		{
			item.damage = 21;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 32;
			item.useTime = 32;
			item.knockBack = 6f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.Blue;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.melee = true;
			item.channel = true;
			item.shoot = ModContent.ProjectileType<PaladinLanceProj>();
			item.shootSpeed = 11f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<IronLance>(), 1);
			recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ItemID.Sapphire, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.MeteoriteBar, 20);
			recipe.AddIngredient(ItemID.TissueSample, 5);
			recipe.AddIngredient(ItemID.Ruby, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}