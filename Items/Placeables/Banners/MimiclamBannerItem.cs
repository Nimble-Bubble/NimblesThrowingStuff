using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Placeables.Banners
{
	public class MimiclamBannerItem : ModItem
	{
        public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mimiclam Banner");
		}
		public override void SetDefaults() 
		{
			item.width = 28;
			item.height = 28;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.useTurn = true;
            item.createTile = mod.TileType("MimiclamBanner");
            item.consumable = true;
            item.maxStack = 999;
		}
	}
}