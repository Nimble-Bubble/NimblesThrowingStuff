using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Tools
{
	public class ProcellariteHamaxe : ModItem
	{
		public override void SetDefaults() 
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Melee;
			Item.width = 54;
			Item.height = 52;
			Item.useTime = 5;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 8f;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = 11;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
            Item.axe = 40;
            Item.hammer = 125;
            Item.tileBoost += 6;
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}