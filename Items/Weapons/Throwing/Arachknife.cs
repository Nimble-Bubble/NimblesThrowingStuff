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
			Item.damage = 32;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = 1;
			Item.knockBack = 0f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 8, 0, 0);
			Item.rare = 4;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<ArachknifeProj>();
			Item.shootSpeed = 10f;
            Item.mana = 8;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(2607, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}