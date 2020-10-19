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
    [AutoloadEquip(EquipType.Legs)]
    public class BatBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
                Tooltip.SetDefault("Increases movement speed by 10%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 20000;
            item.rare = 1;
            item.defense = 3; // The Defence value for this piece of armour.
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("BatMail") && head.type == mod.ItemType("BatMask");
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "10% increase minion damage and knockback";
            player.minionDamage += 0.1f;
            player.minionKB += 0.1f;
        }
        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(19, 12);
            r.AddIngredient(mod.ItemType("BatFlesh"), 9);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
            r = new ModRecipe(mod);
            r.AddIngredient(706, 12);
            r.AddIngredient(mod.ItemType("BatFlesh"), 9);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}