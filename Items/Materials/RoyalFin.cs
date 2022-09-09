using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class RoyalFin : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The hide of the sea's live plague is unsurprisingly powerful when it comes to weaponsmithery.");
        }
		public override void SetDefaults()
        {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = 8;
        }
	}
}
