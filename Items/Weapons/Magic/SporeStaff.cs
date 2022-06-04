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
            Item.staff[Item.type] = true;
		}

		public override void SetDefaults() 
		{
			Item.damage = 16;
			Item.DamageType = DamageClass.Magic;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.useStyle = 5;
			Item.knockBack = 2f;
            Item.noMelee = true;
			Item.value = Item.buyPrice(0, 2, 70, 0);
			Item.rare = 2;
			Item.UseSound = SoundID.Item43;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<SporeBolt>();
			Item.shootSpeed = 3f;
            Item.mana = 10;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(331, 12);
            recipe.AddIngredient(209, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}