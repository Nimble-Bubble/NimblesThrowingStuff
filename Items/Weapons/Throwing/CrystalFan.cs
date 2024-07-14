using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.ComponentModel.DataAnnotations;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class CrystalFan : ModItem
	{
		public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}
		public override void SetDefaults() 
		{
			Item.damage = 21;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 36;
			Item.height = 36;
			Item.useTime = 12;
			Item.useAnimation = 12;
			Item.useStyle = 1;
			Item.knockBack = 4f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 7, 50, 0);
			Item.rare = ItemRarityID.Pink;;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("CrystalKnifeProj").Type;
			Item.shootSpeed = 11f;
            Item.mana = 7;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
			velocity = perturbedSpeed;
			if (Main.rand.Next(100) <= player.GetCritChance<ThrowingDamageClass>())
			{
				type = Mod.Find<ModProjectile>("CrystalBladeProj").Type;
				damage += damage / 2;
            }
        }
        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(502, 20);
            r.AddIngredient(520, 5);
            r.AddTile(TileID.MythrilAnvil);
            r.Register();
        }
	}
}