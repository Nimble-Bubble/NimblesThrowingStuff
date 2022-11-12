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
	public class FuriousFalchion : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() {
			Item.damage = 135;
			Item.useStyle = 1;
			Item.useAnimation = 17;
			Item.useTime = 17;
			Item.knockBack = 6.5f;
			Item.width = 80;
			Item.height = 80;
			Item.scale = 1.6f;
			Item.rare = 10;
			Item.value = Item.buyPrice(0, 50, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<FuriousBeam>();
            Item.shootSpeed = 6f;
			Item.UseSound = SoundID.Item1;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(3)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 174);
			}
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
      float numberProjectiles = 3; 
			float rotation = MathHelper.ToRadians(10);
			position += Vector2.Normalize(velocity) * 6f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 2f; 
				Projectile.NewProjectile(Item.GetSource_FromThis(), position, perturbedSpeed, type, damage / 2, Item.knockBack, player.whoAmI);
			}
        }
        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentSolar, 18);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}