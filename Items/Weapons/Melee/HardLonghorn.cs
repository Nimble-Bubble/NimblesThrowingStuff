using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class HardLonghorn : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Adding in extra bone has given this lance a more painful tip.");
        }
        public override void SetDefaults() {
			item.damage = 14;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.knockBack = 6f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.White;
			item.value = Item.buyPrice(0, 0, 0, 75);
            item.melee = true;
			item.channel = true;
            item.shoot = ModContent.ProjectileType<HardLonghornProj>();
            item.shootSpeed = 8f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RottenChunk, 10);
			recipe.AddIngredient(ModContent.ItemType<Longhorn>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Vertebrae, 10);
			recipe.AddIngredient(ModContent.ItemType<Longhorn>());
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}