using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Audio;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class FlameBlessedBroadsword : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Flame-Blessed Broadsword");
			Tooltip.SetDefault("Fires a flaming sword beam");
        }
        public override void SetDefaults() {
			Item.damage = 32;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.knockBack = 5f;
			Item.width = 66;
			Item.height = 66;
			Item.scale = 1.3f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 25, 0, 0);
            Item.DamageType = DamageClass.Melee;
            Item.shoot = ModContent.ProjectileType<FlameBlessedBeamProj>();
            Item.shootSpeed = 12f;
			Item.UseSound = SoundID.Item1;
		}
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(3)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}
		public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
		{
			for (int f = 0; f < 3; f++)
			{
				int fireIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[fireIndex].velocity *= 4f;
			}
			if (Main.rand.NextBool(3) && !target.buffImmune[BuffID.OnFire])
			{
				for (int f = 0; f < 9; f++)
				{
					int fireIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default(Color), 3f);
					Main.dust[fireIndex2].velocity *= 6f;
				}
				SoundEngine.PlaySound(SoundID.Item88);
				target.AddBuff(BuffID.OnFire, 240);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.EnchantedSword);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(ItemID.Bone, 25);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}