using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class RoyalFin : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			// Tooltip.SetDefault("The hide of the sea's live plague is unsurprisingly powerful when it comes to weaponsmithery.");
        }
		public override void SetDefaults()
        {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = ItemRarityID.Yellow;
        }
	}
}
