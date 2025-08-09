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
	public class Quaxe : ModItem
	{
		//I know it looks weirdly gray right now, but I'll probably make a sprite with a different palette soon
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }
        public override void SetDefaults() {
			Item.damage = 40;
			Item.useStyle = 1;
			Item.useAnimation = 30;
			Item.useTime = 30;
			Item.knockBack = 8f;
			Item.width = 64;
			Item.height = 64;
			Item.rare = ItemRarityID.Green;
			Item.value = Item.buyPrice(0, 0, 29, 99);
            Item.DamageType = DamageClass.Melee;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.scale = 1.25f;
		}
		public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
			for (int f = 0; f < 10; f++)
				{
					int bloodIndex = Dust.NewDust(new Vector2(target.position.X, target.position.Y), target.width, target.height, 5, 0f, 0f, 100, default(Color), 3f);
					Main.dust[bloodIndex].velocity *= 4f;
				}
			target.AddBuff(BuffID.Bleeding, 150);
		}
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.MeteoriteBar, 12);
			recipe.AddRecipeGroup(RecipeGroupID.IronBar, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}