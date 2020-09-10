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
    public class CobaltCrown : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cobalt Crown");
                Tooltip.SetDefault("Increases minion damage by 5%");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 75000;
            item.rare = 4;
            item.defense = 0; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.CobaltBreastplate && legs.type == ItemID.CobaltLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased minion damage and slots";
            player.minionDamage += 0.15f;
            player.maxMinions += 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.05f;
            player.maxMinions += 1;
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = true;  
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(mod);
            r.AddIngredient(381, 10);
            r.AddTile(16);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}