using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class GreenQurupecoFeather : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			// DisplayName.SetDefault("Vivid Bicolor Feather");
			/* Tooltip.SetDefault("These brilliant feathers freeze and get wet easily, but they are surprisingly fire-resistant."
				+"\nThey are said to come from a 'siren bird' which lures in fools and leaves them alight."); */
        }
		public override void SetDefaults()
        {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 0, 36, 0);
			Item.rare = ItemRarityID.Blue;
        }
	}
}
