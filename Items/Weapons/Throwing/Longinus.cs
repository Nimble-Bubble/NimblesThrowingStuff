using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class Longinus : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("A star-spawning holy lance");   
        }

		public override void SetDefaults() 
		{
			item.damage = 48;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 22;
			item.useAnimation = 22;
			item.useStyle = 1;
			item.knockBack = 5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 23, 0, 0);
			item.rare = 5;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("LonginusProj");
			item.shootSpeed = 11f;
            item.mana = 13;
		}

		//public override void AddRecipes() 
		//{
			//ModRecipe recipe = new ModRecipe(mod);
			//recipe.AddIngredient(1225, 12);
            //recipe.AddIngredient(548, 5);
			//recipe.AddTile(TileID.MythrilAnvil);
			//recipe.SetResult(this);
			//recipe.AddRecipe();
		//}
	}
}