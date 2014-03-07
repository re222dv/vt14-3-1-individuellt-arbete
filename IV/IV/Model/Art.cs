using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace IV.Model {
    public class Art {
        public static readonly String PhysicalAlbumArtPath;
        public static readonly String PhysicalArtistArtPath;

        static Art() {
            var PhysicalImagesPath = Path.Combine(
                AppDomain.CurrentDomain.GetData("APPBASE").ToString(),
                "Content/Images"
            );

            PhysicalAlbumArtPath = Path.Combine(PhysicalImagesPath, "Albums");
            PhysicalArtistArtPath = Path.Combine(PhysicalImagesPath, "Artists");
        }

        /// <summary>
        /// Checks if the image is one of the supported filetypes
        /// </summary>
        private static bool IsValidImage(Image image) {
            if (image == null) {
                return false;
            }
            return image.RawFormat.Guid == System.Drawing.Imaging.ImageFormat.Jpeg.Guid;
        }

        public static void SaveAlbumArt(Stream stream, int albumId) {
            var image = Image.FromStream(stream);

            if (!IsValidImage(image)) {
                throw new ArgumentException();
            }

            image.Save(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}.jpg", albumId)));
        }

        public static void SaveArtistArt(Stream stream, int artistId) {
            var image = Image.FromStream(stream);

            if (!IsValidImage(image)) {
                throw new ArgumentException();
            }

            image.Save(Path.Combine(PhysicalArtistArtPath, String.Format("{0}.jpg", artistId)));
        }

        public static void PrepareAlbumArt(int albumId, int size) {
            var path = Path.Combine(PhysicalAlbumArtPath, String.Format("{0}_{1}.jpg", albumId, size));

            if (!File.Exists(path)) {
                var orig = Image.FromFile(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}.jpg", albumId)));
                var resized = orig.GetThumbnailImage(size, size, null, System.IntPtr.Zero);
                resized.Save(path);
            }
        }

        public static void PrepareArtistArt(int artistId, int width, int height) {
            var path = Path.Combine(PhysicalArtistArtPath, String.Format("{0}_{1}x{2}.jpg", artistId, width, height));

            if (!File.Exists(path)) {
                var orig = Image.FromFile(Path.Combine(PhysicalArtistArtPath, String.Format("{0}.jpg", artistId)));
                var resized = orig.GetThumbnailImage(width, height, null, System.IntPtr.Zero);
                resized.Save(path);
            }
        }
    }
}