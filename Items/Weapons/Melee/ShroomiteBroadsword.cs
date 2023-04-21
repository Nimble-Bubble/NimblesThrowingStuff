using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class ShroomiteBroadsword : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
			Item.damage = 68;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.knockBack = 5f;
			Item.width = 72;
			Item.height = 72;
			Item.scale = 1.2f;
			Item.rare = ItemRarityID.Yellow;
			Item.value = Item.buyPrice(0, 37, 50, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<ShroomiteSporeCloud>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(2)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 41);
			}
		}
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			float numberProjectiles = 2; 
			float rotation = MathHelper.ToRadians(15);
			position += Vector2.Normalize(velocity) * 5f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 0.8f; 
				Projectile.NewProjectile(Item.GetSource_FromThis(), position, perturbedSpeed, type, damage / 3, Item.knockBack, player.whoAmI);	
			}
			damage /= 2;
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}