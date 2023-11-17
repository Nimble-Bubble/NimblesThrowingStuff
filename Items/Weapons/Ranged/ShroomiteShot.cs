using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ShroomiteShot : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("Fires four bullets at a time"
				+"\nRegular bullets are turned to chlorophyte bullets"); */
		}
		public override void SetDefaults()
		{
			Item.damage = 42;
			Item.width = 64;
			Item.height = 22;
			Item.useTime = 5;
			Item.useAnimation = 20;
			Item.reuseDelay = 10;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 45, 0, 0);
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item91;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 4f;
			Item.shootSpeed = 14f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (type == ProjectileID.Bullet)
            {
				type = ProjectileID.ChlorophyteBullet;
            }
			SoundEngine.PlaySound(SoundID.Item41);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddIngredient(ItemID.VenusMagnum);
			recipe.AddTile(247);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddTile(ItemID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 20);
			recipe.AddTile(247);
			recipe.Register();
		}
	}
}