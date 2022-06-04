using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class SporeSling : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Fires several stingers along with your arrow");
		}

		public override void SetDefaults()
		{
			Item.damage = 17;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(0, 2, 70, 0);
			Item.rare = ItemRarityID.Green;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.knockBack = 6f;
			Item.shootSpeed = 7f;
			Item.DamageType = DamageClass.Ranged;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
            int numberProjectiles = 3; 
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 stingerSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(30)); 
				int stinger = Projectile.NewProjectile(position, stingerSpeed, ProjectileID.HornetStinger, damage / 3, knockBack, player.whoAmI);
                Main.projectile[stinger].minion = false;
                Main.projectile[stinger].ranged = true;
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.JungleSpores, 12);
			recipe.AddIngredient(ItemID.Stinger, 12);
            recipe.AddIngredient(ItemID.Vine, 2);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.Register();
		}
	}
}