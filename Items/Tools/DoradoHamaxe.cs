using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Tools
{
	public class DoradoHamaxe : ModItem
	{
		public override void SetDefaults() 
		{
			Item.damage = 60;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 7;
			Item.useAnimation = 28;
			Item.useStyle = 1;
			Item.knockBack = 7f;
			Item.value = Item.buyPrice(0, 25, 0, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.axe = 30;
            Item.hammer = 100;
            Item.tileBoost += 4;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LunarBar, 12);
            recipe.AddIngredient(ModContent.ItemType<DoradoFragment>(), 14);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}