using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class RedWing : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("A greatsword designed to resemble a Rathalos' wing."
				+"\nIncendiary powder on the blade ignites targets on contact."); */
        }
        public override void SetDefaults() {
			Item.damage = 34;
			Item.useStyle = 1;
			Item.useAnimation = 28;
			Item.useTime = 28;
			Item.knockBack = 6f;
			Item.width = 70;
			Item.height = 80;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 1.15f;
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			for (int f = 0; f < 3; f++)
			{
				int fireIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[fireIndex].velocity *= 6f;
			}
			if (Main.rand.NextBool(4) && !target.buffImmune[BuffID.OnFire])
			{
				for (int f = 0; f < 12; f++)
				{
					int fireIndex2 = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 6, 0f, 0f, 100, default(Color), 3f);
					Main.dust[fireIndex2].velocity *= 8f;
				}
				SoundEngine.PlaySound(SoundID.Item88);
				target.AddBuff(BuffID.OnFire, 360);
			}
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<RedRathScale>(), 12);
			recipe.AddIngredient(ItemID.BeeWax, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}