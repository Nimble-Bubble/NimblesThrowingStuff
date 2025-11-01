using Terraria;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class EssenceOfBalance : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 8));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true;
			ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }
		public override void SetDefaults()
        {
			Item.width = 24;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = ItemRarityID.Cyan;
        }
	}
}
