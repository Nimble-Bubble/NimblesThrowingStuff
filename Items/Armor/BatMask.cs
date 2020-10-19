using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class BatMask : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases minion damage by 5%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 15000;
            item.rare = 1;
            item.defense = 3; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.05f;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(19, 8);
            r.AddIngredient(mod.ItemType("BatFlesh"), 6);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
            r = new ModRecipe(mod);
            r.AddIngredient(706, 8);
            r.AddIngredient(mod.ItemType("BatFlesh"), 6);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}