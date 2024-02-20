using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class HermitaurShell : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
		public override void SetDefaults()
        {
			Item.width = 24;
			Item.height = 22;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 27, 50);
			Item.rare = ItemRarityID.Blue;
        }
	}
}
