using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Blocks;

namespace NimblesThrowingStuff.Items.Placeables.Blocks
{
	public class ProcellariteOre : ModItem
	{
		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 2, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<ProcellariteOreTile>();
            Item.consumable = true;
            Item.maxStack = 999;
		}
	}
}