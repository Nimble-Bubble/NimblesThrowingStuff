using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class EmptyFlask : ModItem
	{
		public override void SetDefaults()
        {
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 0, 2, 0);
			Item.rare = 3;
        }
	}
}
