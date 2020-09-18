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
			item.damage = 17;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 19;
			item.useAnimation = 19;
			item.useStyle = 1;
			item.knockBack = 7f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(0, 2, 0, 0);
			item.rare = 1;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("MeteorSpearProj");
			item.shootSpeed = 9f;
            item.mana = 12;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(117, 20);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}