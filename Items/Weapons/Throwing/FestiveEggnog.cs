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
			item.damage = 80;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 60;
			item.useAnimation = 60;
			item.useStyle = 1;
			item.knockBack = 0f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 20, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("FestiveEggnogProj");
			item.shootSpeed = 8f;
            item.mana = 18;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("FestiveCloth"), 8);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}