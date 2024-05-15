using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged.Ammo
{
	public class ShroomiteBullet : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
			// Tooltip.SetDefault("Bounces on impact");
        }
        public override void SetDefaults() {
			Item.damage = 15;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 10;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.consumable = true;             //You need to set the item consumable so that the ammo would automatically consumed
			Item.knockBack = 4f;
			Item.value = 120;
			Item.rare = ItemRarityID.Yellow;
			Item.shoot = ModContent.ProjectileType<ShroomiteBulletProj>();   //The projectile shoot when your weapon using this ammo
			Item.shootSpeed = 8f;                  //The speed of the projectile
			Item.ammo = AmmoID.Bullet;              //The ammo class this ammo belongs to.
		}
        public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe(125);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 125);
            recipe.AddIngredient(ItemID.ShroomiteBar, 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe(125);
			recipe.AddIngredient(ItemID.ChlorophyteBullet, 125);
			recipe.AddIngredient(ItemID.ShroomiteBar, 1);
			recipe.AddTile(247);
			recipe.Register();
			recipe = CreateRecipe(200);
			recipe.AddIngredient(ItemID.ShroomiteBar, 2);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}