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
			item.damage = 75;
			item.thrown = true;
			item.width = 24;
			item.height = 24;
			item.useTime = 30;
			item.useAnimation = 30;
			item.useStyle = 1;
			item.knockBack = 10f;
            item.noMelee = true;
            item.noUseGraphic = true;
			item.value = Item.buyPrice(2, 0, 0, 0);
			item.rare = 8;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("NanoMissileProj");
			item.shootSpeed = 10f;
            item.mana = 20;
		}
	}
}