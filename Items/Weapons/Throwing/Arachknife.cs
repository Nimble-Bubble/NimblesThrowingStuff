using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Throwing;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class Arachknife : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("This knife sticks to enemies");   
        }

		public override void SetDefaults() 
		{
			item.damage = 32;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 0f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 8, 0, 0);
			item.rare = 4;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<ArachknifeProj>();
			item.shootSpeed = 10f;
            item.mana = 8;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(2607, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}