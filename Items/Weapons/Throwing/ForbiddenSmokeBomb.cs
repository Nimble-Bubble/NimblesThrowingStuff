using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ForbiddenSmokeBomb : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Explodes into a forbidden storm");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 40;
			Item.useAnimation = 40;
			Item.useStyle = 1;
			Item.knockBack = 10f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 10, 0, 0);
			Item.rare = 5;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("ForbiddenSmokeBombProj").Type;
			Item.shootSpeed = 10f;
            Item.mana = 16;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(3783, 1);
            recipe.AddIngredient(1198, 13);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.Register();
            recipe = CreateRecipe();
			recipe.AddIngredient(3783, 1);
            recipe.AddIngredient(391, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}