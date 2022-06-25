using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class MeteorSpear : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("An extremely agile exploding javelin");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 17;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 2, 0);
			Item.rare = 1;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("MeteorSpearProj").Type;
			Item.shootSpeed = 9f;
            Item.consumable = true;
            Item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(this.Type, 50);
			recipe.AddIngredient(117, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}