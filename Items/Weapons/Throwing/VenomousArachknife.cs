using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class VenomousArachknife : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("This knife sticks to enemies");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 48;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 32;
			Item.useAnimation = 32;
			Item.useStyle = 1;
			Item.knockBack = 8f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 16, 0, 0);
			Item.rare = 6;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("VenomousArachknifeProj").Type;
			Item.shootSpeed = 12f;
            Item.mana = 12;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("Arachknife").Type);
            recipe.AddIngredient(1006, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}