using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Materials
{
	public class SoulOfTrite : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The essense of what lies above");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[item.type] = true;
			ItemID.Sets.ItemIconPulse[item.type] = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
        }
		public override void SetDefaults()
        {
			item.width = 26;
			item.height = 26;
			item.maxStack = 999;
			item.value = Item.buyPrice(0, 2, 50, 0);
			item.rare = ItemRarityID.Cyan;
        }
	}
}
