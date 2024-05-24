using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using NimblesThrowingStuff.Tiles.Blocks;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class HerbalGunpowder : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			// Tooltip.SetDefault("A dangerous chemical that explodes when disturbed or heated.");
        }
        public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 24;
			Item.value = Item.buyPrice(0, 2, 50, 0);
			Item.rare = ItemRarityID.Orange;
            Item.maxStack = 9999;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.VileMushroom, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.ViciousMushroom, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
			recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.VileMushroom, 1);
			recipe.AddIngredient(ItemID.BottledHoney, 3);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.Register();
			recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.Fireblossom, 1);
			recipe.AddIngredient(ItemID.ViciousMushroom, 1);
			recipe.AddIngredient(ItemID.BottledHoney, 3);
			recipe.AddTile(TileID.AlchemyTable);
			recipe.Register();
		}
	}
}