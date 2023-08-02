using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class LagiacrusShell : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			// DisplayName.SetDefault("Shell-Shocker");
			/* Tooltip.SetDefault("Strange crystal protusions on this shell release electricity."
				+"\nIt is because of this electricity that this material is highly valued for crafting equipment."); */
        }
		public override void SetDefaults()
        {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 43, 50);
			Item.rare = ItemRarityID.Green;
        }
	}
}
