using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Tiles.Blocks;

namespace NimblesThrowingStuff.Items.Materials
{
	public class ProcellariteBar : ModItem
	{
		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<ProcellariteBarTile>();
            Item.consumable = true;
            Item.maxStack = 999;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ProcellariteOre>(), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}