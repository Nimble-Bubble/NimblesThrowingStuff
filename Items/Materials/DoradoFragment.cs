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
            ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
		public override void SetDefaults()
        {
			item.width = 14;
			item.height = 14;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 9;
        }
	}
}
