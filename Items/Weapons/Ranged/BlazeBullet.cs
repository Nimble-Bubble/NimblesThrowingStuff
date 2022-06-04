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
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 5f;
			Item.value = 25;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<BlazeBulletProj>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 6f;                  //The speed of the projectile
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 1);
            recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 50);
			recipe.Register();
		}
	}
}