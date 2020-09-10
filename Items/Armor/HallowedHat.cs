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
    public class HallowedHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Hat");
                Tooltip.SetDefault("Increases minion damage by 12% and minion slots by 1");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 250000;
            item.rare = 5;
            item.defense = 3; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 551 && legs.type == 552;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased minion damage and slots";
            player.minionDamage += 0.13f;
            player.maxMinions += 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.12f;
            player.maxMinions += 1;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(1225, 12);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}