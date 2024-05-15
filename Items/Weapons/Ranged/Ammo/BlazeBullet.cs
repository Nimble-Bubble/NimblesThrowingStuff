using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged.Ammo
{
	public class BlazeBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			// Tooltip.SetDefault("Sets enemies on fire");
        }
        public override void SetDefaults() {
			Item.damage = 10;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 26;
			Item.height = 26;
			Item.maxStack = 9999;
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
			Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 1);
            recipe.AddIngredient(ItemID.MusketBall, 50);
			recipe.Register();
		}
	}
}