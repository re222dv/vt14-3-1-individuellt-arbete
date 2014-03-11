using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using IV.Model.DAL;

namespace IV.Model {
    public class Service {

        #region Album CRUD
        /// <summary>
        /// Delete an album
        /// </summary>
        public static void DeleteAlbum(int albumID) {
            AlbumDAL.DeleteAlbum(albumID);
            DeleteAlbumArt(albumID);
        }

        /// <summary>
        /// Get all albums
        /// </summary>
        public static IEnumerable<AlbumArtist> GetAlbums() {
            return AlbumDAL.GetAlbums();
        }

        /// <summary>
        /// Get an album
        /// </summary>
        public static AlbumArtist GetAlbumById(int albumID) {
            return AlbumDAL.GetAlbumById(albumID);
        }

        /// <summary>
        /// Get an artists albums
        /// </summary>
        public static IEnumerable<Album> GetAlbumsByArtistId(int artistID) {
            return AlbumDAL.GetAlbumsByArtistId(artistID);
        }
        
        /// <summary>
        /// Save the album
        /// </summary>
        public static void SaveAlbum(Album album) {

            if (!album.Validate()) {
                throw new ValidationException();
            }

            if (album.AlbumID == 0) {
                AlbumDAL.InsertAlbum(album);
            } else {
                AlbumDAL.UpdateAlbum(album);
            }
        }
        #endregion

        #region Artist CRUD
        /// <summary>
        /// Delete an artist
        /// </summary>
        public static void DeleteArtist(int artistID) {
            foreach (var album in GetAlbumsByArtistId(artistID)) {
                DeleteAlbumArt(album.AlbumID);
            }

            ArtistDAL.DeleteArtist(artistID);
            DeleteArtistArt(artistID);
        }

        /// <summary>
        /// Get all artists
        /// </summary>
        public static IEnumerable<Artist> GetArtists() {
            return ArtistDAL.GetArtists();
        }

        /// <summary>
        /// Get an artist
        /// </summary>
        public static Artist GetArtistById(int artistID) {
            return ArtistDAL.GetArtistById(artistID);
        }

        /// <summary>
        /// Save the artist
        /// </summary>
        public static void SaveArtist(Artist artist) {

            if (!artist.Validate()) {
                throw new ValidationException();
            }

            if (artist.ArtistID == 0) {
                ArtistDAL.InsertArtist(artist);
            } else {
                ArtistDAL.UpdateArtist(artist);
            }
        }
        #endregion

        #region Song CRUD
        /// <summary>
        /// Delete a song
        /// </summary>
        public static void DeleteSong(int songID) {
            SongDAL.DeleteSong(songID);
        }

        /// <summary>
        /// Get a song
        /// </summary>
        public static Song GetSongById(int songID) {
            return SongDAL.GetSongById(songID);
        }

        /// <summary>
        /// Get an albums songs
        /// </summary>
        public static IEnumerable<Song> GetSongsByAlbumId(int albumID) {
            return SongDAL.GetSongsByAlbumId(albumID);
        }

        /// <summary>
        /// Save the song
        /// </summary>
        public static void SaveSong(Song song) {

            if (!song.Validate()) {
                throw new ValidationException();
            }

            if (song.SongID == 0) {
                SongDAL.InsertSong(song);
            } else {
                SongDAL.UpdateSong(song);
            }
        }
        #endregion

        #region ART CD
        /// <summary>
        /// Deletes all images associated with the album
        /// </summary>
        public static void DeleteAlbumArt(int albumId) {
            ArtDAL.DeleteAlbumArt(albumId);
        }

        /// <summary>
        /// Deletes all images associated with the artist
        /// </summary>
        public static void DeleteArtistArt(int artistId) {
            ArtDAL.DeleteArtistArt(artistId);
        }

        /// <summary>
        /// Save the album art and create all custom sizes
        /// </summary>
        public static void SaveAlbumArt(Stream stream, int albumId) {
            ArtDAL.SaveAlbumArt(stream, albumId);
        }

        /// <summary>
        /// Save the artist art and create all custom sizes
        /// </summary>
        public static void SaveArtistArt(Stream stream, int artistId) {
            ArtDAL.SaveArtistArt(stream, artistId);
        }
        #endregion
    }
}