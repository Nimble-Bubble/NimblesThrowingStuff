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

namespace NimblesThrowingStuff.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class AzureRathalosGreaves : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
            /* Tooltip.SetDefault("Increases damage by 5%"
                +"\nGrants 2 seconds of lava immunity"); */
        }

        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 26;
            Item.value = 60000;
            Item.rare = ItemRarityID.Lime;
            Item.defense = 14; 
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.13f;
            player.lavaImmune = true;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == Mod.Find<ModItem>("AzureRathalosHelm").Type && body.type == Mod.Find<ModItem>("AzureRathalosMail").Type;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Projectile attacks will light targets on hellfire"
                +"\nAdditionally, your critical strike chance is increased by 16%";
            player.lavaImmune = true;
            player.GetCritChance(DamageClass.Generic) += 16;
            player.GetModPlayer<NimblesPlayer>().rathalosOnFire = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RathalosGreaves>());
            recipe.AddIngredient(ItemID.SpectreBar, 12);
			recipe.AddIngredient(ItemID.ShroomiteBar, 12);
			recipe.AddIngredient(ItemID.Sapphire, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}