using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Weapons.Melee;
using CsvHelper.TypeConversion;
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
			Item.damage = 73;
			Item.width = 38;
			Item.height = 86;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(1, 25, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Arrow;
			Item.UseSound = SoundID.Item5;
			Item.shoot = 1;
            Item.knockBack = 4f;
			Item.shootSpeed = 12f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2 (-4, 0);
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockBack)
		{
			//Based on how the vanilla Tsunami did it
            Vector2 rotpoint = player.RotatedRelativePoint(player.MountedCenter);
			float tsunum109 = (float)Math.PI / 10f;
			Vector2 tsu13 = new Vector2(velocity.X, velocity.Y);
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
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
            recipe.AddIngredient(ItemID.Tsunami);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}