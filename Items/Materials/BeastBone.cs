using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class BeastBone : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Bigger than human bones, but a bit clumsier to work with");
        }
		public override void SetDefaults()
        {
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 0, 7, 50);
			item.rare = 0;
        }
	}
}
