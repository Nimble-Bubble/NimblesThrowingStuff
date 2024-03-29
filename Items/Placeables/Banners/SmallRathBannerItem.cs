using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Banners;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Banners
{
	public class SmallRathBannerItem : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Small Rathwyvern Banner");
		}
		public override void SetDefaults() 
		{
			Item.width = 10;
			Item.height = 24;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 10, 0);
			Item.rare = ItemRarityID.Blue;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<SmallRathBanner>();
            Item.consumable = true;
            Item.maxStack = 9999;
			Item.noUseGraphic = true;
		}
	}
}