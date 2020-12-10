using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class TheToothpick : ModItem
	{

		public override void SetDefaults() {
			item.damage = 12;
			item.useStyle = 5;
			item.useAnimation = 22;
			item.useTime = 22;
			item.knockBack = 4f;
			item.width = 36;
			item.height = 36;
			item.shoot = mod.ProjectileType("TheToothpickProj");
            item.shootSpeed = 4.5f;
			item.rare = ItemRarityID.Blue;
            item.noUseGraphic = true;
            item.noMelee = true;
			item.value = Item.sellPrice(silver: 54);
            item.melee = true;
			item.UseSound = SoundID.Item1;
		}
        public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DemoniteBar, 10);
            recipe.AddIngredient(ItemID.ShadowScale, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}