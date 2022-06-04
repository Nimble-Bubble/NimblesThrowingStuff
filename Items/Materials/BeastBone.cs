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
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 0, 7, 50);
			Item.rare = 0;
        }
	}
}
