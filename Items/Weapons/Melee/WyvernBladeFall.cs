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
using NimblesThrowingStuff.Items.Materials;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class WyvernBladeFall : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
			Item.damage = 39;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 3.5f;
			Item.width = 72;
			Item.height = 72;
			Item.scale = 1.125f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.crit = 19;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(2)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 6);
			}
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!target.buffImmune[BuffID.OnFire])
			{
				for (int f = 0; f < 15; f++)
				{
					int fireIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default(Color), 3f);
					Main.dust[fireIndex2].velocity *= 6f;
				}
				SoundEngine.PlaySound(SoundID.Item88);
				target.AddBuff(BuffID.OnFire, 300);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Katana);
			recipe.AddIngredient(ItemID.HellstoneBar, 15);
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}