using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Tiles.Furniture;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class Autolantis : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 126;
			Item.width = 68;
			Item.height = 24;
			Item.useTime = 8;
			Item.useAnimation = 8;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(0, 72, 50, 0);
			Item.rare = ItemRarityID.Red;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.knockBack = 6f;
			Item.shootSpeed = 24f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
            int bonusseaarrow = Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity.RotatedByRandom(MathHelper.ToRadians(20)), ModContent.ProjectileType<SeastringArrowProj>(), damage, knockback, Main.myPlayer);
			Main.projectile[bonusseaarrow].penetrate = 5;
            Main.projectile[bonusseaarrow].extraUpdates = 1;
            if (Main.rand.NextBool(3))
			{
				int extraseaarrow = Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity * new Vector2(2, 2), ModContent.ProjectileType<SeastringArrowProj>(), damage * 2, knockback, Main.myPlayer);
                Main.projectile[extraseaarrow].penetrate = 10;
                Main.projectile[bonusseaarrow].extraUpdates = 2;
            }
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Autoquarian>(), 1);
			recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
			recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
			recipe.Register();
		}
	}
}