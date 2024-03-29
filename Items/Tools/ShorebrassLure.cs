using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Tools
{
	public class ShorebrassLure : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.width = 38;
			Item.height = 38;
			Item.value = Item.buyPrice(0, 12, 50, 0);
			Item.rare = ItemRarityID.Orange;
            Item.bait = 25;
			Item.consumable = false;
			Item.maxStack = 1;
		}
		public override bool? CanConsumeBait(Player player)
        {
			return false;
        }
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Demonnow>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
			recipe.AddIngredient(ModContent.ItemType<Crimtroll>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}