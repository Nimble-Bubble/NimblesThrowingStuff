using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ObsidianScalpel : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 20;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 25;
			item.useAnimation = 25;
			item.useStyle = 1;
			item.knockBack = 5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 1, 60);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ObsidianScalpelProj");
			item.shootSpeed = 9f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(173, 1);
			recipe.AddTile(77);
			recipe.SetResult(this, 20);
			recipe.AddRecipe();
		}
	}
}