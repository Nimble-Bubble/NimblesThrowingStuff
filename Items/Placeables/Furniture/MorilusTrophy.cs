using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Trophies;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Furniture
{
	public class MorilusTrophy : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
			// Tooltip.SetDefault("A chip of such power could only be encased in the finest of forbidden cheese.");
        }
        public override void SetDefaults() 
		{
			Item.width = 24;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Purple;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<MorilusTrophyTile>();
            Item.consumable = true;
            Item.maxStack = 9999;
		}
	}
}