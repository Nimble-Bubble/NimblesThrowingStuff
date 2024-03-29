using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Banners;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Placeables.Banners
{
	public class KelbiBannerItem : ModItem
	{
        public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Kelbi Banner");
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
            Item.createTile = ModContent.TileType<KelbiBanner>();
            Item.consumable = true;
			Item.noUseGraphic = true;
            Item.maxStack = 9999;
		}
	}
}