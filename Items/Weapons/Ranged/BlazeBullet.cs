using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class BlazeBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
			Tooltip.SetDefault("Sets enemies on fire");
        }
        public override void SetDefaults() {
			item.damage = 10;
			item.ranged = true;
			item.width = 8;
			item.height = 8;
			item.maxStack = 999;
			item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			item.knockBack = 5f;
			item.value = 25;
			item.rare = ItemRarityID.Green;
			item.shoot = ModContent.ProjectileType<BlazeBulletProj>();   //The projectile shoot when your weapon using this ammo
			item.shootSpeed = 6f;                  //The speed of the projectile
			item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}
        public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 1);
            recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.AddRecipe();
		}
	}
}