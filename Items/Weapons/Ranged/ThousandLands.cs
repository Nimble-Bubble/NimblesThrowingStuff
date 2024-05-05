using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Items.Materials;
using NimblesThrowingStuff.Tiles.Furniture;
using Terraria.DataStructures;

namespace NimblesThrowingStuff.Items.Weapons.Ranged
{
	public class ThousandLands : ModItem
	{
		private bool penAdd;
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults()
		{
			Item.damage = 340;
			Item.width = 34;
			Item.height = 54;
			Item.useTime = 64;
			Item.useAnimation = 64;
			Item.useStyle = 5;
			Item.value = Item.buyPrice(0, 50, 25, 0);
			Item.rare = ItemRarityID.Red;
			Item.noMelee = true;
			Item.useAmmo = AmmoID.Bullet;
			Item.UseSound = SoundID.Item38;
			Item.shoot = ProjectileID.Bullet;
            Item.knockBack = 2f;
			Item.shootSpeed = 24f;
			Item.DamageType = DamageClass.Ranged;
			Item.autoReuse = true;
			penAdd = false;
		}
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			int warpWarp = Projectile.NewProjectile(Item.GetSource_FromThis(), position, velocity, type, damage, knockback, Main.myPlayer);
			if (!penAdd && Main.projectile[warpWarp].penetrate >= 1)
			{
			Main.projectile[warpWarp].penetrate += 10;
			}
			Main.projectile[warpWarp].extraUpdates += 1;
			Main.projectile[warpWarp].usesLocalNPCImmunity = true;
			Main.projectile[warpWarp].localNPCHitCooldown = 5;
			return false;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Musket);
			recipe.AddIngredient(ItemID.SniperRifle);
			recipe.AddIngredient(ItemID.MoltenFury, 2);
			recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
			recipe.Register();
		}
        public override Vector2? HoldoutOffset()
		{
			return new Vector2(0, -4);
		}
	}
}