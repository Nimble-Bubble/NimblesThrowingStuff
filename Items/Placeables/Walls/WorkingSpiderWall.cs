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
			item.width = 28;
			item.height = 28;
			item.useTime = 7;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 0, 20);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.createWall = 62;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(150, 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this, 4);
			recipe.AddRecipe();
            recipe = new ModRecipe(mod);
			recipe.AddIngredient(this, 4);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(150, 1);
			recipe.AddRecipe();
		}
	}
}