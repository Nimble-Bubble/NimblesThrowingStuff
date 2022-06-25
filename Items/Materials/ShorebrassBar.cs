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
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 2, 50, 0);
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<ShorebrassBarTile>();
            Item.consumable = true;
            Item.maxStack = 999;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(this.Type, 3);
			recipe.AddIngredient(ItemID.Bone, 2);
			recipe.AddIngredient(ItemID.Coral, 1);
			recipe.AddIngredient(ItemID.CopperBar, 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
			recipe = CreateRecipe(this.Type, 3);
			recipe.AddIngredient(ItemID.Bone, 2);
			recipe.AddIngredient(ItemID.Coral, 1);
			recipe.AddIngredient(ItemID.TinBar, 2);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}