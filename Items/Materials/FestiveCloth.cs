using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class FestiveCloth : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A magical fabric taken from the jolly invaders");
        }
		public override void SetDefaults()
        {
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 4, 0, 0);
			item.rare = 8;
        }
	}
}
