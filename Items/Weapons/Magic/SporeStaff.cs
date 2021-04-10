using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Magic;

namespace NimblesThrowingStuff.Items.Weapons.Magic
{
	public class SporeStaff : ModItem
	{
        public override void SetStaticDefaults()
		{
            Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.damage = 16;
			item.magic = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 5;
			item.knockBack = 2f;
            item.noMelee = true;
			item.value = Item.buyPrice(0, 2, 70, 0);
			item.rare = 2;
			item.UseSound = SoundID.Item43;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<SporeBolt>();
			item.shootSpeed = 3f;
            item.mana = 10;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(331, 12);
            recipe.AddIngredient(209, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}