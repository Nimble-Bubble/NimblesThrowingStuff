using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Trophies;

namespace NimblesThrowingStuff.Items.Placeables.Furniture
{
	public class MorilusTrophy : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("A chip of such power could only be encased in the finest of forbidden cheese.");
        }
        public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.createTile = ModContent.TileType<MorilusTrophyTile>();
            item.consumable = true;
            item.maxStack = 999;
		}
	}
}