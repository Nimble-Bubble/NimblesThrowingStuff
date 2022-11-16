using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Tools
{
	public class ShorebrassPickaxe : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("This pickaxe is lightweight, yet powerful.");
		}
		public override void SetDefaults() 
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Melee;
			Item.width = 44;
			Item.height = 44;
			Item.useTime = 13;
			Item.useAnimation = 13;
			Item.useStyle = 1;
			Item.knockBack = 3f;
			Item.value = Item.buyPrice(0, 5, 0, 0);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.pick = 100;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ShorebrassBar>(), 12);
			recipe.AddIngredient(ItemID.HellstoneBar, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}