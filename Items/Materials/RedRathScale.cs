using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class RedRathScale : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This beautiful Rathalos scale shines like a ruby");
        }
		public override void SetDefaults()
        {
			item.width = 18;
			item.height = 18;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 0, 29, 50);
			item.rare = 2;
        }
	}
}
