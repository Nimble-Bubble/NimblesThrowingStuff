using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.DataStructures;
using System;

namespace NimblesThrowingStuff.Items.Weapons.Ranged.Ammo
{
	public class Snakeshot : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }
        public override void SetDefaults() {
			Item.damage = 3; //Weak additional damage just so the result of multiple bullet projectiles isn't too strong
			Item.DamageType = DamageClass.Ranged;
			Item.width = 16;
			Item.height = 30;
			Item.maxStack = 9999;
			Item.consumable = true;             
			Item.knockBack = 1f;
			Item.value = 50;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ProjectileID.Bullet;   
			Item.shootSpeed = 4f;                  
			Item.ammo = AmmoID.Bullet;              
		}
		//This doesn't seem to be working right at the moment
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack)
		{
			int halfDamage = damage / 2;
			Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
			for (int i = 0; i < 4; i++)
			{
				Projectile.NewProjectile(Item.GetSource_FromThis(), position, newVelocity, type, halfDamage, knockBack, Main.myPlayer);
			}
		}
        public override void AddRecipes() 
		{
			/* Recipe recipe = CreateRecipe(50);
			recipe.AddIngredient(ItemID.MusketBall, 50);
            recipe.AddIngredient(ItemID.Stinger, 1);
			recipe.AddTile(TileID.Anvils);
			recipe.Register(); */
		}
	}
}