using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class BatFlesh : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			// Tooltip.SetDefault("A furry bit of bat skin");
        }
		public override void SetDefaults()
        {
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 50, 0);
			Item.rare = 1;
        }
	}
}
