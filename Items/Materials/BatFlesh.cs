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
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 0, 50, 0);
			item.rare = 1;
        }
	}
}
