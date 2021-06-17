using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ProcellariteRepeater : ModItem
	{
		public override void SetDefaults()
		{
			item.damage = 68;
			item.width = 40;
			item.height = 40;
			item.useTime = 5;
			item.useAnimation = 6;
			item.useStyle = 5;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.rare = 11;
			item.noMelee = true;
			item.useAmmo = AmmoID.Arrow;
			item.UseSound = SoundID.Item5;
			item.shoot = 1;
            item.knockBack = 5f;
			item.shootSpeed = 38f;
			item.ranged = true;
		}
		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 10);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}