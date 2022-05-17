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
	public class Longhorn : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Rough-hewn, but sturdy.");
        }
        public override void SetDefaults() {
			item.damage = 10;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.useAnimation = 28;
			item.useTime = 28;
			item.knockBack = 4f;
			item.width = 20;
			item.height = 20;
			item.noUseGraphic = true;
			item.noMelee = true;
			item.rare = ItemRarityID.White;
			item.value = Item.buyPrice(0, 0, 37, 50);
            item.melee = true;
            item.shoot = ModContent.ProjectileType<LonghornProj>();
            item.shootSpeed = 8f;
			item.UseSound = SoundID.Item1;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 20);
			recipe.AddIngredient(ModContent.ItemType<BeastBone>(), 5);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}