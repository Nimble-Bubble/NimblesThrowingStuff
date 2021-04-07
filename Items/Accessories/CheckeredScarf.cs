  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories
{
    [AutoloadEquip(EquipType.Neck)]
    public class CheckeredScarf : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The perfect scarf for any leader"
            + "\nGives minions local cooldowns");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 22;
            item.height = 22;
            item.value = Item.sellPrice(0, 6, 21, 0);
            item.rare = 5;
            item.expert = false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.miniLocal = true;
        }
        public override void AddRecipes() 
        {
			ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DarkShard);
            recipe.AddIngredient(ItemID.LightShard);
            recipe.AddIngredient(ItemID.Silk, 20);
			recipe.AddTile(TileID.Loom);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}