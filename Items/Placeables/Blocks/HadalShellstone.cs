using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Blocks;

namespace NimblesThrowingStuff.Items.Placeables.Blocks
{
	public class HadalShellstone : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("It's surprisingly bright down there. \nSo are the flames of hell, right?");
        }
        public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 0, 50);
			item.rare = 0;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.createTile = ModContent.TileType<HadalShellstoneTile>();
            item.consumable = true;
            item.maxStack = 999;
		}
	}
}