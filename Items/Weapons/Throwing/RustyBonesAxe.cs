using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class RustyBonesAxe : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Rustbone Hatchet");
            Tooltip.SetDefault("Accelerates beyond perceptions and envenoms enemies for some reason");
        }

		public override void SetDefaults() 
		{
			Item.damage = 62;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 6.5f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 0, 20, 0);
			Item.rare = 7;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("RustyBonesAxeProj").Type;
			Item.shootSpeed = 14f;
            Item.consumable = true;
            Item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(this.Type, 50);
			recipe.AddIngredient(3261, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}