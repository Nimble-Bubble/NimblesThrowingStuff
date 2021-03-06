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
			item.damage = 62;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 12;
			item.useAnimation = 12;
			item.useStyle = 1;
			item.knockBack = 6.5f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 0, 20, 0);
			item.rare = 7;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("RustyBonesAxeProj");
			item.shootSpeed = 14f;
            item.consumable = true;
            item.maxStack = 999;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(3261, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}