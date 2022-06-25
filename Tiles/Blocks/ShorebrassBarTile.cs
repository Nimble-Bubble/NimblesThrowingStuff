using NimblesThrowingStuff.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
namespace NimblesThrowingStuff.Tiles.Blocks
{
    public class ShorebrassBarTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
			Main.tileLavaDeath[Type] = false;
            Main.tileSolid[Type] = true;
            Main.tileBlockLight[Type] = false;
            Main.tileMergeDirt[Type] = false;
            ItemDrop = ModContent.ItemType<ShorebrassBar>();
            TileObjectData.newTile.StyleWrapLimit = 18;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Procellarite Bar");
            AddMapEntry(new Color(0, 200, 185), name);
            MineResist = 1.5f;
            MinPick = 65;
            HitSound = SoundID.Dig;
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}
