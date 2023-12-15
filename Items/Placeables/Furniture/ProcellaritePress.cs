using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Furniture;
using NimblesThrowingStuff.Items.Placeables.Blocks;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Furniture
{
	public class ProcellaritePress : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
        }
        public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<ProcellaritePressTile>();
            Item.consumable = true;
            Item.maxStack = 9999;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilAnvil);
			recipe.AddIngredient(ItemID.AdamantiteForge);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteOre>(), 75);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.OrichalcumAnvil);
			recipe.AddIngredient(ItemID.AdamantiteForge);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteOre>(), 75);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MythrilAnvil);
			recipe.AddIngredient(ItemID.TitaniumForge);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteOre>(), 75);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.OrichalcumAnvil);
			recipe.AddIngredient(ItemID.TitaniumForge);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteOre>(), 75);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}