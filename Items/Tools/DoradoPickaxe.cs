using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Tools
{
	public class DoradoPickaxe : ModItem
	{
		public override void SetDefaults() 
		{
			item.damage = 80;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 6;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 5.5f;
			item.value = Item.buyPrice(0, 35, 0, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.pick = 225;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(mod.ItemType("DoradoFragment"), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}