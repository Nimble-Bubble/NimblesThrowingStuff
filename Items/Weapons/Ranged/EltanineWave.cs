using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
//using System.Numerics;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class EltanineWave : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.damage = 79;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = 1;
            Item.knockBack = 6f;
			Item.shootSpeed = 16f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack)
		{
            Vector2 rotpoint = player.RotatedRelativePoint(player.MountedCenter);
			float tsunum109 = (float)Math.PI / 10f;
			Vector2 tsu13 = new Vector2(velocity.X, velocity.Y);
			//tsu13.Normalize();
			//tsu13 *= 40f;
			bool tsu10 = Collision.CanHit(rotpoint, 0, 0, rotpoint + tsu13, 0, 0);
			int numberProjectiles = 7;
            for (int tsunum111 = 0; tsunum111 < numberProjectiles; tsunum111++)
            {
                float tsunum112 = (float)tsunum111 - ((float)numberProjectiles - 1f) / 2f;
				Vector2 tsu14 = tsu13.RotatedBy(tsunum109 * tsunum112);
				if (!tsu10)
				{
					tsu14 -= tsu13;
				}
                Projectile.NewProjectile(Item.GetSource_FromThis(), new Vector2 (position.X + tsu14.X, position.Y + tsu14.Y), velocity, type, damage, Item.knockBack, player.whoAmI);
                //Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity, type, damage, Item.knockBack, player.whoAmI);
            }
        }
	}
}