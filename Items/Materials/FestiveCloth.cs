using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class FestiveCloth : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A magical fabric taken from the jolly invaders");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 50;
		}
		public override void SetDefaults()
        {
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 4, 0, 0);
			Item.rare = 8;
        }
	}
}
