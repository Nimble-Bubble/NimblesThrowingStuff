using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class StingerDagger : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Has a chance to poison enemies");   
        }

		public override void SetDefaults() 
		{
			item.damage = 18;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 2, 70, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("StingerDaggerProj");
			item.shootSpeed = 12f;
            item.mana = 10;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(331, 6);
            recipe.AddIngredient(209, 6);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}