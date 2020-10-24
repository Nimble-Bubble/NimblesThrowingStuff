using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class DoradoBomb : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Dragon's Chips");
         Tooltip.SetDefault("Explodes into a storm of draconic shrapnel");   
        }

		public override void SetDefaults() 
		{
			item.damage = 90;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 36;
			item.useAnimation = 36;
			item.useStyle = 1;
			item.knockBack = 12f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 50, 0, 0);
			item.rare = 10;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("DoradoBombProj");
			item.shootSpeed = 11f;
            item.mana = 24;
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("DoradoFragment"), 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}