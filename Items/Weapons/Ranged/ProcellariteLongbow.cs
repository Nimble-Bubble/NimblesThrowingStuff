using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ProcellariteLongbow : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// DisplayName.SetDefault("Pain Rain");
			// Tooltip.SetDefault("Rains several arrows down from the heavens(?)");
		}

		public override void SetDefaults()
		{
			Item.damage = 110;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 16;
			Item.useAnimation = 16;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(1, 0, 0, 0);
			Item.rare = ItemRarityID.Purple;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = 1;
            Item.knockBack = 6f;
			Item.shootSpeed = 21f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack)
		{
			int numberProjectiles = 2 + Main.rand.Next(2);  
			for (int index = 0; index < numberProjectiles; ++index)
			{
				Vector2 vector2_1 = new Vector2((float)(player.Center.X + (Main.rand.Next(201) * -player.direction) + Main.mouseX + Main.screenPosition.X - player.position.X), player.Center.Y - 600f);   //this defines the projectile width, direction and position
				vector2_1.X = ((vector2_1.X + player.Center.X) / 2f) + Main.rand.NextFloat(-200, 200);
				vector2_1.Y -= (float)(100 * index);
				float num12 = Main.mouseX + Main.screenPosition.X - vector2_1.X;
				float num13 = Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
				if (num13 < 0f)
				{
					num13 *= -1f;
				}
				if (num13 < 20f)
				{
					num13 = 20f;
				}
				float num14 = new Vector2(num12, num13).Length();
				float num15 = Item.shootSpeed / num14;
				float num15b = num15 / 2;
				float num16 = num12 * num15b;
				float num17 = num13 * num15b;
				Vector2 Speed = new Vector2(num16 + Main.rand.NextFloat(-40, 40) * 0.03f, num17 + Main.rand.NextFloat(-40, 40) * 0.03f);  
				Projectile.NewProjectile(Item.GetSource_FromThis(), vector2_1, Speed, type, damage, knockBack, Main.myPlayer, 0f, (float)Main.rand.Next(5));
			}
			Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity * new Vector2 (2, 2), type, damage, knockBack, Main.myPlayer, 0f, (float)Main.rand.Next(5));
		}
	}
}