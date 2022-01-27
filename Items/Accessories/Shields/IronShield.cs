using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Accessories.Shields
{
    [AutoloadEquip(EquipType.Shield)]
    public class IronShield : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Slow when guarding, but provides a nice defense");
        }
        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 26;
            item.value = item.value = Item.buyPrice(0, 1, 25, 0);
            item.rare = 0;
            item.defense = 2;
        }
        public override bool CanEquipAccessory(Player player, int slot)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            if (modPlayer.whichShield >= 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.whichShield = 1;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
