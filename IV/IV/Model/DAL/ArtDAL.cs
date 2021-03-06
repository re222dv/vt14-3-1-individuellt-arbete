﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace IV.Model.DAL {
    public class ArtDAL {
        public const int ALBUM_ART_BIG = 270;
        public const int ALBUM_ART_MEDIUM = 150;
        public const int ALBUM_ART_SMALL = 60;
        public const int ARTIST_ART_SMALL_WIDTH = 240;
        public const int ARTIST_ART_SMALL_HEIGHT = 100;

        public static readonly String PhysicalAlbumArtPath;
        public static readonly String PhysicalArtistArtPath;

        static ArtDAL() {
            var PhysicalImagesPath = Path.Combine(
                AppDomain.CurrentDomain.GetData("APPBASE").ToString(),
                "Content/Images"
            );

            PhysicalAlbumArtPath = Path.Combine(PhysicalImagesPath, "Albums");
            PhysicalArtistArtPath = Path.Combine(PhysicalImagesPath, "Artists");
        }

        /// <summary>
        /// Deletes a file from the filesystem
        /// </summary>
        private static bool DeleteFile(String path) {
            if (File.Exists(path)) {
                File.Delete(path);
                return true;
            }
            return false;
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

        /// <summary>
        /// Creates an image with the specified size times size
        /// </summary>
        public static void PrepareAlbumArt(int albumId, int size) {
            var path = Path.Combine(PhysicalAlbumArtPath, String.Format("{0}_{1}.jpg", albumId, size));

            if (!File.Exists(path)) {
                var orig = Image.FromFile(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}.jpg", albumId)));
                var resized = orig.GetThumbnailImage(size, size, null, System.IntPtr.Zero);
                resized.Save(path);

                orig.Dispose();
                resized.Dispose();
            }
        }

        /// <summary>
        /// Creates an image with atleast the specified width and height while keeping the aspect ratio
        /// </summary>
        public static void PrepareArtistArt(int artistId, int width, int height) {
            var path = Path.Combine(PhysicalArtistArtPath, String.Format("{0}_{1}x{2}.jpg", artistId, width, height));

            if (!File.Exists(path)) {
                var orig = Image.FromFile(Path.Combine(PhysicalArtistArtPath, String.Format("{0}.jpg", artistId)));

                double ratio;

                if (orig.Width / width < orig.Height / height) {
                    ratio = orig.Width / (double) width;
                } else {
                    ratio = orig.Height / (double) height;
                }

                width = (int) Math.Round(orig.Width / ratio);
                height = (int) Math.Round(orig.Height / ratio);

                var resized = orig.GetThumbnailImage(width, height, null, System.IntPtr.Zero);
                resized.Save(path);

                orig.Dispose();
                resized.Dispose();
            }
        }

        /// <summary>
        /// Deletes all images associated with the album
        /// </summary>
        public static void DeleteAlbumArt(int albumId) {
            DeleteFile(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}.jpg", albumId)));
            DeleteFile(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}_{1}.jpg", albumId, ALBUM_ART_BIG)));
            DeleteFile(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}_{1}.jpg", albumId, ALBUM_ART_MEDIUM)));
            DeleteFile(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}_{1}.jpg", albumId, ALBUM_ART_SMALL)));
        }

        /// <summary>
        /// Deletes all images associated with the artist
        /// </summary>
        public static void DeleteArtistArt(int artistId) {
            DeleteFile(Path.Combine(PhysicalArtistArtPath, String.Format("{0}.jpg", artistId)));
            DeleteFile(Path.Combine(PhysicalArtistArtPath, String.Format("{0}_{1}x{2}.jpg", artistId, ARTIST_ART_SMALL_WIDTH, ARTIST_ART_SMALL_HEIGHT)));
        }

        /// <summary>
        /// Save the album art and create all custom sizes
        /// </summary>
        public static void SaveAlbumArt(Stream stream, int albumId) {
            var image = Image.FromStream(stream);

            if (!IsValidImage(image)) {
                throw new ArgumentException();
            }

            image.Save(Path.Combine(PhysicalAlbumArtPath, String.Format("{0}.jpg", albumId)));
            image.Dispose();
            stream.Dispose();

            PrepareAlbumArt(albumId, ALBUM_ART_BIG);
            PrepareAlbumArt(albumId, ALBUM_ART_MEDIUM);
            PrepareAlbumArt(albumId, ALBUM_ART_SMALL);
        }

        /// <summary>
        /// Save the artist art and create all custom sizes
        /// </summary>
        public static void SaveArtistArt(Stream stream, int artistId) {
            var image = Image.FromStream(stream);

            if (!IsValidImage(image)) {
                throw new ArgumentException();
            }

            image.Save(Path.Combine(PhysicalArtistArtPath, String.Format("{0}.jpg", artistId)));
            image.Dispose();
            stream.Dispose();

            PrepareArtistArt(artistId, ARTIST_ART_SMALL_WIDTH, ARTIST_ART_SMALL_HEIGHT);
        }
    }
}