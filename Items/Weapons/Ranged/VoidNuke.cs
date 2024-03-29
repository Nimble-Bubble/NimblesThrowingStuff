using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NimblesThrowingStuff.Projectiles.Ranged;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class VoidNuke : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Nuclear Void");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			// Tooltip.SetDefault("Fires powerful rockets");
		}

		public override void SetDefaults()
		{
			Item.damage = 110;
			Item.width = 66;
			Item.height = 28;
			Item.useTime = 18;
			Item.useAnimation = 18;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.value = Item.buyPrice(0, 50, 0, 0);
			Item.rare = ItemRarityID.Red;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Rocket;
			Item.UseSound = SoundID.Item38;
			Item.shoot = ProjectileID.VortexBeaterRocket;
            Item.knockBack = 8f;
			Item.shootSpeed = 15f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.RocketI)
            {
				Item.shoot = ModContent.ProjectileType<VoidRocket1>();
            }
			if (type == ProjectileID.RocketII)
			{
				Item.shoot = ModContent.ProjectileType<VoidRocket2>();
			}
			if (type == ProjectileID.RocketIII)
			{
				Item.shoot = ModContent.ProjectileType<VoidRocket3>();
			}
			if (type == ProjectileID.RocketIV)
            {
				Item.shoot = ModContent.ProjectileType<VoidRocket4>();
            }				
			else if (type >= 617 && type <= 712)
			{
				Item.shoot = ProjectileID.VortexBeaterRocket;
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentVortex, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}