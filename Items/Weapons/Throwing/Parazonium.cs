using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class Parazonium : ModItem
	{

		public override void SetDefaults() 
		{
			item.damage = 57;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 7f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 23, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ParazoniumProj");
			item.shootSpeed = 13f;
            item.mana = 10;
		}

		//public override void AddRecipes() 
		//{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(1225, 12);
            //recipe.AddIngredient(549, 5);
			//recipe.AddTile(TileID.MythrilAnvil);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		//}
	}
}