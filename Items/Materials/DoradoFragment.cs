using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class DoradoFragment : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A shard of the Dragon's Head");
            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
		public override void SetDefaults()
        {
			Item.width = 14;
			Item.height = 14;
			Item.maxStack = 999;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = 9;
        }
	}
}
