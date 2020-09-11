using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class EmptyFlask : ModItem
	{
		public override void SetDefaults()
        {
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 0, 2, 0);
			item.rare = 3;
        }
	}
}
