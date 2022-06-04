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
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 4, 0, 0);
			Item.rare = 8;
        }
	}
}
