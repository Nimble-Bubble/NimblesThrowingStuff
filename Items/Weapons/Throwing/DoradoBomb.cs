using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class DoradoBomb : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Dragon's Grenade");
         Tooltip.SetDefault("Explodes into a storm of draconic shrapnel");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 90;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 36;
			Item.useAnimation = 36;
			Item.useStyle = 1;
			Item.knockBack = 12f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = 10;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("DoradoBombProj").Type;
			Item.shootSpeed = 11f;
            Item.mana = 24;
		}
		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("DoradoFragment").Type, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}