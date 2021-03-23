using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Tools
{
	public class DoradoHamaxe : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 60;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 7;
			item.useAnimation = 28;
			item.useStyle = 1;
			item.knockBack = 7f;
			item.value = Item.buyPrice(0, 25, 0, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.axe = 30;
            item.hammer = 100;
            item.tileBoost += 4;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddIngredient(ModContent.ItemType<DoradoFragment>(), 14);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}