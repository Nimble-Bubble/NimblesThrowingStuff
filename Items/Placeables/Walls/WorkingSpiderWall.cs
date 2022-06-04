using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Placeables.Walls
{
	public class WorkingSpiderWall : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Works like a normal spider wall");   
        }

		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 7;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 0, 20);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.createWall = 62;
            Item.consumable = true;
            Item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(150, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 4);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(this, 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(150, 1);
			recipe.Register();
		}
	}
}