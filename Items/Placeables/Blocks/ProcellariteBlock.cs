using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Blocks;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Blocks
{
	public class ProcellariteBlock : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
		}
		public override void SetDefaults() 
		{
			Item.width = 16;
			Item.height = 16;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 10, 0);
			Item.rare = 9;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<ProcellariteBlockTile>();
            Item.consumable = true;
            Item.maxStack = 9999;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(25);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteOre>());
			recipe.AddTile(TileID.AdamantiteForge);
			recipe.Register();
		}
	}
}