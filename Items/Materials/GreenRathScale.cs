using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class GreenRathScale : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			// DisplayName.SetDefault("Vermilion Scale");
			// Tooltip.SetDefault("The heat-related properties of this scale make it a must-have for equipment crafting.");
        }
		public override void SetDefaults()
        {
			Item.width = 22;
			Item.height = 22;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 29, 50);
			Item.rare = ItemRarityID.Green;
        }
	}
}
