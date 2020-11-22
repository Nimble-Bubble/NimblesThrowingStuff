using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class ThrombusThruster : ModItem
	{

		public override void SetDefaults() {
			item.damage = 19;
			item.useStyle = 3;
			item.useAnimation = 13;
			item.useTime = 13;
			item.knockBack = 5.5f;
			item.width = 44;
			item.height = 44;
			item.scale = 1.1f;
			item.rare = ItemRarityID.Blue;
			item.value = Item.sellPrice(silver: 27);
            item.melee = true;
			item.UseSound = SoundID.Item1;
		}
				public override void AddRecipes()
		{
			//var recipe = new ModRecipe(mod);
			//recipe.AddIngredient(ItemID.CrimtaneBar, 8);
			//recipe.AddTile(TileID.Anvils);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		}
	}
}