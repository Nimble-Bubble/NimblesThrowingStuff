using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class FestiveCloth : ModItem
	{
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("A magical fabric taken from the jolly invaders");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
		}
		public override void SetDefaults()
        {
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 4, 0, 0);
			Item.rare = ItemRarityID.Yellow;
        }
		public override void AddRecipes()
		{
			Recipe recipe = Recipe.Create(ItemID.Present, 10);
			recipe.AddIngredient(this);
			recipe.AddTile(TileID.Loom);
			recipe.Register();
			Recipe recipe2 = Recipe.Create(ItemID.GoodieBag, 15);
			recipe2.AddIngredient(ItemID.SpookyWood, 2);
			recipe2.AddIngredient(this);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.Register();
		}
	}
}
