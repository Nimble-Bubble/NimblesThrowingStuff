using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Tools
{
	public class Crimtroll : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("While it's not the most appetizing bait out there, it sure is reliable.");
		}
		public override void SetDefaults() 
		{
			Item.width = 48;
			Item.height = 26;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = ItemRarityID.Blue;
            Item.bait = 15;
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
			recipe.AddIngredient(ItemID.CrimtaneBar, 12);
            recipe.AddIngredient(ItemID.TissueSample, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}