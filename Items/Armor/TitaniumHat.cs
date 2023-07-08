using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Titanium Hat");
                // Tooltip.SetDefault("Increases thrown damage by 21% and thrown critical strike chance by 12%");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 32;
            Item.value = 150000;
            Item.rare = 4;
            Item.defense = 11; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Attacking generates a defensive barrier of titanium shards";
            player.onHitTitaniumStorm = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.21f;
            player.GetCritChance(DamageClass.Throwing) += 12;
        }


        public override void AddRecipes()
        {
            Recipe r = CreateRecipe();
            r.AddIngredient(1198, 13);
            r.AddTile(134);
            r.Register();
        }
    }
}