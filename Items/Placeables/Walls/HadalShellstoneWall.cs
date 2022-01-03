using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Placeables.Walls
{
	public class HadalShellstoneWall : ModItem
	{
		public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.useTime = 7;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 0, 12);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.createWall = mod.WallType("HadalShellstoneWallTile");
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("HadalShellstone"), 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
			recipe.AddIngredient(this, 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(mod.ItemType("HadalShellstone"), 1);
			recipe.AddRecipe();
		}
	}
}