using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Placeables.Walls
{
	public class HadalShellstoneWall : ModItem
	{
		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 7;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 0, 12);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.createWall = Mod.Find<ModWall>("HadalShellstoneWallTile").Type;
            Item.consumable = true;
            Item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(4);
			recipe.AddIngredient(Mod.Find<ModItem>("HadalShellstone").Type, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
            recipe = Recipe.Create(Mod.Find<ModItem>("HadalShellstone").Type, 1);
			recipe.AddIngredient(this, 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}