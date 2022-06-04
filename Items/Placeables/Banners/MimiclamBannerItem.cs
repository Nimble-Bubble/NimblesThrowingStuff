using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Tiles.Banners;

namespace NimblesThrowingStuff.Items.Placeables.Banners
{
	public class MimiclamBannerItem : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Clam Banner");
		}
		public override void SetDefaults() 
		{
			Item.width = 28;
			Item.height = 28;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = 1;
			Item.value = Item.buyPrice(0, 0, 10, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.useTurn = true;
            Item.createTile = ModContent.TileType<MimiclamBanner>();
            Item.consumable = true;
            Item.maxStack = 999;
		}
	}
}