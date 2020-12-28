using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Placeables.Blocks
{
	public class ProcellariteOre : ModItem
	{
		public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.useTime = 6;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.createTile = mod.TileType("ProcellariteOreTile");
            item.consumable = true;
            item.maxStack = 999;
		}
	}
}