using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class HealingArrow : ModItem
	{

		public override void SetDefaults() {
			Item.damage = 7;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 8;
			Item.height = 8;
			Item.maxStack = 999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 3.5f;
			Item.value = 45;
			Item.rare = 1;
			Item.shoot = ModContent.ProjectileType<HealingArrowProj>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 4f;                  //The speed of the projectile
			Item.ammo = AmmoID.Arrow;              //The ammo class this ammo belongs to.
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(40, 5);
            recipe.AddIngredient(1330);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 5);
			recipe.Register();
		}
	}
}