using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Tiles.Blocks;

namespace NimblesThrowingStuff.Items.Materials
{
	public class ShorebrassBar : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("This unusual brass-steel-coral hybrid makes for a surprisingly good alloy.");
        }
        public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 2, 50, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.createTile = ModContent.TileType<ShorebrassBarTile>();
            item.consumable = true;
            item.maxStack = 999;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 2);
			recipe.AddIngredient(ItemID.Coral, 1);
			recipe.AddIngredient(ItemID.CopperBar, 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
			recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 2);
			recipe.AddIngredient(ItemID.Coral, 1);
			recipe.AddIngredient(ItemID.TinBar, 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.SetResult(this, 3);
			recipe.AddRecipe();
		}
	}
}