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
	public class WyvernBladeLeaf : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
			Item.damage = 36;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 22;
			Item.useTime = 22;
			Item.knockBack = 3.5f;
			Item.width = 64;
			Item.height = 64;
			Item.scale = 1f;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 8, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.crit = 14;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(5)) 
            {
				int dust = Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 46);
			}
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (!target.buffImmune[BuffID.Poisoned])
			{
				for (int f = 0; f < 9; f++)
				{
					int fireIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 46, 0f, 0f, 100, default(Color), 3f);
					Main.dust[fireIndex2].velocity *= 6f;
				}
				SoundEngine.PlaySound(SoundID.Item88);
				target.AddBuff(BuffID.Poisoned, 360);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.Katana);
			recipe.AddIngredient(ItemID.JungleSpores, 15);
			recipe.AddIngredient(ModContent.ItemType<GreenRathScale>());
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}