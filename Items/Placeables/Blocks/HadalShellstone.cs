using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Blocks;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Blocks
{
	public class HadalShellstone : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100;
			DisplayName.SetDefault("Deep Shellstone");
			Tooltip.SetDefault("Formed from a mixture of minerals and remains, this material has a remarkable deep tone to it.");
        }
        public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 0, 50);
			Item.rare = 0;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<HadalShellstoneTile>();
            Item.consumable = true;
            Item.maxStack = 9999;
		}
	}
}