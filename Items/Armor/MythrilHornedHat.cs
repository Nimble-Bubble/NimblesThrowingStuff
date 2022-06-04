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
    public class MythrilHornedHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mythril Horned Hat");
                Tooltip.SetDefault("Increases minion damage by 7% and minion slots by 1");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 112500;
            Item.rare = 4;
            Item.defense = 1; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.MythrilChainmail && legs.type == ItemID.MythrilGreaves;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased minion damage and slots";
            player.maxMinions += 1;
            player.minionDamage += 0.12f;
            
        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.07f;
            player.maxMinions += 1;
        }


        public override void AddRecipes()
        {
            ModRecipe r = new ModRecipe(Mod);
            r.AddIngredient(382, 10);
            r.AddTile(134);
            r.SetResult(this);
            r.AddRecipe();
        }
    }
}