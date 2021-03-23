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
			item.damage = 100;
			item.melee = true;
			item.width = 48;
			item.height = 48;
			item.useTime = 4;
			item.useAnimation = 10;
			item.useStyle = 1;
			item.knockBack = 6f;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.rare = 11;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
            item.pick = 300;
            item.tileBoost += 6;
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}