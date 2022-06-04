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
			Item.damage = 18;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.useStyle = 1;
			Item.knockBack = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 2, 70, 0);
			Item.rare = 2;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("StingerDaggerProj").Type;
			Item.shootSpeed = 12f;
            Item.mana = 10;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(331, 12);
            recipe.AddIngredient(209, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}