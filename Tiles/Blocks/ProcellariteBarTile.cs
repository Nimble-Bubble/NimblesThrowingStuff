using NimblesThrowingStuff.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class ProcellariteBarTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileMergeDirt[Type] = false;
            RegisterItemDrop(ModContent.ItemType<ProcellariteBar>());
            TileObjectData.newTile.StyleWrapLimit = 18;
            LocalizedText name = CreateMapEntryName();
            // name.SetDefault("Procellarite Bar");
            AddMapEntry(new Color(0, 200, 185), name);
            MineResist = 2f;
            MinPick = 210;
            HitSound = SoundID.Dig;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
