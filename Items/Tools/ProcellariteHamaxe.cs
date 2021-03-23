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
			item.damage = 80;
			item.melee = true;
			item.width = 54;
			item.height = 52;
			item.useTime = 5;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 8f;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.axe = 40;
            item.hammer = 125;
            item.tileBoost += 6;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}