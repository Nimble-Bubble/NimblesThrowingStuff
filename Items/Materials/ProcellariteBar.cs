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
			item.width = 28;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 10, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.createTile = ModContent.TileType<ProcellariteBarTile>();
            item.consumable = true;
            item.maxStack = 999;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteOre>(), 5);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}