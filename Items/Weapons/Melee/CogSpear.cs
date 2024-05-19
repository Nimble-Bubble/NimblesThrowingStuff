using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using System;
using NimblesThrowingStuff.Projectiles.Melee;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using Terraria.Audio;

namespace NimblesThrowingStuff.Items.Weapons.Melee
{
	public class CogSpear : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			/* Tooltip.SetDefault("Mightiest Battle Spear in the East Blue"
				+"\nDon Krieg Pirates Guild ON TOP"); */
		}
		public override void SetDefaults()
		{
			Item.damage = 64;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 24;
			Item.useTime = 24;
			Item.knockBack = 8f;
			Item.width = 64;
			Item.height = 64;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.buyPrice(0, 17, 0, 0);
			Item.DamageType = DamageClass.Melee;
			Item.channel = true;
			Item.shoot = ModContent.ProjectileType<CogSpearProj>();
			Item.shootSpeed = 10f;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item1;
			Item.scale = 1f;
		}
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.altFunctionUse == 2)
            {
				Item.useStyle = ItemUseStyleID.Swing;
				Item.shoot = ProjectileID.None;
				Item.noUseGraphic = false;
				Item.noMelee = false;
            }
			else
            {
				Item.useStyle = ItemUseStyleID.Shoot;
				Item.shoot = ModContent.ProjectileType<CogSpearProj>();
				Item.noUseGraphic = true;
				Item.noMelee = true;
			}
			return base.CanUseItem(player);
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
				target.AddBuff(BuffID.OnFire3, 450);
			}
		}
        public override void AddRecipes()
		{
			/* Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<KnightLance>(), 1);
			recipe.AddRecipeGroup(nameof(ItemID.AdamantiteBar), 12);
			recipe.AddIngredient(ItemID.HallowedBar, 12);
			recipe.AddIngredient(ItemID.Cog, 50);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
			recipe = CreateRecipe();
			recipe.AddRecipeGroup(nameof(ItemID.AdamantiteBar), 18);
			recipe.AddIngredient(ItemID.Cog, 100);
			recipe.AddIngredient(ItemID.HallowedBar, 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register(); */
		}
	}
}