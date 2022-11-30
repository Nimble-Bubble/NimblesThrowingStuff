using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class RedRathScale : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			DisplayName.SetDefault("Vermilion Scale");
			Tooltip.SetDefault("The heat-related properties of this scale make it a must-have for equipment crafting.");
        }
		public override void SetDefaults()
        {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 0, 29, 50);
			Item.rare = 2;
        }
	}
}
