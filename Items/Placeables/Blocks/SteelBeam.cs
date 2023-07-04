using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Blocks;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Blocks
{
	public class SteelBeam : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			Tooltip.SetDefault("A sturdy building material");
		}
		public override void SetDefaults() 
		{
			Item.width = 16;
			Item.height = 16;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 0, 50);
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<SteelBeamTile>();
            Item.consumable = true;
            Item.maxStack = 9999;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(10);
			recipe.AddRecipeGroup("IronBar");
			recipe.AddTile(17);
			recipe.Register();
		}
	}
}