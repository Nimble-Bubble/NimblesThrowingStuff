using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class BrimstoneBomb : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Explodes into hellish shrapnel");   
        }

		public override void SetDefaults() 
		{
			item.damage = 30;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 1;
			item.knockBack = 9f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 2, 70, 0);
			item.rare = 3;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("BrimstoneBombProj");
			item.shootSpeed = 8.5f;
            item.mana = 13;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(175, 15);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}