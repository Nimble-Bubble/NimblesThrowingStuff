using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NimblesThrowingStuff.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MorilusMask : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 32;
            item.value = 37500;
            item.rare = ItemRarityID.Blue;
            item.vanity = true;
        }
    }
}