using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class FestiveEggnog : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Explodes into drops o' nog");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 80;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 60;
			Item.useAnimation = 60;
			Item.useStyle = 1;
			Item.knockBack = 0f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 20, 0, 0);
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("FestiveEggnogProj").Type;
			Item.shootSpeed = 8f;
            Item.mana = 18;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("FestiveCloth").Type, 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}