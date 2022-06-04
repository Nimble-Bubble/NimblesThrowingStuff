using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class BatFlesh : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A furry bit of bat skin");
        }
		public override void SetDefaults()
        {
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 0, 50, 0);
			Item.rare = 1;
        }
	}
}
