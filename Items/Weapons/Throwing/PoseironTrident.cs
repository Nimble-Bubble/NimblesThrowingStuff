using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NimblesThrowingStuff.Items.Weapons.Throwing
{
	public class PoseironTrident : ModItem
	{
        public override void SetStaticDefaults()
        {
        DisplayName.SetDefault("Poseiron's Trident");
         Tooltip.SetDefault("A sea god's three-pronged spear that oils and frostburns foes");   
        }

		public override void SetDefaults() 
		{
			Item.damage = 78;
			Item.DamageType = DamageClass.Throwing;
			Item.width = 24;
			Item.height = 24;
			Item.useTime = 24;
			Item.useAnimation = 24;
			Item.useStyle = 1;
			Item.knockBack = 7f;
            Item.noMelee = true;
            Item.noUseGraphic = true;
			Item.value = Item.buyPrice(0, 25, 0, 0);
			Item.rare = 9;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("PoseironTridentProj").Type;
			Item.shootSpeed = 10f;
            Item.mana = 20;
		}
	}
}