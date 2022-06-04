using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class NanoMissile : ModItem
	{
        public override void SetStaticDefaults()
        {
         Tooltip.SetDefault("Are you sure this is legal?");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 75;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.useStyle = 1;
			Item.knockBack = 10f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(2, 0, 0, 0);
			Item.rare = 8;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("NanoMissileProj").Type;
			Item.shootSpeed = 10f;
            Item.mana = 20;
		}
	}
}