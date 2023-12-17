using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using NimblesThrowingStuff.Items.Materials;
using Terraria.GameContent.Creative;
using NimblesThrowingStuff.Tiles.Furniture;

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ProcellariteCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases throwing damage by 30% and critical strike chance by 20%"
                +"\nThe wings on this hat may have been used to boost flight at one point, but they are merely decorative now."); */
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 20;
            Item.value = 500000;
            Item.rare = ItemRarityID.Red;
            Item.defense = 18; 
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("ProcellariteChestplate").Type && legs.type == Mod.Find<ModItem>("ProcellariteLeggings").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Mana increased by 100 and throwing speed increased by 25%";
            var modPlayer = player.GetModPlayer<NimblesPlayer>();
            modPlayer.thrownSpeed += 0.25f;
            player.statManaMax2 += 100;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.3f;
            player.GetCritChance(DamageClass.Throwing) += 20;
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ProcellariteBar>(), 12);
            recipe.AddTile(ModContent.TileType<ProcellaritePressTile>());
            recipe.Register();
        }
    }
}