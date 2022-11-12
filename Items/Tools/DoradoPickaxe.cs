using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Tools
{
	public class DoradoPickaxe : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 6;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 5.5f;
			Item.value = Item.buyPrice(0, 35, 0, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.pick = 225;
            Item.tileBoost += 4;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddIngredient(ModContent.ItemType<DoradoFragment>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}