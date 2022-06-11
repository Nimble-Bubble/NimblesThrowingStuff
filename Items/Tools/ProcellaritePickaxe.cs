using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Tools
{
	public class ProcellaritePickaxe : ModItem
	{
		public override void SetDefaults() 
		{
			Item.damage = 100;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 4;
			Item.useAnimation = 10;
			Item.useStyle = 1;
			Item.knockBack = 6f;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.pick = 300;
            Item.tileBoost += 6;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}