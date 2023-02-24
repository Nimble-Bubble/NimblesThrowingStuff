using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class ThornyGlove : ModItem
	{
        public override void SetStaticDefaults()
        {
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			DisplayName.SetDefault("Thorned Glove");
			Tooltip.SetDefault("Throws out poisonous seeds");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 40;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 34;
			Item.height = 34;
			Item.useTime = 10;
			Item.useAnimation = 10;
			Item.useStyle = 1;
			Item.knockBack = 3.6f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 36, 0, 0);
			Item.rare = 7;
			Item.UseSound = SoundID.Item5;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("PoisonSeedProj").Type;
			Item.shootSpeed = 12f;
            Item.mana = 6;
		}
        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
				Vector2 perturbedSpeed = velocity.RotatedByRandom(MathHelper.ToRadians(20));
			velocity = perturbedSpeed;
        }
	}
}