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
    public class OrichalcumHornedHat : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            // DisplayName.SetDefault("Orichalcum Horned Hat");
                // Tooltip.SetDefault("Increases minion damage by 8% and minion slots by 1");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.value = 112500;
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 1; // The Defence value for this piece of armour.
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.OrichalcumBreastplate && legs.type == ItemID.OrichalcumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased minion damage and slots, plus some petals";
            player.maxMinions += 1;
            player.GetDamage(DamageClass.Summon) += 0.18f;
            player.onHitPetal = true;
            
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Summon) += 0.08f;
            player.maxMinions += 1;
        }
        //unfortunately, minions can't crit


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(1191, 12);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}