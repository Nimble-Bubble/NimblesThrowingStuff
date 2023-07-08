using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class SoulOfTrite : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			// Tooltip.SetDefault("The essence of what lies above");
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
		public override void SetDefaults()
        {
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 2, 50, 0);
			Item.rare = ItemRarityID.Cyan;
        }
	}
}
