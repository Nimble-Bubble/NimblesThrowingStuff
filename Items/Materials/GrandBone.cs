using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Materials
{
	public class GrandBone : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
			DisplayName.SetDefault("Heavy Grandbone");
			Tooltip.SetDefault("This bone is like an ant in its strength."
				+"\nJust a few of these bones can be enough to hold a structure.");
        }
		public override void SetDefaults()
        {
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.value = Item.buyPrice(0, 3, 25, 0);
			Item.rare = 9;
        }
	}
}
